using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

namespace StructOfText
{
    //class Symbol
    //{
    //    //public char[] symbols;

    //    static public void GetSymbols(string word, char[] symbols)
    //    {
    //        int i = 0;
    //        foreach (char c in word)
    //        {
    //            symbols[i] = c;
    //            i++;
    //        }
    //    }
    //}

    //class Punctuation
    //{
    //    //char[] punctuation = { '.', ',', '!', '?', ';', '-' };
    //    //static public char[] Spaces = { ' ', ',', '-', '(', ')', ';' };
    //    //static public char[] EndOfSentence = { '.', '!', '?' };

    //    static public string[] GetPuctuation(string sentence)
    //    {
    //        string[] pucntuation = new string[Word.GetNumberOfWords(sentence) + 2];
    //        int j = 0;
    //        bool flag = false;
    //        foreach (char c in sentence)
    //        {
    //            if (c == ',' || c == ';' || c == ' ' || c == '-' || c == '.' || c == '!' || c == '?')
    //            {
    //                pucntuation[j] += c;
    //                flag = true;
    //            }
    //            else
    //            {
    //                if (flag)
    //                {
    //                    j++;
    //                    flag = false;
    //                }
    //                pucntuation[j] = null;
    //            }
    //        }
    //        return pucntuation;
    //    }
    //}

    //class Word
    //{
    //    ////public string word;
    //    ////public int number_of_repetitions;
    //    ////public int[] strings;

    //    static public int GetNumberOfWords(string sentence)
    //    {
    //        int number = 0;
    //        bool flag = false;
    //        foreach (char c in sentence)
    //        {
    //            if (c == ',' || c == ';' || c == ' ' || c == '-' || c == '.' || c == '!' || c == '?')
    //            {
    //                flag = true;
    //            }
    //            else
    //            {
    //                if (flag)
    //                {
    //                    number++;
    //                    flag = false;
    //                }
    //            }
    //        }
    //        return number;
    //    }

    //    static public string[] Words(string sentence)
    //    {
    //        string[] words = new string[GetNumberOfWords(sentence)];
    //        int j = 0;
    //        bool flag = false;
    //        if(sentence[0] == ' ')
    //        {
    //            j--;
    //        }
    //        foreach (char c in sentence)
    //        {
    //            if (c == ',' || c == ';' || c == ' ' || c == '-' || c == '.' || c == '!' || c == '?')
    //            {
    //                flag = true;
    //            }
    //            else
    //            {
    //                if (flag)
    //                {
    //                    j++;
    //                    flag = false;
    //                }
    //                words[j] += c;

    //            }
    //        }
    //        return words;
    //    }

    //    //static public Word[] Wordss(string sentence)
    //    //{
    //    //    Word[] words = new Word[GetNumberOfWords(sentence)];
    //    //    int j = 0;
    //    //    bool flag = false;
    //    //    if (sentence[0] == ' ')
    //    //    {
    //    //        j--;
    //    //    }
    //    //    foreach (char c in sentence)
    //    //    {
    //    //        if (c == ',' || c == ';' || c == ' ' || c == '-' || c == '.' || c == '!' || c == '?')
    //    //        {
    //    //            flag = true;
    //    //        }
    //    //        else
    //    //        {
    //    //            if (flag)
    //    //            {
    //    //                j++;
    //    //                flag = false;
    //    //            }
    //    //            words[j].word += c;

    //    //        }
    //    //    }
    //    //    return words;
    //    //}

    //}

    //class Sentence
    //{
    //    //public string[] sentences;

    //    static public int GetNumberOfSentences(string path)
    //    {
    //        int i = 0;
    //        using (StreamReader sr = File.OpenText(path))
    //        {
    //            foreach (char c in sr.ReadLine())
    //            {
    //                if (c == '.' || c == '!' || c == '?')
    //                {
    //                    i++;
    //                }
    //            }
    //        }
    //        return i;
    //    }

    //    static public string[] ReadText(string path)
    //    {
    //        string[] Text = new string[GetNumberOfSentences(path)];
    //        string sentence = "";
    //        int i = 0;
    //        using (StreamReader sr = File.OpenText(path))
    //        {
    //            foreach(char c in sr.ReadLine())
    //            {
    //                sentence += c;
    //                if (c == '.' || c == '!' || c == '?')
    //                {
    //                    Text[i] = sentence;
    //                    i++;
    //                    sentence = "";
    //                }
    //            }
    //        }

    //        return Text;
    //    }

    //    static public string GetText(string path, string text)
    //    {
    //        using (StreamReader sr = File.OpenText(path))
    //        {
    //            text += sr.ReadLine();
    //        }
    //        return text;
    //    }
    //}

    //static public bool CheckWord(Word[] words, string buffer) {
    //    for (int i = 0; i < words.Length; i++)
    //    {
    //        if (words[i] != null)
    //        {
    //            if (words[i].word == buffer)
    //            {
    //                return true;
    //            }
    //        }
    //    }
    //    return false;
    //}

    //static public int GetLenght(string path)
    //{
    //    string[] sentences = Sentence.ReadText(path);
    //    int lenght = 0;
    //    for (int i = 0; i < sentences.Length; i++)
    //    {
    //        lenght += Word.GetNumberOfWords(sentences[i]);
    //    }
    //    return lenght;
    //}

    //static public Word[] CountWord(string path)
    //{
    //    Word[] words = new Word[GetLenght(path)];
    //    int string_counter = 0;
    //    int word_counter = -1;
    //    using (StreamReader sr = File.OpenText(path)) {
    //        string[] buffer = Word.Words(sr.ReadLine());
    //        bool flag = true;
    //        for (int i = 0; i < buffer.Length; i++)
    //        {
    //            if (CheckWord(words, buffer[i])) {

    //                words[word_counter].number_of_repetitions++;
    //                if (flag)
    //                {
    //                    words[word_counter].strings[string_counter] = string_counter + 1;
    //                    flag = false;
    //                }
    //            }
    //            else
    //            {
    //                word_counter++;
    //                words[word_counter] = new Word();
    //                words[word_counter].word = buffer[i];
    //                words[word_counter].number_of_repetitions = 1;
    //                words[word_counter].strings = new int[GetLenght(path)];
    //                words[word_counter].strings[string_counter] = string_counter + 1;

    //            }
    //        }
    //        string_counter++;
    //    }
    //    Word[] answer = new Word[word_counter+ 1];
    //    for (int i = 0; i < word_counter + 1; i++)
    //    {
    //        answer[i] = words[i];
    //    }
    //    return answer;
    //}

    //static public bool needToReOrder(string s1, string s2)
    //{
    //    for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
    //    {
    //        if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
    //        if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
    //    }
    //    return false;
    //}

    //static public Word[] Sort(string path)
    //{
    //    Word[] words = CountWord(path);
    //    for (int i = 0; i < words.Length; i++)
    //    {
    //        for (int j = 0; j < words.Length - 1; j++)
    //        {
    //            if (needToReOrder(words[j].word, words[j + 1].word))
    //            {
    //                Word buffer = words[j];
    //                words[j] = words[j + 1];
    //                words[j + 1] = buffer;
    //            }
    //        }
    //    }
    //    return words;
    //}


}
