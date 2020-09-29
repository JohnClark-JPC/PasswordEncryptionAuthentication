using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace E3APasswordEncryptionAuthentication
{
    public class Menu
    {
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\r\n");
            Console.WriteLine("PASSWORD AUTHENTICATION SYSTEM\r\n");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Establish an account");
            Console.WriteLine("2. Authenticate a user");
            Console.WriteLine("3. Exit the system\r\n");
            Console.Write("Enter selection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EstablishAccount();
                    return true;
                case "2":
                    AuthenticateUser();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        public static Dictionary<string, string> Credentials = new Dictionary<string, string>();

        public static void EstablishAccount()
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            // Check for pre existing duplicate user name

            if (!Credentials.ContainsKey(username))
            {
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();
                string hashedPassword = Encryptor.MD5Hash(password);

                Credentials.Add(username, hashedPassword);

                Console.WriteLine($"\r\nYour username is: {username}");
                Console.WriteLine($"Your unencrypted password is: {password}");
                Console.Write("Your MD5 Hashed Password is: ");
                Console.WriteLine($"{hashedPassword}\r\n");
                Console.WriteLine("Press any key to return to menu.");
                Console.ReadKey();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("That user name is already taken. Press any key to return to menu.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }  

        public static void AuthenticateUser()
        {
            Console.WriteLine("AUTHENTICATE USER\r\n");
            Console.Write("Enter username to authenticate: ");
            string authUserName = Console.ReadLine();

            Console.WriteLine("Enter username's password: ");
            string authPassword = Console.ReadLine();
            string authHashedPassword = Encryptor.MD5Hash(authPassword);

            if (Credentials.ContainsKey(authUserName) && Credentials.ContainsValue(authHashedPassword))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User successfully authenticated.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Authentication failed.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }
    }
}
