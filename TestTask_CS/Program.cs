using System;
using System.Linq;

namespace TestTask_CS
{
    class Path
    {
        public string From;
        public string To;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int num;
#if DEBUG
            num = 4;
#else
            Console.WriteLine("enter the number of city pairs:");
            num = int.Parse(Console.ReadLine());
#endif
            string[] inputData = new string[num];
            Path[] nPaths = new Path[num];
            int i = 0;
#if DEBUG
            inputData[0] = "Moscow Tumen";
            inputData[1] = "Tumen RostovNaDonu";
            inputData[2] = "RostovNaDonu Piter";
            inputData[3] = "Tomsk Moscow";
#else
            while (i < num)
            {
                Console.WriteLine($"enter the city pair <from-to>(from: City{1 + i}, to: city{2 + i}):");
                inputData[i] = Console.ReadLine();
                i++;
            }
#endif
            for (i = 0; i < num; i++)
            {
                nPaths[i] = new Path()
                {
                    From = inputData[i].Split(inputData[i].Where(ch => !char.IsLetter(ch) || char.IsWhiteSpace(ch)).FirstOrDefault())[0].Trim(),
                    To = inputData[i].Split(inputData[i].Where(ch => !char.IsLetter(ch) || char.IsWhiteSpace(ch)).FirstOrDefault())[1].Trim()
                };
            }

            string resOutput = String.Empty;
            string fromOrTo = String.Empty;
            bool replaceFirstToLast = false;
            for (int j = 0; j < nPaths.Length; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    if (k == 0)
                        fromOrTo = nPaths[j].From;
                    else
                        fromOrTo = nPaths[j].To;

                    if (j == 0 && fromOrTo == nPaths[nPaths.Length - 1].To)
                    {
                        replaceFirstToLast = true;
                        continue;
                    }
                    else if (j != 0 && fromOrTo == nPaths[j - 1].To)
                        continue;

                    resOutput += fromOrTo + (j == nPaths.Length-1 && k != 0 ? String.Empty : " ");
                }

            }

            if (replaceFirstToLast)
            {
                resOutput = resOutput.Substring(resOutput.LastIndexOf(nPaths[nPaths.Length - 1].From[0]))
                    + " "
                    + resOutput.Substring(0, resOutput.Length - (nPaths[nPaths.Length - 1].From.Length + nPaths[nPaths.Length - 1].To.Length + 2));
            }
            Console.WriteLine(resOutput);
            Console.ReadKey();
        }
    }
}
