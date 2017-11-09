using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization; 

namespace PKCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (int i = 100; i<200; i++)
            {
                var salt = i.ToString().PadRight(5,'X');
                var code = Crypto.Encrypt(salt + "1000OK" + salt, "pass");
                Console.WriteLine(code);
            }
            

            
            Console.WriteLine("CODE:{0} --- {1}", "6R7Q2LWGNOMZMYHM", isValidCode("6R7Q2LWGNOMZMYHM"));
            Console.WriteLine("CODE:{0} --- {1}", "6R7Q2LWBNOMZMYHM", isValidCode("6R7Q2LWGNOMZMYHA"));

            var enc = Crypto.Encrypt("CHRISTOPHER", "pass");
            var dec = Crypto.Decrypt(enc, "pass");


            Console.WriteLine("O: {0}, E: {1}, D: {2}", "CHRISTOPHER", enc, dec);
            Console.ReadKey();
        }

        static bool isValidCode(string code)
        {
            var val = Crypto.Decrypt(code, "pass");
            if(val.EndsWith(val.Substring(0,5)))
                if(val.Contains("1000OK"))
                    return true;
            return false;
        }
    }

 

   
}
