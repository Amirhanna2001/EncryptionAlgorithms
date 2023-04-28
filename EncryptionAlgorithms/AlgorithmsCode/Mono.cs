using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace EncryptionAlgorithms.AlgorithmsCode
{
    public class Mono
    {   
        private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string key = "QWERTYUIOPASDFGHJKLZXCVBNM";
        public static string Encrypt(string plaintext)
        {
            string ciphertext = "";

            foreach (char c in plaintext)
            {
                if (Char.IsLetter(c))
                {
                    // Determine the position of the character in the alphabet (0-25)
                    int position = Char.ToUpper(c) - 'A';

                    // Use the key to encrypt the character
                    char encryptedChar = key[position];

                    // Add the encrypted character to the ciphertext
                    ciphertext += encryptedChar;
                }
                else
                {
                    // Leave non-alphabetic characters unchanged
                    ciphertext += c;
                }
            }

            return ciphertext;
        }

        // Decrypts ciphertext using a monoalphabetic cipher with the given key
        public static string Decrypt(string ciphertext)
        {
            string plaintext = "";

            foreach (char c in ciphertext)
            {
                if (Char.IsLetter(c))
                {
                    // Determine the position of the encrypted character in the key (0-25)
                    int position = key.IndexOf(Char.ToUpper(c));

                    // Use the alphabet to decrypt the character
                    char decryptedChar = alphabet[position];

                    // Add the decrypted character to the plaintext
                    plaintext += decryptedChar;
                }
                else
                {
                    // Leave non-alphabetic characters unchanged
                    plaintext += c;
                }
            }

            return plaintext;
        }
    }
}
