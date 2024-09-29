using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static string Hash(string pasword)
        {
            using (SHA256 sha256 = SHA256.Create())
        {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pasword));
                return Convert.ToBase64String(bytes);
        }
        }

        static void Pause()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            Console.SetCursorPosition(0, height -1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter your key.....");
            Console.ResetColor();
            Console.ReadKey();
        }
        static void SingUp()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your fullname:");
            Console.ResetColor();
            string fullname = Console.ReadLine();
            string cod = "";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your National cod:");
                Console.ResetColor();
                 cod = Console.ReadLine();
               
                if(cod.Length == 10)
                {
                    break;
                    Pause();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not National cod !!");
                    Pause();
                    Console.Clear();
                }
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your email:");
            Console.ResetColor();
            string email = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your user name:");
            Console.ResetColor();
            string username = Console.ReadLine();
            string password = "";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your password:");
                Console.ResetColor();
                password = Console.ReadLine();
                if(password.Length >= 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Password Done");
                    Console.ResetColor();
                    break;
                    Pause();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not Password!!");
                    Pause();
                    Console.Clear();
                }
            }
            Console.Clear();
            users.Add(new User { Email = email ,  Cod = cod ,FullName = fullname, Username = username, Password = Hash(password)});
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SingUp Done, Welcome {username}");
            Console.ResetColor();
            Pause();
            
        }
        static void Login()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your user name:");
            Console.ResetColor();
            string username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your password:");
            Console.ResetColor();
            string password = Console.ReadLine();
            foreach (var user  in users)
            {
                if (user.Username == username && user.Password == Hash(password))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("login done, welcome");
                    Console.ResetColor();
                    Pause();
                    profail(user);
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid username or password.");
            Console.ResetColor();
            Pause();
        }
        static void profail(User user)
        {
            while(true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Welcom to your profaile, {user.FullName}!");
                Console.WriteLine($"Your cod irani is: {user.Cod}");
                Console.WriteLine($"Your username is: {user.Username}");
                Console.WriteLine($"Your password is: {new string('*',user.Password.Length)}");
                Console.WriteLine($"Your email is: {user.Email}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("1.Log out:");
                Console.WriteLine("2.Edit fullname:");
                Console.WriteLine("3.View password:");
                Console.Write("Enter your option:");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    return;
                }
                else if (option == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Enter your new fullname:");
                    string newname = Console.ReadLine();
                    user.FullName = newname;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Name your done");
                    Console.ResetColor();
                    Pause();
                }
                else if (option == "3")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Your password is:{user.Password}");
                    Console.ResetColor();
                    Pause();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invlid option.");
                    Console.ResetColor();
                    Pause();
                }
            }
        }
        static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Sing Up");
                Console.WriteLine("Login");
                Console.WriteLine("Exit");
                Console.Write("Enter your option:");
                string start = Console.ReadLine();
                switch (start.ToLower())
                {
                    case "sing up":
                        SingUp();
                        
                        break;
                    case "login":
                        Login();

                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid satrt.Please try aganr!!");
                        Pause();
                        break;
                }
            }
        }
    }
}
class User
{
    public string Email { get; set; }
    public string Cod {  get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
