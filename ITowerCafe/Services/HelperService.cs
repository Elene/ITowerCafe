using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITowerCafe.Services
{
    class CardChecker
    {
        //https://stackoverflow.com/questions/21249670/implementing-luhn-algorithm-using-c-sharp
        //Not My Own Implementation
        public static bool Luhn(string digits)
        {
            return digits.All(char.IsDigit) && digits.Reverse()
                .Select(c => c - 48)
                .Select((thisNum, i) => i % 2 == 0
                    ? thisNum
                    : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
                ).Sum() % 10 == 0;
        }
    }
    class NumberHelper
    {
        public static Dictionary<int, string> values = new Dictionary<int, string> { {0, "nuli" }, { 1, "erti" }, { 2, "ori" }, { 3, "sami" }, { 4, "otkhi" },
            { 5, "khuti"}, { 6, "ekvsi" }, { 7, "shvidi" }, { 8, "rva" }, { 9, "tskhra" }, { 10, "ati" }, { 11, "tertmenti" }, { 12, "tormenti"},
            { 13, "tsameti" }, { 14, "totkhmeti" }, { 15, "tkhutmeti" }, { 16, "tekvsmeti" }, { 17, "chvidmeti"}, { 18, "tvrameti"}, { 19, "tskhrameti"},
            { 20, "otsi" }, {40, "ormotsi" }, { 60, "samotsi"}, {80, "otkhmotsi" }, {100, "asi" }, {1000, "atasi" }, {1000000, "milioni" },
            {1000000000, "miliardi" } };

        private NumberHelper()
        {

        }

        //Finds prefix for numbers > 100 and < 1000
        private static string FindCentPrefix(int value)
        {
            string result = "";

            string firstToStr = values[value / 100];
            if (value / 100 > 1)
                result += firstToStr[firstToStr.Length - 1] == 'a' ? firstToStr : CutLastCharacter(firstToStr);

            return result;
        }

        //Removes last character from string
        private static string CutLastCharacter(string value)
        {
            return value.Substring(0, value.Length - 1);
        }

        //Finds max thousands in number (Ex: hundreds, thounds, million, billion)
        private static int FindMaxRank(int number)
        {
            if (number >= 100 && number < 1000)
                return 100;

            int result = 1;
            while (number >= 1000)
            {
                result *= 1000;
                number /= 1000;
            }

            return result;
        }

        //Converts number's numeric value into text
        public static string NumberToText(int number)
        {
            if (number == 0)
                return values[number];

            return NumberToTextHelper(number);
        }

        //Recursive function for converting numberic values into text
        private static string NumberToTextHelper(int number)
        {
            if (number < 0)
                return "minus " + NumberToTextHelper(number * (-1));

            if (number == 0)
                return "";

            if (values.ContainsKey(number))
                return values[number];

            if (number > 20 && number < 100)
                return CutLastCharacter(values[number / 20 * 20]) + "da" + NumberToTextHelper(number % 20);

            int maxRank = FindMaxRank(number);

            string prefix = number < 1000 ? FindCentPrefix(number) : (number / maxRank == 1) ? "" : NumberToTextHelper(number / maxRank) + " ";
            prefix += (number % maxRank == 0) ? values[maxRank] : CutLastCharacter(values[maxRank]);

            string ending = NumberToTextHelper(number - number / maxRank * maxRank);

            return ending == "" ? prefix : prefix + " " + ending;
        }
    }
}