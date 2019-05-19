using System;

namespace TechChallenge.Models
{
    public class NumberToWord : INumberToWord
    {
        public InputNumber ConvertNumberToWord(string name, decimal number)
        {
            InputNumber num = new InputNumber();

            string decimals = "";
            string input = Math.Round(number, 2).ToString();

            if (input.Contains("."))
            {
                //get the decimal value
                decimals = input.Substring(input.IndexOf(".") + 1);
                //remove decimal part from input
                input = input.Remove(input.IndexOf("."));
            }

            // Convert input into words. save it into strWords
            string strWords = GetWords(input) + " Dollars";


            if (decimals.Length > 0)
            {
                // if there is any decimal part convert it to words and add it to strWords.
                strWords += " and " + GetWords(decimals) + " Cents";
            }

            num.Name = name;
            num.Word = strWords;

            return num;
        }

        /// <summary>
        /// Converts integer in to word
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetWords(string input)
        {
            //Seperators for each 3 digit in numbers.
            string[] seperators = { "", " Thousand ", " Million ", " Billion " };

            
            int counter = 0;

            string strWords = "";

            while (input.Length > 0)
            {
                // get the 3 last numbers from input and store it. if there is not 3 numbers just use take it.
                string threeDigits = input.Length < 3 ? input : input.Substring(input.Length - 3);
                // remove the 3 last digits from input. if there is not 3 numbers just remove it.
                input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

                int no = int.Parse(threeDigits);
                // Convert 3 digit number into words.
                threeDigits = GetWord(no);

                // apply the seperator.
                threeDigits += seperators[counter];
                // since we are getting numbers from right to left then we must append resault to strWords like this.
                strWords = threeDigits + strWords;

                // 3 digits converted. count and go for next 3 digits
                counter++;
            }
            return strWords;
        }
        
        private static string GetWord(int number)
        {
            string[] Ones =
            {
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
            "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"
            };

            string[] Tens = { "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };

            string word = string.Empty;

            if (number > 99 && number < 1000)
            {
                int i = number / 100;
                word = word + Ones[i - 1] + " Hundred ";
                number = number % 100;
            }

            if (number > 19 && number < 100)
            {
                int i = number / 10;
                word = word + Tens[i - 1] + " ";
                number = number % 10;
            }

            if (number > 0 && number < 20)
            {
                word = word + Ones[number - 1];
            }

            return word;
        }
    }
}