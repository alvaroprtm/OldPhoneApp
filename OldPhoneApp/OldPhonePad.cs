using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhoneApp
{
    internal class OldPhonePad
    {
        /// <summary>
        /// Converts an input string of old-phone keypad presses into text.
        /// Rules implemented:
        /// - Digits 2-9 map to letters (standard phone mapping).
        /// - '0' maps to space.
        /// - Repeating the same digit cycles through that key's letters.
        /// - A space in the input acts as a "pause" (commits the current key sequence).
        /// - A different digit commits the previous key sequence automatically.
        /// - '*' is backspace and deletes the last committed character (any pending key is committed first).
        /// - '#' is send/terminator and stops processing (it must be present at the end).
        /// - Any characters not listed are ignored.
        /// </summary>
        /// <param name="input">Sequence of key presses ending with '#'</param>
        /// <returns>Decoded output string</returns>
        public static string Decode(string input)
        {
            if (input == null) return string.Empty;

            // Basic phone mapping
            var map = new Dictionary<char, string>
            {
                { '0', " " },
                { '1', "1" },
                { '2', "ABC" },
                { '3', "DEF" },
                { '4', "GHI" },
                { '5', "JKL" },
                { '6', "MNO" },
                { '7', "PQRS" },
                { '8', "TUV" },
                { '9', "WXYZ" }
            };

            var output = new StringBuilder();

            char pendingKey = '\0';
            int pendingCount = 0;

            // Helper to commit pending presses to the output
            void CommitPending()
            {
                if (pendingKey == '\0' || pendingCount == 0) return;

                if (map.ContainsKey(pendingKey))
                {
                    string letters = map[pendingKey];
                    if (!string.IsNullOrEmpty(letters))
                    {
                        int index = (pendingCount - 1) % letters.Length;
                        output.Append(letters[index]);
                    }
                }

                pendingKey = '\0';
                pendingCount = 0;
            }

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (c == '#')
                {
                    // End of message: commit current pending key and stop
                    CommitPending();
                    break;
                }

                if (c == ' ')
                {
                    // Pause: commit what we've built so far for the current key
                    CommitPending();
                    continue;
                }

                if (c == '*')
                {
                    // Backspace: commit pending presses first, then remove last char if any
                    CommitPending();
                    if (output.Length > 0)
                    {
                        output.Remove(output.Length - 1, 1);
                    }
                    continue;
                }

                // If digit 0-9
                if (c >= '0' && c <= '9')
                {
                    if (pendingKey == c)
                    {
                        // same key pressed again -> increase count
                        pendingCount++;
                    }
                    else
                    {
                        // different key -> commit previous and start a new pending sequence
                        CommitPending();
                        pendingKey = c;
                        pendingCount = 1;
                    }
                    continue;
                }

                // Any other character: treat like a pause and ignore the character itself
                CommitPending();
            }

            return output.ToString();
        }
    }
}
