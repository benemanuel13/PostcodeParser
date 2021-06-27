using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostcodeParser.Utilities
{
    public class Postcode
    {
        public void ParsePostcode(string postcode, out string newPostcode, out string outward, out string letter, out string number, out string inward)
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
        }
    }
}
