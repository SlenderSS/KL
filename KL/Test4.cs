using System;
using System.Linq;


namespace KL
{
    class Test4
    {
        public static string Test(string line)
        {
            var text = FindNums(line);
            int a = text.Item1[0];
            int b = text.Item1[1];
            int c = text.Item1[2];
            return Func((a * 3.14) / 180, (b * 3.14) / 180, (c * 3.14) / 180, text.Item2);
        }
        static string Func(double a1, double b1, double c1, int result)
        {
            double Vidpovid = 0;
            switch (result)
            {
                case 0:
                    Vidpovid = Math.Cos(a1) * Math.Cos(a1) * Math.Cos(b1) * Math.Cos(b1) * Math.Cos(c1) * Math.Cos(c1) * 16;
                    break;
                case 1:
                    Vidpovid = Math.Cos(a1) * Math.Cos(a1) * Math.Cos(b1) * Math.Cos(b1) * Math.Sin(c1) * Math.Sin(c1) * 16;
                    break;
                case 2:
                    Vidpovid = Math.Cos(a1) * Math.Cos(a1) * Math.Sin(b1) * Math.Sin(b1) * Math.Cos(c1) * Math.Cos(c1) * 16;
                    break;
                case 3:
                    Vidpovid = Math.Cos(a1) * Math.Cos(a1) * Math.Sin(b1) * Math.Sin(b1) * Math.Sin(c1) * Math.Sin(c1) * 16;
                    break;
                case 4:
                    Vidpovid = Math.Sin(a1) * Math.Sin(a1) * Math.Cos(b1) * Math.Cos(b1) * Math.Cos(c1) * Math.Cos(c1) * 16;
                    break;
                case 5:
                    Vidpovid = Math.Sin(a1) * Math.Sin(a1) * Math.Cos(b1) * Math.Cos(b1) * Math.Sin(c1) * Math.Sin(c1) * 16;
                    break;
                case 6:
                    Vidpovid = Math.Sin(a1) * Math.Sin(a1) * Math.Sin(b1) * Math.Sin(b1) * Math.Cos(c1) * Math.Cos(c1) * 16;
                    break;
                case 7:
                    Vidpovid = Math.Sin(a1) * Math.Sin(a1) * Math.Sin(b1) * Math.Sin(b1) * Math.Sin(c1) * Math.Sin(c1) * 16;
                    break;
            }
            return (Math.Round(Vidpovid, MidpointRounding.AwayFromZero)).ToString();
        }

        public static (int[], int) FindNums(string line)
        {
            int startPosition = line.IndexOf("результат ");
            int endPosition = line.IndexOf(" в сер");
            int result = Convert.ToInt32(line.Substring(startPosition,
                endPosition - startPosition).Replace("результат ", ""));
            endPosition = line.IndexOf(" градус");
            startPosition = endPosition - 10;
            string nums = line.Substring(startPosition,
                endPosition - startPosition).Replace("з основою ", "");
            int[] numArr = nums.Split(", ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
            return (numArr, result);
        }
    }
}
