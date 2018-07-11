using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace USBHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting information of all USB connected to this machine till now..\n");
            using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\USBSTOR"))
            {
                if(regkey !=  null)
                {
                       
                    foreach(string valueName in regkey.GetSubKeyNames())
                    {
                        using (RegistryKey rootKey = regkey.OpenSubKey(valueName))
                        {
                           
                            
                            foreach (string vlName in rootKey.GetSubKeyNames())
                            {                               
                               
                                using (RegistryKey tmpreg1 = rootKey.OpenSubKey(vlName))
                                {
                                    
                                    try
                                    {
                                        if(tmpreg1.GetValue("FriendlyName") != null)
                                        {                                                                                  
                                            Console.WriteLine("Device Name        :   {0}", tmpreg1.GetValue("FriendlyName"));
                                            Console.WriteLine("Services           :   {0}", tmpreg1.GetValue("Service"));
                                            //Console.WriteLine("Manifacturer       :   {0}", tmpreg1.GetValue("Mfg"));
                                            //Console.WriteLine("Device Description :   {0}", tmpreg1.GetValue("DeviceDesc"));
                                            
                                            Console.WriteLine("-----------------------------------------------------------------\n");
                                        }                                        
                                    }
                                    catch (Exception)
                                    {
                                        
                                    }
                                   
                                }
                            }                             
                        
                        }
                    }
                }
            }
            Console.WriteLine("Reading Registry keys completed..\n");            
        }
    }
}
