using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using StructOfText;

namespace Text_Reader
{
    class Program
    {
        static public int[] BubbleSort(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array.Length - 1; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        int z = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = z;
                    }
                }
            }
            return Array;
        }

        static public int[] GetArray(string[] sentences)
        {
            int[] number = new int[sentences.Length];
            for (int i = 0; i < sentences.Length; i++)
            {
                number[i] = Word.GetNumberOfWords(sentences[i]);
            }
            return number;
        }

        static public string[] SortSentences(string path)
        {
            string[] sentences = Sentence.ReadText(path);
            string[] answer = new string[sentences.Length];
            int[] number = GetArray(sentences);
            number = BubbleSort(number);
            for (int i = 0; i < number.Length; i++)
            {
                for (int j = 0; j < sentences.Length; j++)
                {
                    if (Word.GetNumberOfWords(sentences[j]) == number[i])
                    {
                        answer[i] = sentences[j];
                        sentences[j] = "1";
                        break;
                    }
                }
            }
            return answer;
        }

        static public int CheckLenght(string[] sentences, int lenght)
        {
            string[] words;
            int counter = 0;
            for (int i = 0; i < sentences.Length; i++)
            {
                if (sentences[i][sentences[i].Length - 1] == '?')
                {
                    words = Word.Words(sentences[i]);
                    for (int j = 0; j < Word.GetNumberOfWords(sentences[i]); j++)
                    {
                        if (words[j].Length == lenght)
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter;
        }

        static public string[] FindWord(string path, int lenght)
        {
            string[] sentences = Sentence.ReadText(path);
            string[] words;
            string[] buffer = new string[CheckLenght(sentences, lenght)];
            int counter = 0;
            for (int i = 0; i < sentences.Length; i++)
            {      
                if(sentences[i][sentences[i].Length - 1] == '?')
                {
                    words = Word.Words(sentences[i]);
                    for (int j = 0; j < Word.GetNumberOfWords(sentences[i]); j++)
                    {
                        bool flag = true; 
                        for (int c = 0; c < buffer.Length; c++)
                        {
                            if(buffer[c] == words[j])
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            if (words[j].Length == lenght)
                            {
                                buffer[counter] = words[j];
                                counter++;
                            }
                        }
                    }
                }
            }
            string[] answer = new string[counter];
            for (int i = 0; i < counter; i++)
            {
                answer[i] = buffer[i];
            }
            return answer;
        }

        static bool Сonstant(char c)
        {
            string constant = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩQWERTYUIOPASDFGHJKLZXCVBNM";
            c = char.ToUpper(c);
            foreach (char g in constant)
                if (c == g) return true;
            return false;
        }

        static public string[] DeleteWords(string path, int lenght)
        {
            string[] sentences = Sentence.ReadText(path);
            for (int i = 0; i < sentences.Length; i++)
            {
                string[] words = Word.Words(sentences[i]);
                string[] puctuation = Punctuation.GetPuctuation(sentences[i]);
                sentences[i] = "";
                for (int j = 0; j < puctuation.Length; j++)
                {
                    if (j < words.Length)
                    {
                        if (words[j].Length == lenght && Сonstant(words[j][0]))
                        {
                            words[j] = null;
                        }
                        sentences[i] += words[j];
                    }
                    if (puctuation[j] != null)
                    {
                        sentences[i] += puctuation[j]; 
                    }
                }
            }
            return sentences;
        }

        static public string[] ChangeWord(string path, int sentece_number, int word_lenght, string changed_word)
        {
            string[] sentences = Sentence.ReadText(path);
            string[] words = Word.Words(sentences[sentece_number - 1]);
            string[] puctuation = Punctuation.GetPuctuation(sentences[sentece_number - 1]);
            sentences[sentece_number - 1] = "";
            for (int j = 0; j < puctuation.Length; j++)
            {
                if (puctuation[j] != null)
                {
                    sentences[sentece_number - 1] += puctuation[j];
                }
                if (j < words.Length)
                {
                    if (words[j].Length == word_lenght)
                    {
                        words[j] = changed_word;
                    }
                    sentences[sentece_number - 1] += words[j];
                }
                
            }

            return sentences;
        }

        static public void Output(string[] output)
        {
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
        }

        static public void Menu(string path, string result_path)
        {
            bool flag = true;
            string choose;
            Console.WriteLine("Choose availeble task. Please use only numbers to choose task:");
            Console.WriteLine("1. Show text.");
            Console.WriteLine("2. Display all sentences of the given text in ascending order of the number of words in each of them.");
            Console.WriteLine("3. Find and display words of a given length in interrogative sentences.");
            Console.WriteLine("4. Remove from the text all words of a given length starting with a consonant letter.");
            Console.WriteLine("5. In some sentence of the text, replace words of a given length with the specified substring");
            Console.WriteLine("6. Concordance");
            Console.WriteLine("7. Exit");
            while (flag)
            {
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        Output(Sentence.ReadText(path));
                        break;
                    case "2":
                        Output(SortSentences(path));
                        break;
                    case "3":
                        Console.WriteLine("Input the lenght of the word:");
                        Output(FindWord(path, Int32.Parse(Console.ReadLine())));
                        break;
                    case "4":
                        Console.WriteLine("Input the lenght of the word:");
                        Output(DeleteWords(path, Int32.Parse(Console.ReadLine())));
                        break;
                    case "5":
                        Console.WriteLine("Input the number of sentence:");
                        int lenght = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Input the word lenght you want to change:");
                        int word = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Input changed word:");
                        string chaged_word = Console.ReadLine();
                        Output(ChangeWord(path, lenght, word, chaged_word));
                        break;
                    case "6":
                        Concordance(path, result_path);
                        break;
                    case "7":
                        flag = false;
                        break;
                    case "8":
                        Console.WriteLine("Choose availeble task. Please use only numbers to choose task:");
                        Console.WriteLine("1. Show text.");
                        Console.WriteLine("2. Display all sentences of the given text in ascending order of the number of words in each of them.");
                        Console.WriteLine("3. Find and display words of a given length in interrogative sentences.");
                        Console.WriteLine("4. Remove from the text all words of a given length starting with a consonant letter.");
                        Console.WriteLine("5. In some sentence of the text, replace words of a given length with the specified substring");
                        Console.WriteLine("6. Exit");
                        break;
                    default:
                        Console.WriteLine("Wrong Input. Please Try Again");
                        Console.WriteLine("Enter '7' if you wanna see menu");
                        break;

                }
            }
        }

        static public Dictionary<string, List<int>> Map(string path)
        {
            Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();
            string[] buffer;
            int string_counter = -1;
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    buffer = sr.ReadLine().Split('.', ',', '!', '?', ';', '-', ' ');
                    string_counter++;
                    foreach (var word in buffer)
                    {
                        if (word != "")
                        {
                            if (!map.ContainsKey(word))
                            {
                                map.Add(word, new List<int>());
                            }
                                map[word].Add(string_counter);
                        }
                    }
                }
            }
            return map;
        }

        static public void Concordance(string path, string result_path)
        {
            Dictionary<string, List<int>> map = Map(path);
            List<string> keyList = new List<string>(map.Keys);
            using (StreamWriter sw = File.CreateText(result_path))
            {
                char letter = 'A';
                foreach (var pair in map.OrderBy(pair => pair.Key))
                {
                    string line = pair.Key + "............" + pair.Value.Count + ":";
                    if (pair.Key[0].ToString().ToUpper() != letter.ToString().ToUpper())
                    {
                        letter = pair.Key[0];
                        sw.WriteLine(letter.ToString().ToUpper());
                    }
                    for(int i = 0; i < pair.Value.ToArray().Length; i++)
                    {
                        if (i > 0)
                        {
                            if(pair.Value.ToArray()[i-1] != pair.Value.ToArray()[i])
                            {
                                line += " " + pair.Value.ToArray()[i];
                            }
                        }
                        else
                        {
                            line += " " + pair.Value.ToArray()[i];
                        }
                    }
                    Console.WriteLine(line);
                    sw.WriteLine(line);
                }
            }
        }

        static void Main(string[] args)
        {
            string path = "/Users/Asus/source/repos/Text Reader/Text Reader/War.txt";
            string result_path = "/Users/Asus/source/repos/Text Reader/Text Reader/Concordance.txt";
            Menu(path, result_path); 
        }
    }
}
