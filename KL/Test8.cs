using System;
using System.Text.RegularExpressions;


namespace KL
{
    class Test8
    {
        public static string Test(string line)
        {
            if (line.Contains("кодова в"))
               return Test_8_1(line);
            else if (line.Contains("стити код Хемм"))
                return Test_8_2(line);
            else if (line.Contains("контрольний розряд при"))
                return Test_8_3(line);
            return "";
        }
        static string Test_8_1(string line)
        {
            int startPosition = line.Length - 3;
            int endPosition = line.Length;
            string Num2 = line.Substring(startPosition, endPosition - startPosition);
            while (Num2.Length < 8)
            {
                Num2 = "0" + Num2;
            }
            int distance = 0;
            startPosition = line.Length - 10;
            endPosition = line.Length - 7;
            string Num1 = line.Substring(startPosition, endPosition - startPosition);
            while(Num1.Length < 8)
            {
                Num1 = "0" + Num1;
            }
            string _binNum1 = Convert.ToString(Convert.ToInt32(Num1,16),2);
            while (_binNum1.Length < 8)
            {
                _binNum1 = "0" + _binNum1;
            }
            char[] binNum1 = _binNum1.ToCharArray();

            string _binNum2 = Convert.ToString(Convert.ToInt32(Num2, 16), 2);
            while (_binNum2.Length < 8)
            {
                _binNum2 = "0" + _binNum2;
            }
            char[] binNum2 = _binNum2.ToCharArray();
            for (int i = 0; i < binNum1.Length; i++)
            {
                if (binNum1[i] != binNum2[i])
                    distance++;
            }
            return distance.ToString();
        }
        static string Test_8_2(string line)
        {
            int startPosition = line.Length - 4;
            int endPosition = line.Length;
            string Num = line.Substring(startPosition, endPosition - startPosition);
            int num = Convert.ToInt32(new Regex(@"\D").Replace(Num, ""));
            int result = Convert.ToInt32(Math.Floor(Math.Log2(num) + 1));
            return result.ToString();
        }
        static string Test_8_3(string line)
        {
            int couple = 0;
            if (line.Contains("непарн"))
                couple = 1;
            int startPosition = line.Length - 3;
            int endPosition = line.Length - 1;
            string hexNum = line.Substring(startPosition, endPosition - startPosition);
            int count = 0;
            char[] arrBinNum = Convert.ToString(Convert.ToInt32(hexNum, 16), 2).ToCharArray();

            for (int i = 0; i < arrBinNum.Length; i++)
            {
                if (arrBinNum[i] == '1')
                    count++;
            }
            switch (couple)
            {
                case 0:
                    return (count % 2 == 0 ? 0 : 1).ToString();                  
                case 1:
                    return (count % 2 == 0 ? 1 : 0).ToString();       
            }
            return "----";
        }
    }
}
