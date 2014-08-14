using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// Symmetric encryption
    /// 
    /// The .NET Framework offers an extensive set of algorithms for both symmetric and asymmetric encryption.
    /// 
    /// One symmetric algorithm is the Advanced Encryption Standard (AES).
    /// AES is adopted by the U.S. government and is becoming the standard worldwide for both governmental and business use. 
    /// The .NET Framework has a managed implementation of the AES algorithm in the AesManaged class. 
    /// All cryptography classes can be found in the System.Security.Cryptography class.
    /// 
    /// This program shows an example of using this algorithm to encrypt and decrypt a piece of text.
    /// As you can see, AES is a symmetric algorithm that uses a key and IV for encryption. 
    /// By using the same key and IV, you can decrypt a piece of text.
    /// The cryptography classes all work on byte sequences.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            EncryptSomeText();

            Console.ReadLine();
        }

        public static void EncryptSomeText()
        {
            string original = "My secret data!";

            using (SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
            {
                Console.WriteLine("Original: {0}", original);

                byte[] encrypted = Encrypt(symmetricAlgorithm, original);
                Console.WriteLine("Cipher data: {0}", encrypted.Aggregate<byte, string>("", (s, b) => s += b.ToString()));

                string decrypted = Decrypt(symmetricAlgorithm, encrypted);

                Console.WriteLine("Decrypted:{0}", decrypted);

                // The SymmetricAlgorithm class has both a method for creating an encryptor and a decryptor.
                // By using the CryptoStream class, you can encrypt or decrypt a byte sequence. 
            }
        }

        static byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
