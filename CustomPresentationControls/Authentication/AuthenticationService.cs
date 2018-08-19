using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace CustomPresentationControls.Authentication
{
    internal interface IAuthentication
    {
        bool AuthenticateUser(string username, string password);
        bool CreateUser(string username, string password);
        bool RemoveUser(string username, string password);
    }
    internal class AuthenticationService : IAuthentication
    {
        public bool AuthenticateUser(string username, string password)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = (config.GetSection("users") as AppSettingsSection).Settings;
            KeyValueConfigurationElement passwordCheck = settings[username];
            if (passwordCheck != null)
            {
                //string unsecuredPassword = DecipherPassword(password);
                //return GetHash(unsecuredPassword) == settings[username].Value;
                return GetHash(password) == settings[username].Value;
            }
            return false;
        }
        public bool CreateUser(string username, string password)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = (config.GetSection("users") as AppSettingsSection).Settings;
            if (settings[username] == null)
            {
                //string unsecuredPassword = DecipherPassword(password);
                //string persistentPassword = GetHash(unsecuredPassword);
                string persistentPassword = GetHash(password);
                settings.Add(username, persistentPassword);
                config.Save();
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
                return true;
            }
            return false;
        }
        public bool RemoveUser(string username, string password)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = (config.GetSection("users") as AppSettingsSection).Settings;
            //string unsecuredPassword = DecipherPassword(password);
            //string persistentPassword = GetHash(unsecuredPassword);
            string persistentPassword = GetHash(password);
            if (settings[username] == null && settings[username].Value == persistentPassword)
            {
                settings.Remove(username);
                config.Save();
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
                return true;
            }
            return false;
        }
        public static bool ValidatePassword(string password, out string message)
        {
            try
            {
                //string unsecuredPassword = Marshal.PtrToStringBSTR(Marshal.SecureStringToBSTR(password));
                message = null;
            }
            catch (Exception)
            {
                message = "Unable to decrypt password.";
            }
            return true;
        }
        private string GetHash(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hash);
        }
        private string DecipherPassword(SecureString password)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(password);
                return Marshal.PtrToStringUni(valuePtr);
            }
            catch (Exception) { }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
            return null;
        }
    }
}
