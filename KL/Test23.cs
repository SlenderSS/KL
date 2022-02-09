using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test23
    {
        public static string Test(string line)
        {
            var torple = Test_23_0(line);
            var d = torple.Item1;
            var ce = torple.Item2;
            var trigger = torple.Item3;
            return (DTrigger(Convert.ToString(Convert.ToInt32(d, 16), 2).ToCharArray(),
                Convert.ToString(Convert.ToInt32(ce, 16), 2).ToCharArray(), trigger)).ToString();            
        }
        static (string, string, int) Test_23_0(string line)
        {
            int startPosition = line.IndexOf("16-ковими числами ");
            int endPosition = startPosition + 22;
            var D = line.Substring(startPosition, endPosition - startPosition).Replace("16-ковими числами ", "");
            startPosition = endPosition;
            endPosition = startPosition + 8;
            var CE = line.Substring(startPosition, endPosition - startPosition).Replace(" та ", "");
            endPosition = line.IndexOf(". Як");
            startPosition = endPosition - 1;
            var state = Convert.ToInt32(line.Substring(startPosition, endPosition - startPosition));
            return (D, CE, state);
        }
        static string DTrigger(char[] D, char[] CE, int trigger)
        {
            string[] result = new string[16];
            string resArr = "";
            for (int i = 0; i < D.Length; i++)
            {
                if (D[i] == '1' && CE[i] == '0')
                {
                    if (i != 0)
                    {
                        if (result[i - 1] == "0")
                            result[i] = "0";
                        else
                            result[i] = "1";
                    }
                    else
                        result[i] = $"{trigger}";
                }
                else if (D[i] == '0' && CE[i] == '1')
                    result[i] = "0";
                else if (D[i] == '1' && CE[i] == '1')
                    result[i] = "1";
                else if (D[i] == '0' && CE[i] == '0')
                {
                    if (i == 0)
                        result[i] = $"{trigger}";
                    else
                        result[i] = result[i - 1];
                }
                resArr += result[i];
            }
            return (Convert.ToInt32(resArr, 2) % 15).ToString();
        }
      
    }
}
