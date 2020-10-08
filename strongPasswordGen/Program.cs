using System;
using System.Text;

namespace strongPasswordGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many strong usernames and passwords do you want to create? ");
            int amountOfUserPass = Convert.ToInt32(Console.ReadLine());

            Genarator gen = new Genarator();

            for (int i = 0; i < amountOfUserPass; i++)
            {
                string username = gen.RandomUsername();
                string password = gen.RandomPassword();
                Console.WriteLine($"Username: {username}  Password: {password}");
            }
            Console.ReadKey();
        }
        public class Genarator
        {
            public int RandomNumber(int min, int max)
            {
                Random rand = new Random();
                return rand.Next(min, max);
            }

            public string RandomString(int size, bool lowerCase)
            {
                StringBuilder builder = new StringBuilder();
                Random rand = new Random();

                char ch;
                for (int i = 0; i < size; i ++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));
                    builder.Append(ch);
                }
                if (lowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();

            }

            public string RandomPassword()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(RandomString(3, false));
                builder.Append(RandomNumber(1, 1000));
                builder.Append(RandomString(3, true));
                return builder.ToString();
            }
            public string RandomUsername()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(RandomString(2, false));
                builder.Append(RandomNumber(1000, 10000));
                return builder.ToString();
            }
        }
    }
}
