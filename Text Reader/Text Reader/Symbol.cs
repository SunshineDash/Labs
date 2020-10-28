using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Reader
{
    class Symbol
    {
        static public void GetSymbols(string word, char[] symbols)
        {
            int i = 0;
            foreach (char c in word)
            {
                symbols[i] = c;
                i++;
            }
        }
    }
}
