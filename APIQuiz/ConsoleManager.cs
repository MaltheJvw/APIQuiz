using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIQuiz
{
    public class ConsoleManager
    {
        private Dictionary<int, string> lineContents;
        private int initialCursorTop;
        private List<int> menuLineNumbers;
        public ConsoleManager()
        {
            lineContents = new Dictionary<int, string>();
            initialCursorTop = Console.CursorTop;
            menuLineNumbers = new List<int>();
        }

        public void WriteLine(string text, int lineNumber)
        {
            lineContents[lineNumber] = text;
            WriteAt(text, lineNumber, Console.ForegroundColor);
        }
        public void WriteColoredLine(string prefix, string coloredText, string suffix, ConsoleColor color, int lineNumber)
        {
            string fullText = prefix + coloredText + suffix;
            lineContents[lineNumber] = fullText;

            int cursorTop = initialCursorTop + lineNumber;
            Console.SetCursorPosition(0, cursorTop);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(prefix);
            Console.ForegroundColor = color;
            Console.Write(coloredText);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(suffix.PadRight(Console.WindowWidth - fullText.Length));
        }

        private void WriteAt(string text, int lineNumber, ConsoleColor color, int offset = 0)
        {
            int cursorTop = initialCursorTop + lineNumber;
            Console.SetCursorPosition(offset, cursorTop);
            Console.ForegroundColor = color;
            Console.Write(text.PadRight(Console.WindowWidth - offset));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ClearLine(int lineNumber)
        {
            if (lineContents.ContainsKey(lineNumber))
            {
                int cursorTop = initialCursorTop + lineNumber;
                Console.SetCursorPosition(0, cursorTop);
                Console.WriteLine(new string(' ', Console.WindowWidth));
                lineContents.Remove(lineNumber);
            }
        }
        public void AddMenuLine(int lineNumber)
        {
            menuLineNumbers.Add(lineNumber);
        }

        public void ClearMenu()
        {
            foreach (var lineNumber in menuLineNumbers)
            {
                ClearLine(lineNumber);
            }
            menuLineNumbers.Clear();
        }
    }
}
