using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Text_Reader
{
    class Sentence
    {
        static public int GetNumberOfSentences(string path)
        {
            int i = 0;
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    foreach (char c in sr.ReadLine())
                    {
                        if (c == '.' || c == '!' || c == '?')
                        {
                            i++;
                        }
                    }
                }
            }
            return i;
        }

        static public string[] ReadText(string path)
        {
            string[] Text = new string[GetNumberOfSentences(path)];
            string sentence = "";
            int i = 0;
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    foreach (char c in sr.ReadLine())
                    {
                        sentence += c;
                        if (c == '.' || c == '!' || c == '?')
                        {
                            Text[i] = sentence;
                            i++;
                            sentence = "";
                        }
                    }
                }
            }

            return Text;
        }

        static public string GetText(string path, string text)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                text += sr.ReadLine();
            }
            return text;
        }

    }
}
