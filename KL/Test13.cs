using System.Linq;
using System.Text.RegularExpressions;


namespace KL
{
    class Test13
    {
        public static string Test(string line)
        {        
            if (line.Contains("Буля"))
                return Func13Bull(Func13Params(line).Item1, Func13Params(line).Item2, line).ToString();
            else if (line.Contains("АБО, НЕ"))
                return Func13OrNot(Func13Params(line).Item1, Func13Params(line).Item2, line).ToString();
            else if (line.Contains("І, НЕ"))
                return Func13AndNot(Func13Params(line).Item1, Func13Params(line).Item2, line).ToString();
            return "---";
        }
        static int Func13AndNot(int countNormal, int countInverse, string line)
        {
            int input = line.Contains("кількість виходів") ? 0 : 1;
            int outPuts = 0;
            int inPuts = 0;
            switch (input)
            {
                case 0:
                    outPuts = 1 + countInverse;
                    return outPuts;
                case 1:
                    if (countInverse == 1 && countNormal == 0)
                        return 1;
                    inPuts = countNormal + countInverse * 2;
                    return inPuts;
            }
            return 0;
        }
        static int Func13OrNot(int countNormal, int countInverse, string line)
        {
            int input = line.Contains("кількість виходів") ? 0 : 1;
            int outPuts = 0;
            int inPuts = 0;
            switch (input)
            {
                case 0:
                    if (countNormal == 0 && countInverse > 1)
                        outPuts = 2;
                    else if (countInverse != 0 && countNormal != 0)
                        outPuts = countNormal + 2;
                    else if (countNormal == 0 && countInverse == 1)
                        outPuts = 1;
                    else if (countNormal == 1 && countInverse == 0)
                        outPuts = 0;
                    else if (countNormal > 1 && countInverse == 0)
                        outPuts = countNormal + 2;
                    return outPuts;
                case 1:
                    if (countNormal == 0 && countInverse == 1)
                        inPuts = 1;
                    else if (countNormal != 0 && countInverse != 0)
                        inPuts = (countNormal * 2) + countInverse + 1;
                    else if (countNormal != 0 && countInverse == 0)
                        inPuts = countNormal;
                    else if (countNormal == 0 && countInverse != 0)
                        inPuts = countInverse + 1;
                    return inPuts;
            }
            return 0;
        }
        static int Func13Bull(int countNormal, int countInverse, string line)
        {
            int input = line.Contains("кількість виходів") ? 0 : 1;

            switch (input)
            {
                case 0:
                    return 1 + countInverse;
                case 1:
                    int inverseInput = countInverse != 0 ? countInverse * 2 : 0; 
                    int normalInput = countNormal != 0 ? countNormal : 0; 
                    normalInput = normalInput < 0 ? normalInput * (-1) : normalInput;
                    return inverseInput + normalInput;
            }
            return 0;
        }
        static (int, int) Func13Params(string line)
        {
            int input = line.Contains("кількість входів") ? 1 : 0;
            int startPoint = line.IndexOf("ФАЛ f=");
            int endPoint = line.IndexOf(", якщо");
            string func = line.Substring(startPoint, endPoint - startPoint).Replace("ФАЛ f=", "");
            int countInverse = func.Count(c => c == '~');
            func = new Regex(@"\W").Replace(func, "");
            int countLetter = func.Length;
            int countNormal = countLetter - countInverse;
            return (countNormal, countInverse);
        }
    }
}
