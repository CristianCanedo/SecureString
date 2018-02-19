using System;
using System.Diagnostics;
using System.ComponentModel;
using static System.Console;
using System.Security;

namespace SecureStringProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            SecureString pwd = new SecureString();
            SecureString pwd2 = new SecureString();
            ConsoleKeyInfo cki;
            try
            {
                Write("Enter a password: ");
                do
                {
                    cki = Console.ReadKey(true);
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
                } while (cki.Key != ConsoleKey.Enter);

                Write("\nRe-enter password: ");
                do{
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Backspace){
                        if (pwd2.Length == 0){
                            continue;
                        }
                        else if (pwd2.Length > 0){
                            pwd2.RemoveAt(pwd2.Length-1);
                            Console.Write("\b \b");
                            continue;
                        }
                    }
                    else{
                        pwd2.AppendChar(cki.KeyChar);
                        Write("*");
                    }
                } while (cki.Key != ConsoleKey.Enter);

                CheckPasswords(pwd, pwd2);
            }
            catch (Win32Exception e){
                WriteLine(e.Message);
            }
            catch (Exception e){
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

            if (s1.ToString() != s2.ToString()){
                WriteLine("\nPasswords do not match.");
            }
            else{
                WriteLine("\n Passwords match!");
            }
        }
    }
}
