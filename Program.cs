using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProjectTest2
{
    enum MainMenuOption
    {
        Option1 = 1,
        Option2,
        Option3,
        Option4,
        Option5,
    }

    enum LogInMenu
    {
        Option1 = 1,
        Option2,
    }

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

    internal class Program
    {
        private static List<User> users = new List<User>()
        {
            new User("user1", "password1"), //Hard coded user 1 and user 2
            new User("user2", "password2"),
        };
        private static User loggedInUser = null;

        static void Main(string[] args)
        {
            //User creation or log in Loop
            while (loggedInUser == null)
            {
                Console.Clear();
                Console.WriteLine("Welcome to ---- !");

                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Login");
                Console.WriteLine("Select an option: ");

                if (Enum.TryParse<LogInMenu>(Console.ReadLine(), out var selectedOption))
                {
                    switch (selectedOption)
                    {
                        case LogInMenu.Option1:
                            CreateUser();
                            break;
                        case LogInMenu.Option2:
                            Login();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 2.");
                }

                //Wait for user input before clearing screen
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
            }

            //Main menu Loop
            MainMenu();
        }

        static void CreateUser()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            //Check if user already exits
            if (users.Exists(u => u.Username == username))
            {
                Console.WriteLine("User already exists. Please choose a diffrent username.");
                return;
            }

            //Create and add new user
            users.Add(new User(username, password));
            Console.WriteLine("User created successfully!");
        }

        static void Login()
        {
            Console.Clear();
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            Console.Clear();

            //Check for valid credentials
            loggedInUser = users.Find(u => u.Username == username && u.Password == password);
            if (loggedInUser != null)
            {

                Console.WriteLine("Login succefull!");
                Console.WriteLine($"Welcome, {loggedInUser.Username}!");
            }
            else
            {
                Console.WriteLine("Login failed!");
                Console.WriteLine("Incorrect username or password.");
            }
        }
        static void MainMenu()
        {
            MainMenuOption selectedOption;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. View Schedule");
                Console.WriteLine("2. Add/Update Schedule");
                Console.WriteLine("3. Monitor Backup Power");
                Console.WriteLine("4. Generate Report");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                // Parse user input to MenuOption enum
                if (Enum.TryParse<MainMenuOption>(Console.ReadLine(), out selectedOption))
                {
                    switch (selectedOption)
                    {
                        case MainMenuOption.Option1:
                            
                            ViewSchedule scheduleView = new ViewSchedule();         //create instance of ViewSchedule()
                            scheduleView.DisplaySchedule();                         //Display schedule
                            Console.ReadKey();                                      //wait for user input before closing

                            break;
                        case MainMenuOption.Option2:
                            UpdateSchedule();
                            break;
                        case MainMenuOption.Option3:
                            MonitorBackup();
                            break;
                        case MainMenuOption.Option4:
                            GenerateReport();
                            break;
                        case MainMenuOption.Option5:
                            Exit();

                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }

                // Wait for user input before clearing the screen
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            } while (selectedOption != MainMenuOption.Option5);
        }

        ////create instance of ViewSchedule()
        //var scheduleView = new ViewSchedule();

        ////Display schedule
        //scheduleView.DisplaySchedule();

        ////wait for user input before closing
        //Console.ReadKey();

        //static void ViewSchedule()
        //{
        //    Console.Clear();
        //    Console.WriteLine("You selected Option 1: Display schedule!");
        //}

        static void UpdateSchedule()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 2: Update schedule!");
            // Add action code here
        }

        static void MonitorBackup()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 3: Monitor Backup Power!");
            // Add info display code here
        }

        static void GenerateReport()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 4: Generate Report!");
            // Add action code here
        }

        static void Exit()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 5: Exiting the application...");

        }
    }
}
