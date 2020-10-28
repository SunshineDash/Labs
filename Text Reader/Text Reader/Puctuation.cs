using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Reader
{
    class Punctuation
    {
        //char[] punctuation = { '.', ',', '!', '?', ';', '-' };
        //static public char[] Spaces = { ' ', ',', '-', '(', ')', ';' };
        //static public char[] EndOfSentence = { '.', '!', '?' };

        static public string[] GetPuctuation(string sentence)
        {
            string[] pucntuation = new string[Word.GetNumberOfWords(sentence) + 2];
            int j = 0;
            bool flag = false;
            foreach (char c in sentence)
            {
                if (c == ',' || c == ';' || c == ' ' || c == '-' || c == '.' || c == '!' || c == '?')
                {
                    pucntuation[j] += c;
                    flag = true;
                }
                else
                {
                    if (flag)
                    {
                        j++;
                        flag = false;
                    }
                    pucntuation[j] = null;
                }
            }
            return pucntuation;
        }

    }
}
