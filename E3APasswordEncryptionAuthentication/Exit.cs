using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace E3APasswordEncryptionAuthentication
{
    class Exit
    {
        public static void PrintData()
        {
            foreach (KeyValuePair<string, string> kvp in Menu.Credentials)
            {
                Console.WriteLine("List of all usernames and passwords used this session:\r\n");
                Console.WriteLine("\r\n Username: {0}\r\n Password: {1}", kvp.Key, kvp.Value);
            }
            Console.ReadKey();
        }
    }
}
