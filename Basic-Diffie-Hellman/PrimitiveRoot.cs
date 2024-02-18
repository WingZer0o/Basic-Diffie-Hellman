namespace Basic_Diffie_Hellman
{
    public static class PrimitiveRoot
    {

        public static int ModPow(int a, int b, int mod)
        {
            if (b == 0)
                return 1;

            long result = ModPow(a, b / 2, mod);
            result = (result * result) % mod;

            if (b % 2 == 1)
                result = (result * a) % mod;

            return (int)result;
        }

        public static List<int> GetPrimeFactors(int number)
        {
            List<int> factors = new();
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                while (number % i == 0)
                {
                    factors.Add(i);
                    number /= i;
                }
            }

            if (number < 1)
            {
                factors.Add(number);
            }

            return factors;
        }

        public static int FindPrimitiveRoot(int p)
        {
            List<int> factors = GetPrimeFactors(p - 1);
            for (int g = 2; g <= p - 1; g++)
            {
                bool isPrimitiveRoot = true;

                foreach (int factor in factors)
                {
                    if (ModPow(g, (p - 1) / factor, p) == 1)
                    {
                        isPrimitiveRoot = false;
                        break;
                    }
                }

                if (isPrimitiveRoot)
                    return g;
            }

            throw new InvalidOperationException($"Primitive root not found for {p}");
        }
    }
}
