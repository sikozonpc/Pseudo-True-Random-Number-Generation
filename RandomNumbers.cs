using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    class RandomNumbers
    {
        // Random object that gets a CPU clock as seeding , Note that you can give a seed
        // as a parameter
        static Random obj = new Random(); 

        private static void Main(string[] args)
        {
           
            Console.WriteLine("PSEUDO random number with random seed: " + GetPseudoRandom());
            Console.WriteLine("PSEUDO random number with given seed: " + GetPseudoRandom2(100));
            Console.WriteLine("SECURE random number: " + GetSecureRandom());
            Console.WriteLine("UNIQUE random key: " + GetUniqueKey());

            // Input reader for the console window not close up
            Console.ReadKey();
        }

        /// <summary>
        /// Returns a PSEUDO random number generated from the cpu clock using a random seed
        /// </summary>
        private static int GetPseudoRandom()
        {
            return obj.Next();
        }

        /// <summary>
        /// Returns a PSEUDO random number generated with a seed thats is given by the user
        /// (Same seed = Same Number)
        /// </summary>
        /// <param name="seed"> Is the trigger and beginning point in the generation process</param>
        /// <returns></returns>
        private static int GetPseudoRandom2(int seed)
        {
            Random obj2 = new Random(seed);
            return obj2.Next();
        }

        /// <summary>
        /// Returns a true or secure random number where
        /// the seed of the secure random number uses entropy from sound, mouse clicks 
        /// keyboard timings and thermal temperatures etc.
        /// </summary>
        /// <returns></returns>
        public static int GetSecureRandom()
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                int randomvalue = BitConverter.ToInt32(rno, 0);

                return randomvalue;
            }
        }

        public static string GetUniqueKey()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
