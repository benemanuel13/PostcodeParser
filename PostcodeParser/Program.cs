using PostcodeParser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostcodeParser
{
    class Program
    {
        /// <summary>
        /// This is a simple run of the parser using test data supplied.  Please run Unit Tests project for testing.
        /// Please see the Postcode class (under Utilities) for everything that this project contains.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var code = new Postcode();

            string[] postcodes = new string[] { "M28 7JP", "wc2h7de", "CT21      4LR", "N33DP" };
            
            foreach (string postcode in postcodes)
            {
                code.ParsePostcode(postcode, out string newPostcode, out string outward, out string outwardLetter, out string outwardNumber, out string inward);

                Console.WriteLine("#POSTCODE: " + newPostcode);
                Console.WriteLine("\tOUTWARD CODE: " + outward);
                Console.WriteLine("\t\tOUTWARD LETTER: " + outwardLetter);
                Console.WriteLine("\t\tOUTWARD NUMBER: " + outwardNumber);
                Console.WriteLine("\tINWARD CODE: " + inward);
            }

            Console.ReadLine();
        }
    }
}
