using System;


namespace KL
{
    class Test6
    {

        public static string Test(string line)
        {
            int startPosition = line.IndexOf("кодування ");
            int endPosition = line.IndexOf(" кольору?");
            string number = line.Substring(startPosition, endPosition - startPosition).Replace("кодування ", "");
            var num = number.Split(" ");
            return Math.Ceiling(Math.Log2(Convert.ToInt32(num[num.Length - 3]))).ToString();
        }
    }
}
