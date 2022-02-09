using System;


namespace KL
{
    class Test5
    {
        public static string Test(string line)
        {
            int startPosition = line.IndexOf("F=");
            int endPosition = line.IndexOf("Гц");
            string friquency = line.Substring(startPosition, endPosition - startPosition).Replace("F=", "");

            var frArr = friquency.Split(" ");
            int friquence = Convert.ToInt32(frArr[frArr.Length - 2]);
            double num = (frArr[frArr.Length - 1] == "к") ? Math.Pow(10, 9) : Math.Pow(10, 6);
            return (Convert.ToInt32(Math.Round(num / (2 * friquence), MidpointRounding.AwayFromZero)) % 15).ToString();
        }
    }
}
