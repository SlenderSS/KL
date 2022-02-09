using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test20
    {
        public static string Test(string line)
        {
            int endPosition = line.Length - 1;
            int startPosition = endPosition - 12;
            var hexNums = line.Substring(startPosition, endPosition - startPosition).Replace(" та ", " ");
            string[] nums = hexNums.Split(" ");
            string binNum1 = Convert.ToString(Convert.ToInt32(nums[nums.Length - 2], 16), 2);
            string binNum2 = Convert.ToString(Convert.ToInt32(nums[nums.Length - 1], 16), 2);
            int count = 0;
            if (line.Contains(" рівних 0 двійкових переносів сформують повні однорозрядні двійкові суматори"))
            {
                char[] binArr1 = binNum1.ToCharArray();
                char[] binArr2 = binNum2.ToCharArray();
                for (int i = 0; i < binArr1.Length; i++)
                {
                    if (binArr1[i] == '1' && binArr2[i] == '1' ||
                        binArr1[i] == '0' && binArr2[i] == '1' ||
                        binArr1[i] == '1' && binArr2[i] == '0')
                        count++;
                }
            }
            else if (line.Contains("Скільки рівних 1 двійкових переносів сформує 16-бітний вузол прискорення переносів"))
            {
                char[] binArr1 = binNum1.ToCharArray();
                char[] binArr2 = binNum2.ToCharArray();
                Array.Reverse(binArr1);
                Array.Reverse(binArr2); ;
                char[] binRess = new char[17];
                for (int i = 0; i < binArr1.Length; i++)
                {
                    if (binArr1[i] == '1' && binArr2[i] == '1')
                    {
                        count++;
                        binRess[i] = '1';
                    }
                    else
                        binRess[i] = '0';
                    if (i != 0 &&
                        (binArr1[i] == '0' && binArr2[i] == '1' ||
                        binArr1[i] == '1' && binArr2[i] == '0') && binRess[i - 1] == '1')
                    {
                        count++;
                        binRess[i] = '1';
                    }
                }
            }
            else if (line.Contains("рівних 0"))
            {
                char[] binArr1 = binNum1.ToCharArray();
                char[] binArr2 = binNum2.ToCharArray();
                Array.Reverse(binArr1);
                Array.Reverse(binArr2);
                int decNum1 = Convert.ToInt32(binNum1, 2);
                int decNum2 = Convert.ToInt32(binNum2, 2);
                int decResult = decNum1 + decNum2;
                string binRes = Convert.ToString(decResult, 2);
                char[] binResArr = binRes.ToCharArray();
                count = binRes.Count(c => c == '0');
                for (int i = 0; i < binArr1.Length; i++)
                {
                    if (i == 0)
                    {
                        if (binArr1[0] == '0' && binArr2[0] == '0')
                            count--;
                    }
                    else if ((binArr1[i - 1] == '0' && binArr2[i - 1] == '0') && (binArr1[i] == '0' && binArr2[i] == '0') && binResArr[i - 1] == '0')
                        count--;
                }
            }
            else if (line.Contains("рівних 1 ознак G"))
            {
                char[] binArr1 = binNum1.ToCharArray();
                char[] binArr2 = binNum2.ToCharArray();
                for (int i = 0; i < binArr1.Length; i++)
                {
                    if (binArr1[i] == '1' && binArr2[i] == '1')
                        count++;
                }
            }
            else if (line.Contains("рівних 1 ознак P"))
            {
                char[] binArr1 = binNum1.ToCharArray();
                char[] binArr2 = binNum2.ToCharArray();
                for (int i = 0; i < binArr1.Length; i++)
                {
                    if (binArr1[i] == '1' && binArr2[i] == '1' ||
                        binArr1[i] == '0' && binArr2[i] == '1' ||
                        binArr1[i] == '1' && binArr2[i] == '0')
                        count++;
                }
            }
            else if (line.Contains(" рівних 1 двійкових "))
            {
                int decNum1 = Convert.ToInt32(binNum1, 2);
                int decNum2 = Convert.ToInt32(binNum2, 2);
                int decResult = decNum1 + decNum2;
                string binRes = Convert.ToString(decResult, 2);
                count = binRes.Count(c => c == '1');
            }
            else if (line.Contains("Скільки рівних 0 двійкових переносів сформує 16-бітний вузол прискорення переносів"))
            {
                int decNum1 = Convert.ToInt32(binNum1, 2);
                int decNum2 = Convert.ToInt32(binNum2, 2);
                int decResult = decNum1 + decNum2;
                string binRes = Convert.ToString(decResult, 2);
                count = binRes.Count(c => c == '0');
            }
            return Convert.ToString(count, 16);
        }
    }
}
