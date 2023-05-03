namespace EncryptionAlgorithms.AlgorithmsCode
{
    public class Vigenere
    {
        public static string Encrypt(string text, string key)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Input text cannot be null or empty");
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty");

            string result = "";

            int keyIndex = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    // Calculate the shift amount based on the corresponding key letter
                    int shift = (int)(char.ToLower(key[keyIndex % key.Length]) - 'a');

                    // Apply the Caesar Cipher shift
                    char newChar = (char)((((c + shift) - 'a') % 26) + 'a');
                    result += newChar;

                    // Move to the next key letter
                    keyIndex++;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }

        public static string Decrypt(string text, string key)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Input text cannot be null or empty");
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty");

            string result = "";

            int keyIndex = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    // Calculate the shift amount based on the corresponding key letter
                    int shift = (int)(char.ToLower(key[keyIndex % key.Length]) - 'a');

                    // Apply the reverse Caesar Cipher shift
                    char newChar = (char)((((c - shift) - 'a' + 26) % 26) + 'a');
                    result += newChar;

                    // Move to the next key letter
                    keyIndex++;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }
    }
}