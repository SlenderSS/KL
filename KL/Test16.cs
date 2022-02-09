using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test16
    {
        public static string Test(string line)
        {
            int startPoint = line.IndexOf("функцію f(");
            int endPoint = line.IndexOf(")=");
            string func = line.Substring(startPoint, endPoint - startPoint).Replace("функцію f(", "");
            startPoint = line.IndexOf(")=");
            endPoint = line.IndexOf("?");
            string vars = line.Substring(startPoint, endPoint - startPoint).Replace(")=", "");
            var str = func.Split(",");
            int min = str.Length - vars.Length;
            if (min == 0)
                return "0";
            return Math.Pow(2, min).ToString();
        }
    }
}
