using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
namespace WebRequester
{
    /*
     * Convert configuration key saved as readeable by an human format to Hotkeys
     * SHIFT + ALT + A (ex) --> Object Input.ModifierKeys and Input.Key
     */
    class KeysConverter
    {
        public System.Windows.Input.ModifierKeys HotKeyModifiers { get; set; }
        public System.Windows.Input.Key HotKeyCode { get; set; }
        public bool error = false;
        public string[] keysArray = new string[] { };

        public void StringToHotKeys(String keys)
        {
            Console.WriteLine(keys);
            this.keysArray = keys.Split('+');

            //Get Modifiers
            this.StringToModifiers();
            //Get Keys
            this.StringToKey();
        }

        public void StringToModifiers()
        {
            this.HotKeyModifiers = System.Windows.Input.ModifierKeys.None;

            for (int i = 0; i < this.keysArray.Length - 1; i++)
            {
                switch (this.keysArray[i].Trim())
                {
                    case "Alt":
                        this.HotKeyModifiers = HotKeyModifiers | System.Windows.Input.ModifierKeys.Alt;
                        break;

                    case "Control":
                        this.HotKeyModifiers = HotKeyModifiers | System.Windows.Input.ModifierKeys.Control;
                        break;

                    case "Shift":
                        this.HotKeyModifiers = HotKeyModifiers | System.Windows.Input.ModifierKeys.Shift;
                        break;
                }
            }
        }

        public void StringToKey()
        {
            TypeConverter keyConverter = TypeDescriptor.GetConverter(typeof(System.Windows.Input.Key));
            try { 
            this.HotKeyCode = (System.Windows.Input.Key)keyConverter.ConvertFromString(this.keysArray[this.keysArray.Length - 1]);
            }
            catch (Exception E)
            {
                this.error = true;
                //MessageBox.Show(E.Message, "Hot Key cannot be registered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string getKey()
        {
            string key = this.keysArray[this.keysArray.Length - 1];
            return key.Trim();
        }
    }
}
