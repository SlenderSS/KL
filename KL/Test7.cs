using System;


namespace KL
{
    class Test7
    {
        public static string Test(string line)
        {
            int startPosition = line.IndexOf("числа ");
            int endPosition = startPosition + 10;
            string data = line.Substring(startPosition, endPosition - startPosition).Replace("числа ", "");
            if (data.Contains("Г"))
            {
                return ((int)Math.Ceiling(Math.Log2(Convert.ToInt32(data.Replace("Г", "")) * Math.Pow(2, 30)))%15).ToString();
            }
            else if (data.Contains("К"))
            {
                return ((int)Math.Ceiling(Math.Log2(Convert.ToInt32(data.Replace("К", "")) * Math.Pow(2, 10)))%15).ToString();
            }
            else if (data.Contains("М"))
            {
                return ((int)Math.Ceiling(Math.Log2(Convert.ToInt32(data.Replace("М", "")) * Math.Pow(2, 20)))%15).ToString();
            }
            return ((int)Math.Ceiling(Math.Log2(Convert.ToInt32(data.Replace(" ", ""))))%15).ToString();
        }
    }
}
