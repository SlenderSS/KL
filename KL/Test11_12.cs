using System;
using System.Linq;


namespace KL
{
    class Test11_12
    {
        public static string Test_12(string line)
        {
            int startPosition = line.IndexOf("аргументами є ");
            int endPosition = line.IndexOf(" молодших");
            var bytes = Convert.ToInt32(line.Substring(startPosition, endPosition - startPosition).Replace("аргументами є ", ""));
            //
            int lf = 0;
            endPosition = line.IndexOf(" якщо");
            startPosition = line.IndexOf("результат ");
            string logFunc = line.Substring(startPosition, endPosition - startPosition).Replace("обчислення логічної функції ", "");

            if (logFunc.Contains("ВИКЛЮЧНЕ АБО") || logFunc.Contains("XOR") || logFunc.Contains("СУМА ЗА МОДУЛЕМ 2"))
                lf = 0;
            else if (logFunc.Contains("NAND") || logFunc.Contains("І-НЕ"))
                lf = 1;
            else if (logFunc.Contains("AND") || logFunc.Contains("І") || logFunc.Contains("логічного множення") || logFunc.Contains("кон'юнкції"))
                lf = 2;
            else if (logFunc.Contains("NOR") || logFunc.Contains("АБО-НЕ"))
                lf = 3;
            else if (logFunc.Contains("диз'юнкції") || logFunc.Contains("логічного додавання") || logFunc.Contains("АБО") || logFunc.Contains("OR"))
                lf = 4;
            //
            endPosition = line.Length;
            startPosition = line.IndexOf("числа ");
            int num = Convert.ToInt32(line.Substring(startPosition, endPosition - startPosition).Replace("числа ", ""));
            //
            if (num == 0)
            {
                return "0";
            }
            else if (num == 1)
            {
                return "1";
            }
            return (Func12_2(lf, Convert.ToString(num, 2).ToCharArray(), bytes)).ToString();
        }
        static int Func12_2(int lf, char[] num, int bytes)
        {
            Array.Reverse(num);
            int min = 0;
            string number = "";
            if (bytes > num.Length)
            {
                min = bytes - num.Length;
                for (int i = 0; i < min; i++)
                {
                    number += "0";
                }
                for (int i = 0; i < num.Length; i++)
                {
                    number += num[i];
                }
            }
            else
            {
                for (int i = 0; i < bytes; i++)
                {
                    number += num[i];
                }
            }
            int countOne = number.Where(c => c == '1').Count();
            int countZero = number.Where(c => c == '0').Count();
            switch (lf)
            {
                case 0:
                    return countOne % 2;
                case 1:
                    if (countZero != 0)
                        return 1;
                    else
                        return 0;
                case 2:
                    if (countZero != 0)
                        return 0;
                    else
                        return 1;
                case 3:
                    if (countOne == 0)
                        return 1;
                    else
                        return 0;
                case 4:
                    if (countOne == 0)
                        return 0;
                    else
                        return 1;
            }
            return 0;
        }
    }
}
