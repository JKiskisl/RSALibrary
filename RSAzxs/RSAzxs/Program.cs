using System;

namespace RSAzxs
{
    class Program
    {
        static void Main(string[] args)
        {
            RSA rsa = new RSA();

            Console.WriteLine("Public key: " + rsa.PublicKeyString());
            Console.WriteLine("Enter msg: ");
            String msg = Console.ReadLine();

            Console.WriteLine("Encrypted text: " + rsa.Encrypt(msg));

            Console.WriteLine("Decrypted text: " + rsa.Decryption(rsa.Encrypt(msg)));
        }
    }
}
