using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WebRequester
{
    /*
     * Forge json response for local error that will looks what the server would have responded
     * 
    */
    class JsonForger
    {
        //Forge a server like response for local error
        public string ClientError(string type , string code, string message)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("type");
                writer.WriteValue(type);
                writer.WritePropertyName("code");
                writer.WriteValue(code);
                writer.WritePropertyName("message");
                writer.WriteValue(message);
                writer.WriteEndObject();
            }

            return sb.ToString();
        }
    }
}
