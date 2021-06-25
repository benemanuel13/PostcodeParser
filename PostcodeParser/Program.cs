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
            string[] postcodes = new string[] { "M28 7JP", "wc2h7de", "CT21      4LR", "N33DP" };
            string[] expectedPostcodes = new string[] { "M287JP", "WC2H7DE", "CT214LR", "N33DP" };
            string[] expectedOutward = new string[] { "M28", "WC2H", "CT21", "N3" };
            string[] expectedLetter = new string[] { "M", "WC", "CT", "N" };
            string[] expectedNumber = new string[] { "28", "2H", "21", "3" };
            string[] expectedInward = new string[] { "7JP", "7DE", "4LR", "3DP" };

            for (int i = 0; i < 4; i++)
            {
                bool passed = DoTest(postcodes[i], expectedPostcodes[i], expectedOutward[i], expectedLetter[i], expectedNumber[i], expectedInward[i]);

                if (passed)
                {
                    Console.WriteLine("PASSED TEST");
                }
                else
                {
                    Console.WriteLine("FAILED TEST");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static bool DoTest(string postcode, string expectedPostcode, string expectedOutward, string expectedLetter, string expectedNumber, string expectedInward)
        {
            ParsePostcode(postcode, out string newPostcode, out string outward, out string outwardLetter, out string outwardNumber, out string inward);

            if (newPostcode != expectedPostcode)
                return false;

            if (outward != expectedOutward)
                return false;

            if (outwardLetter.ToString() != expectedLetter)
                return false;

            if (outwardNumber != expectedNumber)
                return false;

            if (inward != expectedInward)
                return false;

            return true;
        }

        //This is fully self contained
        static void ParsePostcode(string postcode, out string newPostcode, out string outward, out string letter, out string number, out string inward)
        {
            newPostcode = postcode.ToUpper().Replace(" ", "");

            inward = newPostcode.Substring(newPostcode.Length - 3, 3);
            outward = newPostcode.Substring(0, newPostcode.Length - 3);

            StringBuilder outwardLetterBuilder = new StringBuilder();

            int pos = 0;
            foreach (char chr in outward.ToCharArray())
            {
                if ((int)chr > 64 && (int)chr < 91)
                {
                    outwardLetterBuilder.Append(chr);
                    pos++;
                }
                else
                    break;
            }

            letter = outwardLetterBuilder.ToString();
            number = outward.Substring(pos, outward.Length - pos);

            Console.WriteLine("#POSTCODE: " + postcode);
            Console.WriteLine("\tOUTWARD CODE: " + outward);
            Console.WriteLine("\t\tOUTWARD LETTER: " + letter);
            Console.WriteLine("\t\tOUTWARD NUMBER: " + number);
            Console.WriteLine("\tINWARD CODE: " + inward);
        }
    }
}
