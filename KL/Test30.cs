using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL
{
    class Test30
    {
        public static string Test(string line)
        {
            if (line.Contains("Помножувач здійснює операцію "))
                return Test30_1(line);
            else if (line.Contains("Формат чисел з рухомою комою "))
                return Test30_2(line);
            return "---";
        }

        static string Test30_1(string line)
        {
			int startPoint = line.IndexOf(" M =");
			int endPoint = line.IndexOf(", N = ");
			string M = line.Substring(startPoint, endPoint - startPoint).Replace(" M =", "");
			M = Convert.ToString(Convert.ToInt32(M, 16), 2);
			while (M.Length < 10)
			{
				M = $"0{M}";
			}
			startPoint = line.IndexOf(", N = ");
			endPoint = line.IndexOf("? На початку S=0");
			string N = line.Substring(startPoint, endPoint - startPoint).Replace(", N = ", "");
			N = Convert.ToString(Convert.ToInt32(N, 16), 2);
			while (N.Length < 6)
			{
				N = $"0{N}";
			}
			int[] me = M.ToCharArray().Select(x => x - 48).ToArray();
			int[] mk = N.ToCharArray().Select(x => x - 48).ToArray();
			int[] S = new int[13];
			int[] Sr1 = new int[13];
			int[] Sr2 = new int[13];
			int[] Sr3 = new int[13];
			for (int i = 0; i < 4; i++)
			{
				for (int b = 0; b < 13; b++) // S = 00.000000000000
				{
					S[b] = 0;
				}
				if (mk[5] == 1)
				{
					for (int c = 0; c < 10; c++) // dodavanya za monulem 2
					{
						S[c] += me[c];
					}
				}
				if (i == 0)
				{
					for (int h = 0; h < 3; h++)
					{
						for (int p = 12; p > 1; --p)
						{
							S[p] = S[p - 1];
						}
					}
					for (int w = 0; w < 13; w++)
						Sr1[w] = S[w];
					for (int n = 5; n > 1; --n)
					{
						mk[n] = mk[n - 1];
					}
				}
				else if (i == 1)
				{
					for (int j = 0; j < 2; j++)
					{
						for (int q = 12; q > 1; --q)
						{
							S[q] = S[q - 1];
						}
					}
					for (int q = 0; q < 13; q++)
						Sr2[q] = S[q];
					for (int q = 5; q > 1; --q)
					{
						mk[q] = mk[q - 1];
					}
				}
				else if (i == 2)
				{
					for (int j = 0; j < 1; j++)
					{
						for (int q = 12; q > 1; --q)
						{
							S[q] = S[q - 1];
						}
					}
					for (int q = 0; q < 13; q++)
						Sr3[q] = S[q];
					for (int q = 5; q > 1; --q)
					{
						mk[q] = mk[q - 1];
					}
				}
				else if (i == 3)
				{
					for (int q = 0; q < 13; q++)
					{
						S[q] = Sr1[q] + Sr2[q] + Sr3[q];
					}
					for (int q = 12; q > -1; q--)
					{
						if (S[q] == 2 && q != 0)
						{
							S[q] = 0;
							S[q - 1] += 1;
						}
						else if (S[q] == 3 && q != 0)
						{
							S[q] = 1;
							S[q - 1] += 1;
						}
						else if (q == 0)
						{
							S[q] = S[q] % 2;
						}
					}
				}
			}
			return (Convert.ToInt32(string.Join("", S), 2) % 15).ToString();
		}

        static string Test30_2(string line)
        {


            return "";
        }
    }
}
