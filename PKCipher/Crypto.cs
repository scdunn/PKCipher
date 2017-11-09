using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PKCipher
{
    public class Crypto
    {
        

        private static List<char> CreateSwapTable(string password)
        {
            List<char> table = new List<char>();
            table.AddRange("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray());

            int passIndex = 0;

            for (int i = 0; i < table.Count(); i++)
            {
                int j = (i + password[passIndex]) % table.Count;
                char jChar = table[j];
                table[j] = table[i];
                table[i] = jChar;
            }
            System.Diagnostics.Debug.WriteLine(table.ToString());
            return table;
        }

        /// <summary>
        /// Encrypt a string value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(string input, string password)
        {
            string result = null;
            char last = 'a';

            List<char> swapTable = CreateSwapTable(password);
            int swapCount = swapTable.Count();

            for (int i = 0; i < input.Length; i++)
            {

                if (!swapTable.Contains(input[i]))
                    throw new Crypto.InvalidCharacterException();

                int index = swapTable.IndexOf(input[i]) + (i == 0 ? 5 : (int)(last * 1.85));
                if (index >= swapCount)
                    index = (index - swapCount) % swapCount;

                last = swapTable[index];
                result += last;
            }

            return result;

        }
        
        /// <summary>
        /// Decrypt a string value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Decrypt(string input, string password)
        {
            string result = null;
            char last = 'a';

            List<char> swapTable = CreateSwapTable(password);
            swapTable.Reverse();

            int swapCount = swapTable.Count();

            for (int i = input.Length - 1; i >= 0; i--)
            {

                int index = swapTable.IndexOf(input[i]) + (i == 0 ? 5 : (int)(input[i - 1] * 1.85));
                if (index >= swapCount)
                    index = (index - swapCount) % swapCount;

                last = swapTable[index];
                result = last + result;

            }


            return result;

        }
        
    }
}
