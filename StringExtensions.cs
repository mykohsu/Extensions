using System;
using System.Collections.Generic;

namespace UVAToDataCube
{
    public static class StringExtensions
    {
        public static string[] SplitWithQuotes(this string input, int requiredCount = 0, char quoteChar = '"', char delim = ',', char escape = '\\')
        {
            List<string> result = new List<string>(requiredCount);

            int end = 0, start = 0;

            while (start < input.Length)
            {
                char c = input[start];

                if (c == quoteChar)
                {
                    while (++end < input.Length && input[end] != quoteChar && input[end - 1] != escape) ;
                    result.Add(input.Substring(++start, end - start));
                    start = ++end;
                }
                else if (c == delim)
                {
                    if (end == input.Length - 1 || input[end + 1] == delim)
                    {
                        result.Add(string.Empty);
                    }
                    start = ++end;
                }
                else
                {
                    while (++end < input.Length && input[end] != delim) ;
                    result.Add(input.Substring(start, end - start));
                    start = end;
                }
            }

            if (requiredCount > 0 && result.Count != requiredCount)
            {
                throw new InvalidOperationException("Input string cannot be split into the required number of parts.");
            }

            return result.ToArray();
        }
    }
}
