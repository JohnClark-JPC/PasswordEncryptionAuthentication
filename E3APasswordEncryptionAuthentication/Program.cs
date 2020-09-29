using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.ComponentModel.Design;
using System.Collections.Generic;

namespace E3APasswordEncryptionAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool showMenu = true;
               
                while (showMenu)
                {
                    showMenu = Menu.MainMenu();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                Exit.PrintData();
            }
        }
    }
}
