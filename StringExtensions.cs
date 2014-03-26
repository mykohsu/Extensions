
namespace Extensions
{
    public static class StringExtensions
    {
        public static string[] Split(this string input, int numOfParts)
        {
            const char quoteChar = '"';
            const char delim = ',';
            const char escape = '\\';

            string[] result = new string[numOfParts];

            int i = 0, end = 0, start = 0;

            while (start < input.Length)
            {
                switch (input[start])
                {
                    case quoteChar:
                        start++;
                        while (input[++end] != quoteChar && input[end - 1] != escape) ;
                        result[i++] = input.Substring(start, end - start);
                        start = ++end;
                        break;
                    case delim:
                        if (end == input.Length - 1 || input[end + 1] == delim)
                        {
                            result[i++] = string.Empty;
                        }
                        start = ++end;
                        break;
                    default:
                        while (++end < input.Length && input[end] != delim) ;
                        result[i++] = input.Substring(start, end - start);
                        start = end;
                        break;
                }
            }

            return result;
        }
    }
}
