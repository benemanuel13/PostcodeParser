using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostcodeParser.Utilities;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class PostcodeTests
    {
        //This is the raw test data
        static string[] postcodes = new string[] { "M28 7JP", "wc2h7de", "CT21      4LR", "N33DP" };
        static string[] expectedPostcodes = new string[] { "M287JP", "WC2H7DE", "CT214LR", "N33DP" };
        static string[] expectedOutward = new string[] { "M28", "WC2H", "CT21", "N3" };
        static string[] expectedLetter = new string[] { "M", "WC", "CT", "N" };
        static string[] expectedNumber = new string[] { "28", "2H", "21", "3" };
        static string[] expectedInward = new string[] { "7JP", "7DE", "4LR", "3DP" };

        [DataTestMethod]
        [DynamicData("TestData")]
        public void TestMethod(string postcode, string expectedPostcode, string expectedOutward, string expectedLetter, string expectedNumber, string expectedInward)
        {
            var code = new Postcode();

            code.ParsePostcode(postcode, out string newPostcode, out string outward, out string outwardLetter, out string outwardNumber, out string inward);

            Assert.AreEqual(newPostcode, expectedPostcode);
            Assert.AreEqual(outward, expectedOutward);
            Assert.AreEqual(outwardNumber, expectedNumber);
            Assert.AreEqual(outwardLetter, expectedLetter);
            Assert.AreEqual(inward, expectedInward);
        }

        /// <summary>
        /// This is an abstraction of the raw test data
        /// </summary>
        public static IEnumerable<string[]> TestData
        {
            get {
                var objects = new List<string[]>();

                for (int i = 0; i < 4; i++)
                {
                    objects.Add(new string[6] { postcodes[i], expectedPostcodes[i], expectedOutward[i], expectedLetter[i], expectedNumber[i], expectedInward[i] });
                }

                return objects.ToArray();
            }
        }
    }
}
