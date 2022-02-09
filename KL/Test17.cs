using System;


namespace KL
{
    class Test17
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
            if (line.Contains("необхідно завести 1"))
            {
                return Math.Pow(2, min).ToString();
            }
            else if (line.Contains("необхідно завести 0"))
            {
                return (Math.Pow(2, str.Length) - Math.Pow(2, min)).ToString();
            }
            return Math.Pow(2, min).ToString();
        }
    }
}
