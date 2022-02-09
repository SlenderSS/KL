using System;
using System.Collections.Generic;

namespace KL
{
    class Test26
    {
        public static string Test(string line)
        {
            var str = Func(line);
            string[] str2 = str.Split('x');
            return Func26(str2[str2.Length - 2], Convert.ToInt32(str2[str2.Length - 1]));
        }
        static string Func26(string str, int n)
        {
            int num = 0;
            int m1 = 0;
            foreach (var item in ToBit())
            {
                if (str.Contains(item.Key))
                {
                    m1 = item.Value;
                    num = Convert.ToInt32(str.Replace($"{item.Key}", ""));
                }
            }
            var m = (int)Math.Ceiling(Math.Log2(num * Math.Pow(2, m1)));
            return ((m + n + n) % 15).ToString();
        }

        static string Func(string line)
        {
            int endPosition = line.IndexOf("? Як");
            int startPosition = endPosition - 7;
            var str = line.Substring(startPosition, endPosition - startPosition);
            return str;
        }
        public static Dictionary<string, int> ToBit()
        {
            Dictionary<string, int> toBin = new Dictionary<string, int>();
            toBin.Add("K", 10);
            toBin.Add("M", 20);
            toBin.Add("G", 30);
            toBin.Add("T", 40);
            toBin.Add(" ", 0);
            return toBin;
        }
    }
}
