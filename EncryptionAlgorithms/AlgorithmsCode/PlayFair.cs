namespace EncryptionAlgorithms.AlgorithmsCode
{
    public class PlayFair
    {
        private static string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; // no "J" in Playfair Cipher
        private static char[,] grid = new char[5, 5];

        // Generates the encryption grid based on the given key
        private static void GenerateGrid(string key)
        {
            // Remove any duplicate letters from the key
            key = RemoveDuplicates(key);

            // Fill the grid with the key
            int index = 0;
            foreach (char c in key)
            {
                grid[index / 5, index % 5] = Char.ToUpper(c);
                index++;
            }

            // Fill the remaining cells with the remaining letters of the alphabet
            foreach (char c in alphabet)
            {
                if (c != 'J' && !key.Contains(c))
                {
                    grid[index / 5, index % 5] = c;
                    index++;
                }
            }
        }

        // Removes any duplicate letters from the given string
        private static string RemoveDuplicates(string input)
        {
            string result = "";

            foreach (char c in input)
            {
                if (!result.Contains(c))
                {
                    result += c;
                }
            }

            return result;
        }

        // Returns the row and column indices of the given character in the grid
        private static Tuple<int, int> GetPosition(char c)
        {
            int row = -1;
            int col = -1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (grid[i, j] == Char.ToUpper(c))
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
            }

            return new Tuple<int, int>(row, col);
        }

        // Encrypts plaintext using a Playfair cipher with the given key
        public static string Encrypt(string plaintext, string key)
        {
            GenerateGrid(key);

            // Remove any non-alphabetic characters from the plaintext and convert to uppercase
            plaintext = new string(Array.FindAll(plaintext.ToUpper().ToCharArray(), Char.IsLetter));

            // Insert "X" between any two identical consecutive letters in the plaintext
            for (int i = 1; i < plaintext.Length; i++)
            {
                if (plaintext[i] == plaintext[i - 1])
                {
                    plaintext = plaintext.Insert(i, "X");
                }
            }

            // If the plaintext length is odd, append "X" to the end
            if (plaintext.Length % 2 != 0)
            {
                plaintext += "X";
            }

            // Divide the plaintext into pairs of letters
            List<string> pairs = new List<string>();
            for (int i = 0; i < plaintext.Length; i += 2)
            {
                pairs.Add(plaintext.Substring(i, 2));
            }

            // Encrypt each pair of letters using the encryption rules of the Playfair cipher
            string ciphertext = "";
            foreach (string pair in pairs)
            {
                Tuple<int, int> pos1 = GetPosition(pair[0]);
                Tuple<int, int> pos2 = GetPosition(pair[1]);

                int row1 = pos1.Item1;
                int col1 = pos1.Item2;
                int row2 = pos2.Item1;
                int col2 = pos2.Item2;

                if (row1 == row2)
                {
                    col1 = (col1 + 1);
                    // If the two letters are in the same row, shift each one to the right (wrapping around to the leftmost column if necessary)
                    col2 = (col2 + 1) % 5;
                    col1 = (col1 + 1) % 5;
                }
                else if (col1 == col2)
                {
                    // If the two letters are in the same column, shift each one down (wrapping around to the top row if necessary)
                    row2 = (row2 + 1) % 5;
                    row1 = (row1 + 1) % 5;
                }
                else
                {
                    // Otherwise, swap the columns of the two letters
                    int temp = col1;
                    col1 = col2;
                    col2 = temp;
                }
                ciphertext += grid[row1, col1];
                ciphertext += grid[row2, col2];
            }

            return ciphertext;
        }

        // Decrypts ciphertext using a Playfair cipher with the given key
        public static string Decrypt(string ciphertext, string key)
        {
            GenerateGrid(key);

            // Divide the ciphertext into pairs of letters
            List<string> pairs = new List<string>();
            for (int i = 0; i < ciphertext.Length; i += 2)
            {
                pairs.Add(ciphertext.Substring(i, 2));
            }

            // Decrypt each pair of letters using the decryption rules of the Playfair cipher
            string plaintext = "";
            foreach (string pair in pairs)
            {
                Tuple<int, int> pos1 = GetPosition(pair[0]);
                Tuple<int, int> pos2 = GetPosition(pair[1]);

                int row1 = pos1.Item1;
                int col1 = pos1.Item2;
                int row2 = pos2.Item1;
                int col2 = pos2.Item2;

                if (row1 == row2)
                {
                    // If the two letters are in the same row, shift each one to the left (wrapping around to the rightmost column if necessary)
                    col2 = (col2 + 4) % 5;
                    col1 = (col1 + 4) % 5;
                }
                else if (col1 == col2)
                {
                    // If the two letters are in the same column, shift each one up (wrapping around to the bottom row if necessary)
                    row2 = (row2 + 4) % 5;
                    row1 = (row1 + 4) % 5;
                }
                else
                {
                    // Otherwise, swap the columns of the two letters
                    int temp = col1;
                    col1 = col2;
                    col2 = temp;
                }

                plaintext += grid[row1, col1];
                plaintext += grid[row2, col2];
            }

            return plaintext;
        }
    }
}
