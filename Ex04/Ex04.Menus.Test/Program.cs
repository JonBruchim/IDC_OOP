using System;
using System.Linq;

namespace Ex04.Menus.Test
{
    class MainClass
    {
        public class DelegatesTest
        {
            public const string k_Version = "21.3.4.8933";

            public static void Test()
            {
                Delegates.MainMenu mainMenu = new Delegates.MainMenu("Main Menu");
                DelegatesTest dateAndTime = new DelegatesTest();
                int showVersionAndDSpacesHash = mainMenu.AddNewMenuItemUnder(mainMenu.RootHashCode, "Version and Spaces");
                int showDateTimeHashCodeHash = mainMenu.AddNewMenuItemUnder(mainMenu.RootHashCode, "Show Date/Time");

                mainMenu.AddNewOperationItemUnder(showVersionAndDSpacesHash, "Count Spaces", dateAndTime.CountSpaces_Click);
                mainMenu.AddNewOperationItemUnder(showVersionAndDSpacesHash, "Show Version", dateAndTime.ShowVersion_Click);

                mainMenu.AddNewOperationItemUnder(showDateTimeHashCodeHash, "Show Date", dateAndTime.ShowDate_Click);
                mainMenu.AddNewOperationItemUnder(showDateTimeHashCodeHash, "Show Time", dateAndTime.ShowTime_Click);

                mainMenu.Show();
            }

            public void ShowDate_Click()
            {
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
                Console.ReadLine();
            }

            public void ShowTime_Click()
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm"));
                Console.ReadLine();
            }

            public void CountSpaces_Click()
            {
                Console.WriteLine("Enter a sentence (to count spaces):");
                string str = Console.ReadLine();
                Console.WriteLine(countSpaces(str));
                Console.ReadLine();
            }

            private int countSpaces(string i_Str)
            {
                return i_Str.Count(Char.IsWhiteSpace);
            }

            public void ShowVersion_Click()
            {
                Console.WriteLine("Version: " + k_Version);
                Console.ReadLine();
            }
        }

        public class InterfaceTest
        {
            public const string k_ShowTime = "Show Time";
            public const string k_ShowDate = "Show Date";

            public static void Test()
            {
                Console.WriteLine("Hello World!");
                Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Main Menu");
                InterfaceTest.Date date = new InterfaceTest.Date();
                InterfaceTest.Time time = new InterfaceTest.Time();
                InterfaceTest.Version version = new InterfaceTest.Version();
                InterfaceTest.CountDigits countDigits = new InterfaceTest.CountDigits();
                int showVersionAndDSpacesHash = mainMenu.AddNewMenuItemUnder(mainMenu.RootHashCode, "Version and Spaces");
                int showDateAndTimeHash = mainMenu.AddNewMenuItemUnder(mainMenu.RootHashCode, "Show Date/Time");

                mainMenu.AddNewOperationItemUnder(showVersionAndDSpacesHash, "Count Spaces", countDigits);
                mainMenu.AddNewOperationItemUnder(showVersionAndDSpacesHash, "Show Version", version);

                mainMenu.AddNewOperationItemUnder(showDateAndTimeHash, "Show Date", date);
                mainMenu.AddNewOperationItemUnder(showDateAndTimeHash, "Show Time", time);

                mainMenu.Show();
            }

            public class Date : IMenuItemClickListener
            {
                public void OnMenuItemClick()
                {
                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
                    Console.ReadLine();
                }
            }

            public class Time : IMenuItemClickListener
            {
                public void OnMenuItemClick()
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:mm"));
                    Console.ReadLine();
                }

            }

            public class Version : IMenuItemClickListener
            {
                public const string k_Version = "21.3.4.8933";

                public void OnMenuItemClick()
                {
                    Console.WriteLine("Version: " + k_Version);
                    Console.ReadLine();
                }
            }

            public class CountDigits : IMenuItemClickListener
            {
                public void OnMenuItemClick()
                {
                    Console.WriteLine("Enter a sentence (to count space):");
                    string str = Console.ReadLine();
                    Console.WriteLine(countSpaces(str));
                    Console.ReadLine();
                }

                private int countSpaces(string i_Str)
                {
                    return i_Str.Count(Char.IsWhiteSpace);
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("-------Starting Interface test-------");
            InterfaceTest.Test();
            Console.WriteLine("-------Ending Interface test-------");

            Console.WriteLine("-------Starting Delegate test-------");
            DelegatesTest.Test();
            Console.WriteLine("-------Ending Delegate test-------");
        }
    }
}
