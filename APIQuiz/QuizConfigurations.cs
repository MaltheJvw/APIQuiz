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

        public string GetDifficulty()
        {
            string[] menuItems = { "Easy", "Medium", "Hard" };
            int selectedIndex = 0;
            ConsoleKey key;

            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 0);
            Console.Write("Difficulty: ");

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
            Console.Clear();
            return difficulty;
        }

        public string GetLimit()
        {
            string[] menuItems = { "5", "10", "15", "20", "25", "30" };
            int selectedIndex = 0;
            ConsoleKey key;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Number of questions:");

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

            string limit = menuItems[selectedIndex];

            Console.Clear();

            return limit;
        }

        public string GetCategory()
        {
            string[] menuItems = { "Code", "Linux", "DevOps", "Networking", "SQL", "(f)Cloud", "Docker", "Kubernetes", "CMS" };
            int selectedIndex = 0;
            ConsoleKey key;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write("Category: ");

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

            Console.Clear();
            return category;
        }



        public void Menu(string[] menuItems, int selectedIndex)
        {


            Console.SetCursorPosition(0,1);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.WriteLine(menuItems[i]);
            }
        }
    }
}