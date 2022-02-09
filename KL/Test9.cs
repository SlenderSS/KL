using System;

namespace KL
{
    class Test9
    {
        public static string Test(string line)
        {
            int endPosition = line.IndexOf(". У якому ");
            int startPosition = endPosition - 4;
            string binNum = Convert.ToString(Convert.ToInt32(line.Substring(startPosition,
                endPosition - startPosition),16),2);
            while(binNum.Length < 16)
            {
                binNum = "0" + binNum;
            }
            char[] _binNum = binNum.ToCharArray();
            return Func9(_binNum).ToString();
        }
        static int Func9(char[] num)
        {
            int k1, k2, k4, k8;
            int result = 0;
            k1 = (num[3] - '0') + (num[5] - '0') + (num[7] - '0') + (num[9] - '0') + (num[11] - '0') + (num[13] - '0') + (num[15] - '0');
            k2 = (num[3] - '0') + (num[6] - '0') + (num[7] - '0') + (num[10] - '0') + (num[11] - '0') + (num[14] - '0') + (num[15] - '0');
            k4 = (num[5] - '0') + (num[6] - '0') + (num[7] - '0') + (num[12] - '0') + (num[13] - '0') + (num[14] - '0') + (num[15] - '0');
            k8 = (num[9] - '0') + (num[10] - '0') + (num[11] - '0') + (num[12] - '0') + (num[13] - '0') + (num[14] - '0') + (num[15] - '0');
            k1 %= 2;
            k2 %= 2;
            k4 %= 2;
            k8 %= 2;
            if (k1 != (num[1] - '0'))
                result += 1;
            if (k2 != (num[2] - '0'))
                result += 2;
            if (k4 != (num[4] - '0'))
                result += 4;
            if (k8 != (num[8] - '0'))
                result += 8;
            return result;
        }

    }
}
