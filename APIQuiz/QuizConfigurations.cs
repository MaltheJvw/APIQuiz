using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace APIQuiz
{
    internal class QuizConfigurations
    {
        ConsoleManager consoleManager = new ConsoleManager();
        public string GetDifficulty()
        {
            string[] menuItems = { "Easy", "Medium", "Hard" };
            int selectedIndex = 0;
            ConsoleKey key;

            Console.CursorVisible = false;


            Menu(menuItems, selectedIndex);

            do
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                }


                Menu(menuItems, selectedIndex);

            } while (key != ConsoleKey.Enter);

            string difficulty = menuItems[selectedIndex];

            Console.Write("Difficulty: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(difficulty);
            Console.ResetColor();

            return difficulty;
        }

        public string GetLimit()
        {
            int limit = 0;

            consoleManager.WriteLine("How many Questions: ", 2);

            limit = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(5, 0);
            consoleManager.WriteColoredLine("Questions: ", limit, "", ConsoleColor.Green, 0);
            Console.Write("Questions: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(limit);
            Console.ResetColor();

            return limit.ToString();
        }

        public string GetCategory()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("What language: ");

            string[] menuItems = { "Code", "Linux", "DevOps", "Networking", "SQL", "(f)Cloud", "Docker", "Kubernetes", "CMS" };
            int selectedIndex = 0;
            ConsoleKey key;

            Console.CursorVisible = false;


            Menu(menuItems, selectedIndex);

            do
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                }

                // Redraw the menu with the new selected index
                Menu(menuItems, selectedIndex);
            } while (key != ConsoleKey.Enter);
            Console.Clear();

            string category = menuItems[selectedIndex];

            consoleManager.ClearMenu();
            consoleManager.WriteColoredLine("Category: ", category, "", ConsoleColor.Green, 0);

            return category;
        }



        public void Menu(string[] menuItems, int selectedIndex)
        {
            Console.SetCursorPosition(4, 4);
            for (int i = 0; i < menuItems.Length; i++)
            {
                consoleManager.AddMenuLine(i);

                if (i == selectedIndex)
                {
                    consoleManager.WriteLine("-> " + menuItems[i], i);
                }
                else
                {
                    consoleManager.WriteLine("   " + menuItems[i], i);
                }
            }
        }
    }
}
