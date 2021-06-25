using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostcodeParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("POSTCODE: ");
            string postcode = Console.ReadLine();

            postcode = postcode.ToUpper().Replace(" ", "");

            string inward = postcode.Substring(postcode.Length - 3, 3);
            string outward = postcode.Substring(0, postcode.Length - 3);

            StringBuilder outwardLetter = new StringBuilder();

            int pos = 0;
            foreach(char chr in outward.ToCharArray())
            {
                if ((int)chr > 64 && (int)chr < 91)
                {
                    outwardLetter.Append(chr);
                    pos++;
                }
                else
                    break;
            }

            string outwardNumber = outward.Substring(pos, outward.Length - pos);

            Console.WriteLine("\tOUTWARD CODE: " + outward);
            Console.WriteLine("\t\tOUTWARD LETTER: " + outwardLetter);
            Console.WriteLine("\t\tOUTWARD NUMBER: " + outwardNumber);
            Console.WriteLine("\tINWARD CODE: " + inward);

            Console.ReadLine();
        }
    }
}
