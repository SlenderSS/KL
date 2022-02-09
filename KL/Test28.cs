using System;


namespace KL
{
    class Test28
    {
        public static string Test(string line)
        {         
            var torple = FindNums(line);
            switch (torple.Item1)
            {
                case "JK":
                    return ((torple.Item2 * 2 + torple.Item3)%15).ToString();
                case "D":
                    return ((torple.Item2 + torple.Item3)%15).ToString();
                case "T":
                    return ((torple.Item2 + torple.Item3)%15).ToString();
            }
            return "---";
        }
        static (string, int, int) FindNums(string line)
        {
            int endPosition = line.IndexOf(". Пам'ять автомата ");
            int startPosition = endPosition - 10;
            string _nums = line.Substring(startPosition, endPosition - startPosition);
            var arrNums = _nums.Split(", ");
            startPosition = line.IndexOf("побудована на ");
            endPosition = line.IndexOf("-тригерах");
            string _trigger = line.Substring(startPosition, endPosition - startPosition).Replace("побудована на ", "");
            var torple = (trigger: _trigger,
                state: Convert.ToInt32(Math.Ceiling(Math.Log2(Convert.ToInt32(arrNums[arrNums.Length - 3])))),
                outPuts: Convert.ToInt32(arrNums[arrNums.Length - 1]));
            return torple;
        }
    }
}
