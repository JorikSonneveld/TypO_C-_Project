using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Typo.Controller
{
    internal class LoginController
    {
        private readonly DatabaseController databaseController = new DatabaseController();

        public bool CheckCredentials(string Username, string Password)
        {
            var user = databaseController.CheckLogin(Username, Password);
            if (user != null)
            {
                Application.Current.Properties["ActiveUserID"] = user.ID;
                Application.Current.Properties["UserType"] = user.Type;
                return true;
            }
            return false;
        }

        public static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            Console.WriteLine(Convert.ToBase64String(hashBytes));
            return Convert.ToBase64String(hashBytes);
        }
    }
}