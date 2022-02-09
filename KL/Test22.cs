using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test22
    {
        public static string Test(string line)
        {
            var torple = FindNums(line);
            var reset = torple.Item1;
            var set = torple.Item2;
            var trigger = torple.Item4;
            reset = Convert.ToString(Convert.ToInt32(reset,16),2);
            set = Convert.ToString(Convert.ToInt32(set, 16), 2);
            var key = torple.Item3;
            switch (key)
            {
                case "1":
                    return RStrigger(reset.ToCharArray(), set.ToCharArray(), trigger);
                case "2":
                    return RStriggerInverse(reset.ToCharArray(), set.ToCharArray(), trigger);
                case "3":
                    return NotRNotStrigger(reset.ToCharArray(), set.ToCharArray(), trigger);
            }
            return "---";   
        }
        static (string, string, string, int) FindNums(string line)
        {
            string key = string.Empty;
            if (line.Contains("неRнеS"))
                key = "3";
            else if (!line.Contains("прямого виходу"))
                key = "2";
            else
                key = "1";
            int startPosition = line.IndexOf("16-ковими числами ");
            int endPosition = startPosition + 22;
            var R = line.Substring(startPosition, endPosition - startPosition).Replace("16-ковими числами ", "");
            startPosition = endPosition;
            endPosition = startPosition + 8;
            var S = line.Substring(startPosition, endPosition - startPosition).Replace(" та ", "");
            endPosition = line.IndexOf(". Як");
            startPosition = endPosition - 1;
            var state = Convert.ToInt32(line.Substring(startPosition, endPosition - startPosition));
            return (R, S, key, state);
        }

        static string RStriggerInverse(char[] R, char[] S, int trigger)
        {
            if (trigger == 1)
                trigger = 0;
            else
                trigger = 1;
            string[] result = new string[16];
            string resArr = "";
            for (int i = 0; i < R.Length; i++)
            {
                if (R[i] == '1' && S[i] == '0')
                    result[i] = "1";
                else if (R[i] == '0' && S[i] == '1')
                    result[i] = "0";
                else if (R[i] == '1' && S[i] == '1')
                    result[i] = "0";
                else if (R[i] == '0' && S[i] == '0')
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
        static string RStrigger(char[] R, char[] S, int trigger)
        {
            string[] result = new string[16];
            string resArr = "";
            for (int i = 0; i < R.Length; i++)
            {
                if (R[i] == '1' && S[i] == '0')
                    result[i] = "0";
                else if (R[i] == '0' && S[i] == '1')
                    result[i] = "1";
                else if (R[i] == '1' && S[i] == '1')
                    result[i] = "0";
                else if (R[i] == '0' && S[i] == '0')
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
        static string NotRNotStrigger(char[] R, char[] S, int trigger)
        {
            string[] result = new string[16];
            string resArr = "";
            for (int i = 0; i < R.Length; i++)
            {
                if (R[i] == '1' && S[i] == '0')
                    result[i] = "1";
                else if (R[i] == '0' && S[i] == '1')
                    result[i] = "0";
                else if (R[i] == '0' && S[i] == '0')
                    result[i] = "1";
                else if (R[i] == '1' && S[i] == '1')
                {
                    if (i == 0)
                        result[i] = trigger.ToString();
                    else
                        result[i] = result[i - 1];
                }
                resArr += result[i];
            }
            return (Convert.ToInt32(resArr,2)%15).ToString();
        }
    }
}
