using System;
using System.ComponentModel;
using static System.Console;
using System.Security;

namespace SecureStringProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating two secure strings in order to 
            // compare typed in passwords
            SecureString pwd = new SecureString();
            SecureString pwd2 = new SecureString();
            ConsoleKeyInfo cki;
            try
            {
                // Ask user for password entry
                Write("Enter a password: ");
                while(true)
                {
                    cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Enter){       // If user hits enter, jump out of the loop
                        break;
                    }

                    if (cki.Key == ConsoleKey.Backspace){
                        if (pwd.Length == 0){               // If user hits backspace while there is no entry, do nothing
                            continue;
                        }
                        else if (pwd.Length > 0){           // If user hits backspace, overwrite console output
                            pwd.RemoveAt(pwd.Length-1);     // and remove from SecureString
                            Console.Write("\b \b");
                            continue;
                        }
                    }
                    else{
                        pwd.AppendChar(cki.KeyChar);        // Add user input to SecureString
                        Write("*");
                    }
                }

                // Ask user to confirm password entry
                Write("\nRe-enter password: ");
                while(true)
                {
                    cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Enter){
                        break;
                    }

                    if (cki.Key == ConsoleKey.Backspace){
                        if (pwd.Length == 0){
                            continue;
                        }
                        else if (pwd.Length > 0){
                            pwd.RemoveAt(pwd.Length-1);
                            Console.Write("\b \b");
                            continue;
                        }
                    }
                    else{
                        pwd.AppendChar(cki.KeyChar);
                        Write("*");
                    }
                }

                CheckPasswords(pwd, pwd2);                  // Compare both SecureStrings
            }
            catch (Win32Exception e){
                WriteLine(e.Message);
            }
            finally{
                pwd.Dispose();
                pwd2.Dispose();
            }
        }

        static void CheckPasswords(SecureString s1, SecureString s2){
            if (s1.Length < 0 || s2.Length < 0){
                WriteLine("\nPasswords must be longer than 6 characters.");
            }

            if (s1.ToString() != s2.ToString()){            // Convert ToString temporarily to compare
                WriteLine("\nPasswords do not match.");
            }
            else{
                WriteLine("\n Passwords match!");
            }
        }
    }
}
