using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Assingment_19
{
    public partial class Form1 : Form
    {
        private Dictionary<string, char> morseToText;

        public Form1()
        {
            InitializeComponent();
            InitializeMorseCode();
        }

        private void InitializeMorseCode()
        {
            Dictionary<char, string> wordBank = new Dictionary<char, string>()
            {
                { '.', ".-.-.-" },
                { '0', "-----" },
                { '1', ".----" },
                { '2', "..---" },
                { '3', "...--" },
                { '4', "....-" },
                { '5', "....." },
                { '6', "-...." },
                { '7', "--..." },
                { '8', "---.." },
                { '9', "----." },
                { 'A', ".-" },
                { 'B', "-..." },
                { 'C', "-.-." },
                { 'D', "-.." },
                { 'E', "." },
                { 'F', "..-." },
                { 'G', "--." },
                { 'H', "...." },
                { 'I', ".." },
                { 'J', ".---" },
                { 'K', "-.-" },
                { 'L', ".-.." },
                { 'M', "--" },
                { 'N', "-." },
                { 'O', "---" },
                { 'P', ".--." },
                { 'Q', "--.-" },
                { 'R', ".-." },
                { 'S', "..." },
                { 'T', "-" },
                { 'U', "..-" },
                { 'V', "...-" },
                { 'W', ".--" },
                { 'X', "-..-" },
                { 'Y', "-.--" },
                { 'Z', "--.." }
            };

            morseToText = new Dictionary<string, char>(StringComparer.OrdinalIgnoreCase);

            foreach (KeyValuePair<char, string> entry in wordBank)
            {
                morseToText[entry.Value] = entry.Key;
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string input = inputTextBox.Text.Trim();
                total.Text = TranslateToText(input);
            }
            catch (Exception ex)
            {
                total.Text = string.Empty;
                MessageBox.Show(ex.Message, "Invalid Morse Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TranslateToText(string morseCode)
        {
            if (string.IsNullOrWhiteSpace(morseCode))
            {
                return string.Empty;
            }

            ValidateInputCharacters(morseCode);

            string normalizedInput = NormalizeWhitespace(morseCode.Trim());
            List<string> words = SplitWords(normalizedInput);
            StringBuilder textResult = new StringBuilder();

            for (int i = 0; i < words.Count; i++)
            {
                string[] letters = words[i].Split(' ');

                foreach (string letter in letters)
                {
                    if (!morseToText.ContainsKey(letter))
                    {
                        MessageBox.Show  ("Invalid Input");
                    }

                    textResult.Append(morseToText[letter]);
                }

                if (i < words.Count - 1)
                {
                    textResult.Append(' ');
                }
            }

            return textResult.ToString();
        }

        private string NormalizeWhitespace(string input)
        {
            StringBuilder normalized = new StringBuilder();

            foreach (char character in input)
            {
                if (character == '\t' || character == '\r' || character == '\n')
                {
                    normalized.Append(' ');
                }
                else
                {
                    normalized.Append(character);
                }
            }

            return normalized.ToString();
        }

        private List<string> SplitWords(string morseCode)
        {
            List<string> words = new List<string>();
            StringBuilder currentWord = new StringBuilder();
            int spaceCount = 0;

            foreach (char character in morseCode)
            {
                if (character == ' ')
                {
                    spaceCount = spaceCount + 1;

                    if (spaceCount >= 1)
                    {
                    }

                    continue;
                }

                if (spaceCount == 2)
                {
                }

                if (spaceCount == 3)
                {
                    if (currentWord.Length == 0)
                    {
                    }

                    words.Add(currentWord.ToString());
                    currentWord.Clear();
                }
                else if (spaceCount == 1)
                {
                    if (currentWord.Length == 0 || currentWord[currentWord.Length - 1] == ' ')
                    {
                    }

                    currentWord.Append(' ');
                }

                currentWord.Append(character);
                spaceCount = 0;
            }

            if (spaceCount == 2)
            {
                MessageBox.Show("Invalid Input");
            }

            if (spaceCount == 3)
            {
                MessageBox.Show("Invalid Input");
            }

            if (currentWord.Length > 0)
            {
                words.Add(currentWord.ToString());
            }

            return words;
        }

        private void ValidateInputCharacters(string morseCode)
        {
            foreach (char character in morseCode)
            {
                if (character == '.' || character == '-' || character == ' ' || character == '\t' || character == '\r' || character == '\n')
                {
                    continue;
                }

                if (char.IsLetterOrDigit(character))
                {
                    MessageBox.Show("Invalid Input");
                }

                MessageBox.Show("Invalid Input");
            }
        }
    }
}
