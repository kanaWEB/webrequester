using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Configuration;
using System.Security.Cryptography;

namespace WebRequester
{
    class Settings
    {
        public void OnBoot(bool StartOnBoot)
        {
            //Put our application in the registry to make it available at boot
            string AppName = AppDomain.CurrentDomain.DomainManager.EntryAssembly.GetName().Name;
            string Path = AppDomain.CurrentDomain.DomainManager.EntryAssembly.Location;
            Console.WriteLine(AppName);
            Console.WriteLine(Path);

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
             ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (StartOnBoot){
                rk.SetValue(AppName, Path);
            }
            else{
                rk.DeleteValue(AppName, false);
            }
        }
    }
}
