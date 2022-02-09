using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test25
    {
        public static string Test(string line)
        {
           var hex = Func25(line);
           return Generator(Convert.ToString(Convert.ToInt32(hex, 16), 2));
        }
        static string Func25(string line)
        {
            int endPosition = line.IndexOf(" Яким");
            int startPosition = endPosition - 3;
            var str = line.Substring(startPosition, endPosition - startPosition);
            return str;
        }

        static string Generator(string binNum)
        {
            var _binNum = binNum.ToCharArray();
            string binNum_ = "";
            for (int i = 12; i > 0; i--)
            {
                binNum_ += _binNum[i - 1];
            }
            _binNum = binNum_.ToCharArray();
            string[] result = new string[binNum.Length];
            string res = "";
            for (int i = 0; i < binNum.Length; i++)
            {
                if (i == 0)
                    result[i] = _binNum[11].ToString();
                else if (i == 3 || i == 4 || i == 7)
                {
                    result[i] = XOR(_binNum[11].ToString(), _binNum[i - 1].ToString());
                }
                else
                {
                    result[i] = _binNum[i - 1].ToString();
                }
            }
            for (int i = 12; i > 0; i--)
            {
                res += result[i - 1];
            }
            return (Convert.ToInt32(res,2) % 15).ToString();
        }
        static string XOR(string a, string b)
        {
            if (a == "1" && b == "1")
                return "0";
            else if (a == "1" && b == "0")
                return "1";
            else if (a == "0" && b == "1")
                return "1";
            else if (a == "0" && b == "0")
                return "0";
            return "";
        }
    }
}
