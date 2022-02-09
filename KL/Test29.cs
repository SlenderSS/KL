using System;

namespace KL
{
    class Test29
    {
        public static string Test(string line)
        {
            int endPosition = line.IndexOf(". Пам'ять");
            int startPosition = endPosition - 12;
            string nums = line.Substring(startPosition, endPosition - startPosition).Replace(" ", "");
            var arrNums = nums.Split(",");
            var turple = (Convert.ToInt32(arrNums[arrNums.Length - 3]),
                Convert.ToInt32(arrNums[arrNums.Length - 2]),
                Convert.ToInt32(arrNums[arrNums.Length - 1]));
            int result = Convert.ToInt32(Math.Ceiling(Math.Log2(turple.Item1))) + turple.Item2;
            var res2 = (int)Math.Pow(2, result) * turple.Item3;
            return (res2 % 15).ToString();
        }
    }
}
