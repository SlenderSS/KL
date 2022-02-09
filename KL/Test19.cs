using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace KL
{
    class Test19
    {
        public static string Test(string line)
        {
            if (line.Contains("зсуву"))
                return Test_19_1(line);
            else if (line.Contains("де M і N - дворозрядні двійкові числа, розряди яких m0, m1, n0, n1"))
                return Test_19_2(line);
            return "---";
        }
        static string Test_19_1(string line)
        {
            int start = 0;
            int end = 0;
            int number = 0;
            if (line.Contains("циклічного зсуву"))
            {
                end = line.Length;
                start = end - 3;
                number = Convert.ToInt32(line.Substring(start, end - start).Replace(" ", ""));
                char[] arrNum = Convert.ToString(number, 2).ToCharArray();
                string result = line.Contains("ліворуч")
                    ? $"{arrNum[1]}{arrNum[2]}{arrNum[3]}{arrNum[0]}"
                    : $"{arrNum[3]}{arrNum[0]}{arrNum[1]}{arrNum[2]}";
                return Convert.ToInt32(result).ToString();
            }
            start = line.IndexOf("дорівнює ");
            end = line.IndexOf(", якщо");
            number = Convert.ToInt32(line.Substring(start, end - start).Replace("дорівнює ", ""));
            string binNum = Convert.ToString(number, 2);
            if (binNum.Length < 4)
            {
                while (binNum.Length < 4)
                {
                    binNum = "0" + binNum;
                }
            }
            char[] arr = binNum.ToCharArray();
            if (line.Contains("логічного зсуву ліворуч") && line.Contains("подається 0")
                || line.Contains("арифметичного зсуву ліворуч") && line.Contains("подається 0"))
            {
                string result = $"{arr[1]}{arr[2]}{arr[3]}0";
                return Convert.ToInt32(result, 2).ToString();
            }
            else if (line.Contains("логічного зсуву ліворуч") && line.Contains("подається 1")
                || line.Contains("арифметичного зсуву ліворуч") && line.Contains("подається 1"))
            {
                string result = $"{arr[1]}{arr[2]}{arr[3]}1";
                return Convert.ToInt32(result, 2).ToString();
            }
            else if (line.Contains("логічного зсуву праворуч") && line.Contains("подається 0")
             || line.Contains("арифметичного зсуву праворуч") && line.Contains("подається 1"))
            {
                string result = $"0{arr[0]}{arr[1]}{arr[2]}";
                return Convert.ToInt32(result, 2).ToString();
            }
            else if (line.Contains("логічного зсуву праворуч") && line.Contains("подається 1")
             || line.Contains("арифметичного зсуву праворуч") && line.Contains("подається 0"))
            {
                string result = $"1{arr[0]}{arr[1]}{arr[2]}";
                return Convert.ToInt32(result, 2).ToString();
            }
            return "---";
        }
        static string Test_19_2(string line)
        {
            int startPoint = line.IndexOf("з десяткової адреси ");
            int endPoint = line.IndexOf(" ПЗП,");
            int adress = Convert.ToInt32(line.Substring(startPoint, endPoint - startPoint).Replace("з десяткової адреси ", ""));
            char[] adressArr = Convert.ToString(adress, 2).ToCharArray();
            Array.Reverse(adressArr);
            char m0 = adressArr[0];
            char m1 = adressArr[1];
            char n0 = adressArr[2];
            char n1 = adressArr[3];
            int M = Convert.ToInt32($"{m1}{m0}", 2);
            int N = Convert.ToInt32($"{n1}{n0}", 2);
            startPoint = line.IndexOf(" S = ");
            endPoint = line.IndexOf(", де M і N");
            string subStr = line.Substring(startPoint, endPoint - startPoint);
            var number = new Regex(@"\D").Replace(subStr, " ").Trim().Split("   ");
            int[] nums = number.Select(x => int.Parse(x)).ToArray();
            return $"{nums[0] * M + nums[1] * N}";
        }
    }
}
