using System;
using System.Linq;


namespace KL
{
    class Test2
    {
        public static string Test(string line)
        {
            var text = FindNums(line);
            return ToDecimal(text.Item1, text.Item2);
        }
        public static string ToDecimal(string num, int notation)
        {
            double sum = 0;
            var numArray = num.Select(i => (int)i - 48).ToArray();
            Array.Reverse(numArray);
            for (int i = numArray.Length; i > 0; i--)
            {
                var pow = Math.Pow(notation, i - 1);

                sum += numArray[i - 1] * pow;
            }
            return ((int)sum % 15).ToString();
        }
        public static (string, int) FindNums(string line)
        {
            int startPosition = line.IndexOf("числа ");
            int endPosition = line.IndexOf(" до 10-кової");
            string doubleNum = line.Substring(startPosition, endPosition - startPosition).Replace("числа ", "");
            startPosition = line.IndexOf("з основою");
            endPosition = line.IndexOf(" числа");
            int notation = Convert.ToInt32(line.Substring(startPosition, endPosition - startPosition).Replace("з основою ", ""));
            var arr = doubleNum.Split(",");
            return (arr[arr.Length - 2], notation);
        }
    }
}
