using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_MarianaPerezSerna.Models
{
    public class Settings
    {
        public static void Header(string tittle)
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(TextCenter(tittle, 50));
            Console.WriteLine(new string('=', 50));
        }

        public static void Footer(string footer)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(TextCenter(footer, 50));
            Console.WriteLine(new string('-', 50));
        }

        public static void Separator()
        {
            Console.WriteLine(new string('-', 50));
        }

        private static string TextCenter(string text, int longitudTotal)
        {
            if (text.Length >= longitudTotal)
                return text;

            int spaceLeft = (longitudTotal - text.Length) / 2;
            int spaceRight = longitudTotal - text.Length - spaceLeft;

            return new string(' ', spaceLeft) + text + new string(' ', spaceRight);
        }
    }
}