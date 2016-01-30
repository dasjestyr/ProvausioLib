using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProvausioLib.Portable.Parsing
{
    public class TokenReplacer
    {
        /// <summary>
        /// Processes the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static string Process(string input, ReplacementToken token, IDictionary<string, string> values)
        {
            var result = input;
            foreach (var value in values)
            {
                var regex = new Regex($"{token.OpenToken}{value.Key}{token.CloseToken}");
                result = regex.Replace(result, value.Value);
            }

            return result;
        }
    }
}
