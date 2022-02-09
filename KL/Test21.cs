using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test21
    {
        public static string Test(string line)
        {
            int endPosition = line.Length;
            int startPosition = line.IndexOf("дорівнює ");
            var str = line.Substring(startPosition, endPosition - startPosition).Replace("дорівнює ", "");
            int M = Convert.ToInt32(str);
            return Math.Ceiling(Math.Log2(M)).ToString();
        }
    }
}
