using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test18
    {
        public static string Test(string line)
        {
            return line.Contains("на скільки") ? Func18_2(line) : Func18_1(line);
        }
        static string Func18_1(string line)
        {
            int endPosition = line.IndexOf(" розрядів");
            int startPosition = line.IndexOf("сл. х ");
            return line.Substring(startPosition, endPosition - startPosition).Replace("сл. х ", "");
        }
        static string Func18_2(string line)
        {
            int endPosition = line.Length;
            int startPosition = endPosition - 1;
            return line.Substring(startPosition, endPosition - startPosition);
        }
    }
}
