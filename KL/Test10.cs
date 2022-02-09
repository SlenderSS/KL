using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace KL
{
    class Test10
    {
        public static string Test(string line)
        {
            int endPosition = line.IndexOf(")?");
            int startPosition = endPosition - 3;
            string gf = line.Substring(startPosition, endPosition - startPosition);
            int GF = Convert.ToInt32(new Regex(@"\D").Replace(gf, ""));
            endPosition = line.IndexOf(" у простому");
            startPosition = endPosition - 7;
            string subline = line.Substring(startPosition, endPosition - startPosition);
            string sline = new Regex(@"\D").Replace(subline, " ");
            int[] nums = sline.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
            int result = 0;
            if (subline.Contains("x"))
            {
                result = (nums[nums.Length - 2] * nums[nums.Length - 1]) % GF;
            }
            else if (subline.Contains("+"))
            {
                result = (nums[nums.Length - 2] + nums[nums.Length - 1]) % GF;
            }
            else if (subline.Contains(":"))
            {
                int i = 0; bool a = true;
                while (a)
                {
                    if (((i * nums[nums.Length - 1]) % GF) == 1)
                    {
                        break;
                    }
                    i++;
                }
                result = (nums[nums.Length - 2] * i) % GF;
            }
            else if (subline.Contains("-"))
            {
                int temp = GF;
                int checker = -1;
                if ((nums[nums.Length - 2] - nums[nums.Length - 1]) > 0)
                {
                    checker = (nums[nums.Length - 2] - nums[nums.Length - 1]) % GF;
                }
                if ((nums[nums.Length - 2] - nums[nums.Length - 1]) < 0)
                {
                    while ((nums[nums.Length - 2] - nums[nums.Length - 1]) < temp)
                    {
                        temp = GF * checker;
                        checker -= 1;
                    }
                    int temp2 = temp;
                    checker = -1;
                    while ((nums[nums.Length - 2] - nums[nums.Length - 1]) != temp2)
                    {
                        ++checker;
                        temp2 = temp;
                        temp2 += checker;
                    }
                }
                result = checker;

            }
            return result.ToString();
        }
    }
}
