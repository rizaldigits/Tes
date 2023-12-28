using System;
using System.Collections.Generic;

namespace tes1
{
    class Program
    {

        static void Main(string[] args)
        {
            string inputString = "abbcccd";
            int[] queries = { 1, 3, 9, 8 };

            string[] output = CheckQueries(inputString, queries);

            Console.WriteLine("Output:");
            foreach (string result in output)
            {
                Console.Write(result + " ");
            }
            Console.ReadLine();
        }

        static Dictionary<char, int> CalculateWeights(string s)
        {
            Dictionary<char, int> weights = new Dictionary<char, int>();
            int totalWeight = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];
                if (i > 0 && s[i] == s[i - 1])
                {
                    int charWeight = weights[s[i - 1]] + (int)currentChar - 'a' + 1;
                    weights[currentChar] = charWeight;
                }
                else
                {
                    int charWeight = (int)currentChar - 'a' + 1;
                    weights[currentChar] = charWeight;
                }
                totalWeight += weights[currentChar];
            }

            return weights;
        }

        static string[] CheckQueries(string s, int[] queries)
        {
            Dictionary<char, int> weights = CalculateWeights(s);
            List<string> results = new List<string>();

            foreach (int query in queries)
            {
                if (weights.ContainsValue(query))
                {
                    results.Add("Yes");
                }
                else
                {
                    results.Add("No");
                }
            }
            return results.ToArray();
        }

    }
}
