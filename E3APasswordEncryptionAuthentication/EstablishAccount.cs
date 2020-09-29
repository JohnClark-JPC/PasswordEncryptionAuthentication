using System;
using System.Collections.Generic;
using System.Text;

namespace E3APasswordEncryptionAuthentication
{
    public class EstablishAccount
    {
        public Dictionary<string, string> Credentials = new Dictionary<string, string>();

        public EstablishAccount()
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            string hashedPassword = Encryptor.MD5Hash(password);

            // Check for pre existing duplicate user name

            if (!Credentials.ContainsKey(username))
            {
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
                Console.WriteLine("User name already taken. ");
                Console.ReadKey();
            }
        }
    }
}



