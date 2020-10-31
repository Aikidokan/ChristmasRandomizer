using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasGift.PairingApp
{
    public class Program
    {
        private List<string> strl;
        private List<string> strlst;
        private Random rnd;

        private static void Main(string[] args)
        {
            string readFile = @"C:\temp\TmpTxt\people.txt";

            var str = MakeStringCombine(readFile);
            string resultFile = @"C:\temp\TmpTxt\RandomizedResult.txt";

            WriteFile(str, resultFile);

            Console.WriteLine("Nu finns det 4 namnpar matchade!");

            // Keep the console window open in debug mode.
            Console.WriteLine("klicka för att stänga");
            Console.ReadKey();
        }

        private static void WriteFile(List<string> str, string resultFile)
        {
            try
            {
                // Create a new file     
                using (StreamWriter sr = new StreamWriter(resultFile))
                {
                    foreach (var s in str)
                    {
                        sr.WriteLine(s);
                    }
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private static List<string> MakeStringCombine(string readFile)
        {
           
            var seed = (int) DateTime.Now.Ticks;
            
            var random = new Random(seed);


            var lines = File.ReadAllLines(readFile);
            var sr = lines.OrderBy(x => random.Next()).ToArray();
            
            var firstArray = sr.Take(sr.Length / 2).ToArray();
            var secondArray = sr.Skip(sr.Length / 2).ToArray();

            var res = new List<string>();
            var List1 = firstArray.ToList();
            var List2 = secondArray.ToList();

            for (int i = 0; i < firstArray.Length; i++)
            {
                int first = random.Next(0, List1.Count);
                int second = random.Next(0, List2.Count);
               
                string s = "(" + List1[first] + "," + List2[second] + ")";
                res.Add(s);
                List1.RemoveAt(first);
                List2.RemoveAt(second);
            }

            res.Sort();
            return res;
        }

      



    }
}