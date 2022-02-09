using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test24
    {
        public static string Test(string line)
        {
            var tople = Func23(line);
            return (DTrigger(Convert.ToString(Convert.ToInt32(tople.Item1,16),2).ToCharArray(),
                Convert.ToString(Convert.ToInt32(tople.Item2, 16), 2).ToCharArray())).ToString();   
        }
        static (string, string) Func23(string line)
        {
            int startPosition = line.IndexOf("числом ");
            int endPosition = startPosition + 11;
            var D = line.Substring(startPosition, endPosition - startPosition).Replace("числом ", "");
            endPosition = line.IndexOf(". Як");
            startPosition = endPosition - 4;
            var CE = line.Substring(startPosition, endPosition - startPosition);
            return (D, CE);
        }
        static string DTrigger(char[] D, char[] CE)
        {
            string resArr = "";
            string arrD = "";
            for (int i = 11; i < D.Length; i++)
            {
                arrD += D[i];
            }
            foreach (var item in CE)
            {
                resArr += item;
            }
            return (Convert.ToInt32((arrD + resArr).Remove(16, 5))%15).ToString();
        }
    }
}
