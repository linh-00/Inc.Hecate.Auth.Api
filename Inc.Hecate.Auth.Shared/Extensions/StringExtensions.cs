using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Extensions
{
    public static class StringExtensions
    {
        private static readonly Random _random = new Random();

        public static string RandomString(this string _, int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();
        }
    }
}
