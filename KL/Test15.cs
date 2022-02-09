using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test15
    {
        public static string Test(string line)
        {
            if (line.Contains("скороченої ДНФ функції"))
                return Func15_1(line);
            else if (line.Contains("логіки Поста"))
                return Func15_2(line);
            return "----";
        }

        static string Func15_1(string line)
        {
            int startPoint = line.IndexOf("функції ");
            int endPoint = line.IndexOf(" змінних");
            int numOfVar = Convert.ToInt32(line.Substring(startPoint, endPoint - startPoint).Replace("функції ", ""));
            startPoint = line.IndexOf("склеювання ");
            endPoint = line.IndexOf(" клітинок на карті");
            int cells = Convert.ToInt32(line.Substring(startPoint, endPoint - startPoint).Replace("склеювання ", ""));
            return (numOfVar - Math.Log2(cells)).ToString();
        }
        static string Func15_2(string line)
        {
            int startPoint = line.IndexOf("відповідно, ");
            int endPoint = line.Length;
            var nums = line.Substring(startPoint, endPoint - startPoint).Replace("відповідно, ", "");
            int[] arrNums = nums.Split(", ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
            int N = arrNums[arrNums.Length - 4];
            int a = arrNums[arrNums.Length - 3];
            int b = arrNums[arrNums.Length - 2];
            int c = arrNums[arrNums.Length - 1];
            int one = Math.Min(Math.Min(a + (1 % N), b), c);
            int two = Math.Min(Math.Min(b + (1 % N), a), c);
            int three = Math.Min(Math.Min(c + (1 % N), b), c);
            return (Math.Max(one, Math.Max(two, three))).ToString();
        }
    }
}
