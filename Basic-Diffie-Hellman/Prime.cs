namespace Basic_Diffie_Hellman
{
    public static class Prime
    {
        public static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static int GenerateRandomPrime(int min, int max)
        {
            Random rnd = new Random();

            while (true)
            {
                int candidate = rnd.Next(min, max + 1);
                if (IsPrime(candidate))
                    return candidate;
            }
        }
    }
}
