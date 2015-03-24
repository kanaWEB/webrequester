using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace WebRequester
{
    /*
     * 
     * All web request are handle by this class
     * 
     */
    class WebManager
    {
        const string POST_TOKEN = "token=";
        const string TOKEN_LINK = "/token.php";
        const string ACTION_LINK = "api/v1/action/";

        //Manage Post Request
        public dynamic sendPost(string post_data, string uri)
        {
            //Console.WriteLine(uri);
            
            //Authorized unsigned HTTPS 
            // source: http://smarturl.it/httpscsharp
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; 
            
            JsonForger Json = new JsonForger();
            string json_answer = Json.ClientError("Unexpected Error", "ERROR", "");
            dynamic answer = JsonConvert.DeserializeObject(json_answer);

            // create a request
            // source: http://smarturl.it/httpostcsharp
            //Catch invalid URL
            try
            {
                HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create(uri);
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "POST";

                // turn our request string into a byte stream
                byte[] postBytes = Encoding.ASCII.GetBytes(post_data);

                // this is important - make sure you specify type this way
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;

                //Catch Server Invalid Request
                try
                {
                    Stream requestStream = request.GetRequestStream();
                    // now send it
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    // grab the response and print it out to the console along with the status code
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    json_answer = new StreamReader(response.GetResponseStream()).ReadToEnd().ToString();
                    //Console.WriteLine(response.StatusCode.ToString());
                }
                //LOCAL : No Server found
                catch (Exception error)
                {
                    json_answer = Json.ClientError("No Server founded", "ERROR", error.Message);

                }

                //REMOTE : Response is OK (json)
                try
                {
                    if (String.IsNullOrEmpty(json_answer))
                    { //REMOTE : Empty response
                        json_answer = Json.ClientError("Empty Response", "ERROR", "Server responded nothing :-(");
                    }
                    answer = JsonConvert.DeserializeObject(json_answer);

                }
                catch (Exception error) //REMOTE : Response is not json
                {
                    json_answer = Json.ClientError("Incorrect Response : "+ error.Message, "ERROR", json_answer);
                    answer = JsonConvert.DeserializeObject(json_answer);
                }

            }
            catch (Exception e) //LOCAL BAD URL
            {
                json_answer = Json.ClientError("Invalid Action or URL", "ERROR", uri + " \n" + e.Message);
                answer = JsonConvert.DeserializeObject(json_answer);
            }
            return answer;
        }

        public dynamic Action(string Token, string URL, string Action)
        {
            string CompleteUrl = URL + ACTION_LINK + Action;
            string CompleteToken = POST_TOKEN + Token;
            dynamic answer = sendPost(CompleteToken, CompleteUrl);
            return answer;
        }

        public dynamic Check_Server(string Token, string URL)
        {
            //Check Token and Server
            dynamic answer = sendPost(POST_TOKEN + Token, URL + TOKEN_LINK);
            return answer;
        }
    }
}
