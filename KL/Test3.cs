using System;


namespace KL
{
    class Test3
    {
        public static string Test(string line)
        {
			int abs = 0, mod_result = 0, temp, checker;
			var torple = FindNums(line);
			int M = torple.Item1;
			int N = torple.Item2;
			if (M < 0)
				abs = -M;
			else if (M >= 0)
				abs = M;
			if (N > 0 && M > 0)
			{
				mod_result = N % M;
			}
			else if (N > 0 && M < 0)
			{
				temp = M;
				checker = -1;
				while (N > temp)
				{
					temp = M * checker;
					checker -= 1;
				}
				int temp2 = temp;
				checker = 0;
				while (N != temp2)
				{
					temp2 = temp;
					temp2 -= checker;
					if (N == temp2)
						break;
					checker++;
				}
				mod_result = -checker;
			}
			else if (N < 0 && M > 0)
			{
				temp = M;
				checker = -1;
				while (N < temp)
				{
					temp = M * checker;
					checker -= 1;
				}
				int temp2 = temp;
				checker = 0;
				while (N != temp2)
				{
					temp2 = temp;
					temp2 += checker;
					if (N == temp2)
						break;
					checker++;
				}
				mod_result = checker;
			}
			else if (N < 0 && M < 0)
			{
				int temp3 = 0;
				temp = M;
				checker = 1;
				while (N < temp)
				{
					temp = M * checker;
					if (temp < N)
						break;
					temp3 = temp;
					checker += 1;
				}
				int temp2 = temp3;
				checker = 0;
				while (N != temp2)
				{
					temp2 = temp3;
					temp2 -= checker;
					if (N == temp2)
						break;
					checker++;
				}
				mod_result = -checker;
			}
			return (abs + mod_result).ToString();
		}
        public static (int, int) FindNums(string line)
        {
            int startPosition = line.IndexOf("M=");
            int endPosition = line.IndexOf(", а N=");
            int M = Convert.ToInt32(line.Substring(startPosition, endPosition - startPosition).Replace("M=", ""));
            startPosition = line.IndexOf("N=");
            endPosition = line.IndexOf("?");
            int N = Convert.ToInt32(line.Substring(startPosition, endPosition - startPosition).Replace("N=", ""));

            return (M, N);
        }
    }
}
