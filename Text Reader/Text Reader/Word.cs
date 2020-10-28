using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Reader
{
    class Word
    {
        static public int GetNumberOfWords(string sentence)
        {
            int number = 0;
            bool flag = false;
            foreach (char c in sentence)
            {
                if (c == ',' || c == ';' || c == ' ' || c == '-' || c == '.' || c == '!' || c == '?')
                {
                    flag = true;
                }
                else
                {
                    if (flag)
                    {
                        number++;
                        flag = false;
                    }
                }
            }
            return number;
        }

        static public string[] Words(string sentence)
        {
            string[] words = new string[GetNumberOfWords(sentence)];
            int j = 0;
            bool flag = false;
            if (sentence[0] == ' ')
            {
                j--;
            }
            foreach (char c in sentence)
            {
                if (c == ',' || c == ';' || c == ' ' || c == '-' || c == '.' || c == '!' || c == '?')
                {
                    flag = true;
                }
                else
                {
                    if (flag)
                    {
                        j++;
                        flag = false;
                    }
                    words[j] += c;

                }
            }
            return words;
        }

    }
}
