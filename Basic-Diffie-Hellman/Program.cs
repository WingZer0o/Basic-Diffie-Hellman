// See https://aka.ms/new-console-template for more information



using Basic_Diffie_Hellman;
using System.Numerics;

int prime = Prime.GenerateRandomPrime(2, 100000);
int primitiveRoot = PrimitiveRoot.FindPrimitiveRoot(prime);

int privateAlice = 10;
int privateBob = 250;

BigInteger publicAlice = BigInteger.ModPow(primitiveRoot, privateAlice, prime);
BigInteger publicBob = BigInteger.ModPow(primitiveRoot, privateBob, prime);

BigInteger sharedSecretAlice = BigInteger.ModPow(publicBob, privateAlice, prime);
BigInteger sharedSecretBob = BigInteger.ModPow(publicAlice, privateBob, prime);

Console.WriteLine("Alice's Shared Secret is: {0}", sharedSecretAlice);
Console.WriteLine("Bobs's Shared Secret is: {0}", sharedSecretBob);