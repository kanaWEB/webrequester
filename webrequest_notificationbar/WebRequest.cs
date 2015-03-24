using GlobalHotKey;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Configuration;
using Microsoft.Win32;

namespace WebRequester
{
    public partial class NotificationBar : Form
    {
        private HotKeyManager _hotKeyManager;
        private WebManager Web = new WebManager();
        private KeysConverter HotKey_ON = new KeysConverter();
        private KeysConverter HotKey_OFF = new KeysConverter();

        public NotificationBar()
        {
            InitializeComponent();
           
            _hotKeyManager = new HotKeyManager(); //Manage Hot Keys (Hotkeys works even if application is not focused)
            _hotKeyManager.KeyPressed += HotKeyPressed;
        }

        //On form load
        private void NotificationBar_Load(object sender, EventArgs e)
        {
            //Create context
            ContextMenu Menu = new ContextMenu();
            MenuItem MenuItem_ON = new MenuItem("&ON", sendCode);
            MenuItem_ON.Name = "ON";

            MenuItem MenuItem_OFF = new MenuItem("&OFF", sendCode);
            MenuItem_OFF.Name = "OFF";

            Menu.MenuItems.Add(MenuItem_ON);
            Menu.MenuItems.Add(MenuItem_OFF);
            Menu.MenuItems.Add("&Configuration", showConfiguration);
            Menu.MenuItems.Add("&Exit", ExitApplication);

            //Create notification icon
            BarIcon.Icon = this.Icon;
            BarIcon.ContextMenu = Menu;

            //Get Configuration
            URL.Text = Properties.Settings.Default.URL;
            Token.Text = Properties.Settings.Default.Token;
            ActionON_Text.Text = Properties.Settings.Default.ON_ACTION;
            ActionOFF_Text.Text = Properties.Settings.Default.OFF_ACTION;
            ActionONKey_Text.Text = Properties.Settings.Default.ON_HOTKEY;
            ActionOFFKey_Text.Text = Properties.Settings.Default.OFF_HOTKEY;
            startOnBoot.Checked = Properties.Settings.Default.StartOnBoot;

            //If properties wasn't set, we show configuration
            if (Properties.Settings.Default.FirstStart)
            {
                showConfiguration();
            }

            
            HotKey_ON.StringToHotKeys(Properties.Settings.Default.ON_HOTKEY);
            HotKey_OFF.StringToHotKeys(Properties.Settings.Default.OFF_HOTKEY);
            //Register hotKeys (if there are valid)
            if (!HotKey_ON.error) { 
                _hotKeyManager.Register(HotKey_ON.HotKeyCode, HotKey_ON.HotKeyModifiers);
            }
            if (!HotKey_OFF.error){
                _hotKeyManager.Register(HotKey_OFF.HotKeyCode, HotKey_OFF.HotKeyModifiers);
            }

        }

        private void showConfiguration(object sender, EventArgs e)
        {
            showConfiguration();
        }

        private void showConfiguration()
        {
            //Display Configuration window

            this.WindowState = FormWindowState.Normal;
            Screen screen = Screen.FromControl(this);

            //Center Configuration window
            Rectangle workingArea = screen.WorkingArea;
            this.Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - this.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - this.Height) / 2)
            };
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            _hotKeyManager.Dispose();
            BarIcon.Dispose();
            Application.Exit();
        }

       

        private void DisplayBalloon(String text)
        {
            BarIcon.BalloonTipTitle = "Requester";
            BarIcon.BalloonTipText = text;
            BarIcon.ShowBalloonTip(1000);
        }

        //When a hot keys is pressed (Execute theses actions)
        void HotKeyPressed(object sender, KeyPressedEventArgs e)
        {
            DisplayBalloon("HOTKEY PRESSED");
            string key = e.HotKey.Key.ToString();
            sendCode(key);

        }

        private void sendCode(string key)
        {
            string URL = Properties.Settings.Default.URL;
            string Token = Properties.Settings.Default.Token;
            string ActionSelected = ActionOFF_Text.Text;
            //Saving Actions and Hotkeys
            //Console.WriteLine(HotKey_ON.getKey());
            //Console.WriteLine(key);

            if (key == HotKey_ON.getKey())
            {
                ActionSelected = ActionON_Text.Text;
            }

             if (key == HotKey_OFF.getKey())
            {
                 ActionSelected = ActionOFF_Text.Text;
            }
               
            dynamic answer = Web.Action(Token, URL, ActionSelected);
            this.answerToMessageBox(answer,true);
        }

        private void sendCode(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            string code = mi.Name;

            string URL = Properties.Settings.Default.URL;
            string Token = Properties.Settings.Default.Token;
            string ActionSelected = ActionOFF_Text.Text;

            DisplayBalloon("Sending request");
            if (code == "ON")
            {
                ActionSelected = ActionON_Text.Text;
            }

            if (code == "OFF")
            {
                ActionSelected = ActionOFF_Text.Text;
            }

            dynamic answer = Web.Action(Token, URL, ActionSelected);
            this.answerToMessageBox(answer, true);
            
        }

        private void SetKey(object sender, KeyEventArgs e)
        {
            TextBox hotkeybox = sender as TextBox;

            string KeyCode = e.KeyCode.ToString();
            string Modifiers = e.Modifiers.ToString().Replace(",", " +");

            //We doesn't take the new hotkey if it is just Modifiers keys
            if ((KeyCode != "ShiftKey") && (KeyCode != "ControlKey") && (KeyCode != "Menu") && (Modifiers != "None +"))
            {
                if (Modifiers == "None")
                {
                    hotkeybox.Text = KeyCode;
                }
                else
                {
                    hotkeybox.Text = Modifiers + " + " + KeyCode;
                }

              
            }
        }

        private void SetKey_Focus(object sender, EventArgs e)
        {
            TextBox hotkeybox = sender as TextBox;
            hotkeybox.BackColor = Color.Red;
        }

        private void SetKey_Leave(object sender, EventArgs e)
        {
            TextBox hotkeybox = sender as TextBox;
            hotkeybox.BackColor = System.Drawing.SystemColors.HotTrack;
        }

        private void SaveConfiguration_Click(object sender, MouseEventArgs e)
        {
            //Crypt URL/Token with DPAPI
            //Not implemented

            //Unregister previous Hotkeys
            HotKey_ON.StringToHotKeys(Properties.Settings.Default.ON_HOTKEY);
            HotKey_OFF.StringToHotKeys(Properties.Settings.Default.OFF_HOTKEY);
            //Register hotKeys
            _hotKeyManager.Unregister(HotKey_ON.HotKeyCode, HotKey_ON.HotKeyModifiers);
            _hotKeyManager.Unregister(HotKey_OFF.HotKeyCode, HotKey_OFF.HotKeyModifiers);

            //Save Configuration
            Console.WriteLine("Saving Configuration");
            Properties.Settings.Default.URL = URL.Text;
            Properties.Settings.Default.Token = Token.Text;

            //Saving Actions and Hotkeys
            Properties.Settings.Default.ON_ACTION = ActionON_Text.Text;
            Properties.Settings.Default.ON_HOTKEY = ActionONKey_Text.Text;

            Properties.Settings.Default.OFF_ACTION = ActionOFF_Text.Text;
            Properties.Settings.Default.OFF_HOTKEY = ActionOFFKey_Text.Text;

            //Do the user want the application to start on boot ?
            Properties.Settings.Default.StartOnBoot = startOnBoot.Checked;
            Settings SH = new Settings();
            SH.OnBoot(startOnBoot.Checked);

            //We won't display FirstStart on startup
            Properties.Settings.Default.FirstStart = false;

            Properties.Settings.Default.Save();

            //Convert Readeable Hotkeys to Windows.Input.Keys/ModifiersKeys

            
            //Register Hotkeys
            
            HotKey_ON.StringToHotKeys(Properties.Settings.Default.ON_HOTKEY);
            HotKey_OFF.StringToHotKeys(Properties.Settings.Default.OFF_HOTKEY);
            //Register hotKeys
            _hotKeyManager.Register(HotKey_ON.HotKeyCode, HotKey_ON.HotKeyModifiers);
            _hotKeyManager.Register(HotKey_OFF.HotKeyCode, HotKey_OFF.HotKeyModifiers);
        }

        private void CheckServer_Button_Click(object sender, EventArgs e)
        {
            string Token = this.Token.Text;
            string URL = this.URL.Text;
            dynamic answer = Web.Check_Server(Token, URL);
            this.answerToMessageBox(answer);

        }

        private void ActionON_Click(object sender, EventArgs e)
        {

            string URL = this.URL.Text;
            string Token = this.Token.Text;
            string Action_ON = ActionON_Text.Text;

            dynamic answer = Web.Action(Token, URL, Action_ON);
            this.answerToMessageBox(answer);

        }

        private void ActionOFF_Click(object sender, EventArgs e)
        {
            string URL = this.URL.Text;
            string Token = this.Token.Text;
            string Action_OFF = ActionOFF_Text.Text;

            dynamic answer = Web.Action(Token, URL, Action_OFF);
            this.answerToMessageBox(answer);
        }

        private void answerToMessageBox(dynamic answer,bool silent=false)
        {
            string code = "None";
            string type = "None";
            string message = "None";

            type = answer.type;
            code = answer.code;
            message = answer.message;


            switch (code)
            {
                //When the server is not reachable / response badly
                case "ERROR":
                    message = message.Replace("'", "\'");
                    MessageBox.Show(message, type, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                //When server responded correctly
                default:
                    if (!silent)
                    {
                        MessageBox.Show(message, code + " - " + type, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DisplayBalloon("OK");
                    }
                    break;
            }
        }

        

    }
}
