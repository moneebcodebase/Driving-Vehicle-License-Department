using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using Microsoft.Win32;


namespace DVLD.Classes
{
    internal static  class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            //Registry path
            string RegPath = @"HKEY_CURRENT_USER\Software\DVLD";

            try
            {
                if(Username != "" && Password !="")
                {
                    //this will create a registry Valuename (username) with it's value 
                    Registry.SetValue(RegPath, "Username", Username, RegistryValueKind.String);
                    //this will create a registry Valuename (Password) with it's value Encrypted
                    Registry.SetValue(RegPath, "Password", Encryption(Password), RegistryValueKind.String);
                }
                else
                {
                    //this will create a registry Valuename (username) with empty value
                    Registry.SetValue(RegPath, "Username", "", RegistryValueKind.String);
                    //this will create a registry Valuename (Password) with empty value
                    Registry.SetValue(RegPath, "Password", "", RegistryValueKind.String);
                }
                
            }
            catch
            {
               return false;
            }

            return true;
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.

            //Registry path
            string RegPath = @"HKEY_CURRENT_USER\Software\DVLD";
            
            try
            {
                Username = Registry.GetValue(RegPath, "Username", "") as string;
                string EncryptedPassword = Registry.GetValue(RegPath, "Password", "") as string;

                if (EncryptedPassword != null)
                {
                    Password = Decryption(EncryptedPassword);
                }
                else
                {
                    Password = "";
                }
            }
            catch
            {
                return false;
            }

            return true;
           
        }


        public static string Encryption(string Password)
        {
            string EncryptedPassword = "";


            foreach (char c in Password)
            {
                char NewC = (char)(c + 12);

                EncryptedPassword = EncryptedPassword + NewC;
            }


            return EncryptedPassword;
        }

        public static string Decryption(string Password)
        {
            string EncryptedPassword = "";


            foreach (char c in Password)
            {
                char NewC = (char)(c - 12);

                EncryptedPassword = EncryptedPassword + NewC;
            }


            return EncryptedPassword;
        }
    }
}
