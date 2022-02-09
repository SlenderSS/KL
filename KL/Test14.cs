using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KL
{
    class Test14
    {
        public static string Test(string line)
        {
            int result = 0;
            var tople = Func13Params(line);
            if (line.Contains("Буля"))
                result = Func14BullCMOS(tople.Item1, tople.Item2, line);
            else if (line.Contains("АБО, НЕ") && line.Contains("КМОН-транзисторів"))
                result = Func14OrNotCMOS(tople.Item1, tople.Item2, line);
            else if (line.Contains("І, НЕ") && line.Contains("КМОН-транзисторів"))
                result = Func14AndNotCMOS(tople.Item1, tople.Item2, line);
            else if (line.Contains("АБО-НЕ"))
                result = Func14Or_Not(tople.Item1, tople.Item2, line);
            else if (line.Contains("І-НЕ"))
                result = Func14And_Not(tople.Item1, tople.Item2, line);
            return result.ToString();

        }

        static int Func14And_Not(int countNormal, int countInverse, string line)
        {
            int input = line.Contains("кількість виходів") ? 0 : 1;
            int result = 0;
            switch (input)
            {
                case 0:
                    if (countNormal == 1 && countInverse == 0)
                        result = 0;
                    else if (countNormal == 0 && countInverse == 1)
                        result = 1;
                    else result = 2 + countInverse;
                    break;
                case 1:
                    if (countNormal == 0 && countInverse == 1)
                        result = 1;
                    else if (countNormal == 1 && countInverse == 0)
                        return 0;
                    else
                        result = countNormal + countInverse * 2 + 1;
                    if (line.Contains("КМОН"))
                        result = result * 2;
                    break;
            }
            return result;
        }  
        static int Func14Or_Not(int countNormal, int countInverse, string line)
        {
            int input = line.Contains("кількість виходів") ? 0 : 1;
            int result = 0;
            switch (input)
            {
                case 0:
                    if (countNormal == 1 && countInverse == 0)
                        return 0;
                    else if (countNormal == 0 && countInverse == 1)
                        return 1;
                    else
                        return 1 + countNormal;
                case 1:
                    if (countNormal == 1 && countInverse == 0)
                        return 0;
                    else if (countNormal == 0 && countInverse == 1)
                        return 1;
                    else
                        result = countNormal * 2 + countInverse;
                    if (line.Contains("КМОН"))
                        result = result * 2;
                    break;
            }
            return result;
        }
        static int Func14AndNotCMOS(int countNormal, int countInverse, string line)
        {
            int inPuts = 0;
            if (countNormal == 0 && countInverse == 1)
                inPuts = 1;
            else if (countNormal == 0 && countInverse == 0)
                inPuts = 0;
            else if (countNormal == 1 && countInverse == 0)
                inPuts = 0;
            else if (countNormal > 1 && countInverse == 0)
                inPuts = countNormal;
            else
                inPuts = countNormal + countInverse * 2 + 1;
            return inPuts * 2;
        }
        static int Func14OrNotCMOS(int countNormal, int countInverse, string line)
        {
            int inPuts = 0;
            if (countNormal == 0 && countInverse == 1)
                inPuts = 1;
            else if (countNormal != 0 && countInverse != 0)
                inPuts = (countInverse * 2) + countNormal + 1;
            else if (countNormal == 1 && countInverse == 0)
                inPuts = 0;
            else if (countNormal != 0 && countInverse == 0)
                inPuts = countNormal;
            else if (countNormal == 0 && countInverse != 0)
                inPuts = countInverse * 2;
            return inPuts * 2;
        }
        static int Func14BullCMOS(int countNormal, int countInverse, string line)
        {
            int inverseInput = countInverse != 0 ? countInverse * 2 : 0;
            int normalInput = countNormal != 0 ? countNormal : 0;
            if (normalInput == 1 && inverseInput == 0)
                return 0;
            else if (normalInput == 0 && inverseInput == 1)
                return 2;
            normalInput = normalInput < 0 ? normalInput * (-1) : normalInput;
            return (inverseInput + normalInput) * 2 + 2;

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
