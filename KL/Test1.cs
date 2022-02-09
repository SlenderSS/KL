using System;
using System.Linq;

namespace KL
{
    class Test1
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
            for (int i = 0; i < numArray.Length; i++)
            {
                sum += numArray[i] * Math.Pow(notation, -(i + 1));
            }
            if (sum == 0)
            {
                return "0";
            }
            string suma = sum.ToString();
            var result = suma.Split(",");
            var totalRes = result[1].ToCharArray();
            return totalRes[1].ToString();
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
            return (arr[arr.Length - 1], notation);
        }
    }
}
