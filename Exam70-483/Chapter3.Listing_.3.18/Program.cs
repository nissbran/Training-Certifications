using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// Asymmetric encryption
    /// 
    /// The .NET Framework also has support for asymmetric encryption. 
    /// You can use the RSACryptoServiceProvider and DSACryptoServiceProvider classes.
    /// When working with asymmetric encryption, you typically use the public key from another party. 
    /// You encrypt the data using the public key so only the other party can decrypt the data with their private key.
    /// 
    /// This example shows how you can create a new instance of the RSACryptoServiceProvider and export the public key to XML.
    /// By passing true to the ToXmlString method, you also export the private part of your key.
    /// </summary>
    class Program
    {
        private static string publicKeyXML;
        private static string privateKeyXML;

        static void Main(string[] args)
        {
            GenerateAndDisplayRSAKeys();

            Console.WriteLine();

            EncryptSomeText();

            Console.ReadLine();
        }

        static void GenerateAndDisplayRSAKeys()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            publicKeyXML = rsa.ToXmlString(false);
            privateKeyXML = rsa.ToXmlString(true);

            Console.WriteLine(publicKeyXML);
            Console.WriteLine(privateKeyXML);

            // The public key is the part you want to publish so others can use it to encrypt data. 
            // You can send it to someone directly or publish it on a website that belongs to you. 
        }

        static void EncryptSomeText()
        {
            string dataToBeEncrypted = "My secret text!";
            Console.WriteLine("Original: {0}", dataToBeEncrypted);

            var encryptedData = Encrypt(dataToBeEncrypted);
            Console.WriteLine("Cipher data: {0}", encryptedData.Aggregate<byte, string>("", (s, b) => s += b.ToString()));

            var decryptedString = Decrypt(encryptedData);

            Console.WriteLine("Decrypted:{0}", decryptedString);

            // As you can see, you first need to convert the data you want to encrypt to a byte sequence.
            // To encrypt the data, you need only the public key.
            // You then use the private key to decrypt the data. 

            // Because of this, it’s important to store the private key in a secure location.
            // If you would store it in plain text on disk or even in a nonsecure memory location, 
            // your private key could be extracted and your security would be compromised. 

            // The .NET Framework offers a secure location for storing asymmetric keys in a key container. 
            // A key container can be specific to a user or to the whole machine. 
            // This example shows how to configure an RSACryptoServiceProvider to use a key container for saving and loading the asymmetric key.

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes(dataToBeEncrypted);
            string containerName = "SecretContainer";
            CspParameters csp = new CspParameters() { KeyContainerName = containerName };

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
            {
                var encryptedByteData = RSA.Encrypt(dataToEncrypt, false);
            }
        }

        static byte[] Encrypt(string input)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes(input);

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKeyXML);
                return RSA.Encrypt(dataToEncrypt, false);
            }
        }

        static string Decrypt(byte[] encryptedData)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML);
                byte[] decryptedData = RSA.Decrypt(encryptedData, false);

                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                return ByteConverter.GetString(decryptedData);
            }
        }
    }
}
