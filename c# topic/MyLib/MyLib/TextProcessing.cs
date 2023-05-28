using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLib
{
    public class TextProcessing
    {
        private static char[] Separators = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '"', '(', ')', '[', ']', '!' };
        public static Dictionary<string, int> myDicParallel(string inpText)
        {
            ConcurrentDictionary<string, int> myDic = new ConcurrentDictionary<string, int>();

            inpText = Regex.Replace(inpText, "<[^>]+>", string.Empty);

            string[] text = inpText.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

            Parallel.ForEach(text, word => myDic.AddOrUpdate(word.ToLower(), 1, (_, i) => ++i));

            return myDic.OrderByDescending(w => w.Value).ToDictionary(u => u.Key, u => u.Value);
        }


        private Dictionary<string, int> myDic(string inpText)
        {
            Dictionary<string, int> textDic = new Dictionary<string, int>();
            inpText = Regex.Replace(inpText, "<[^>]+>", string.Empty);

            string[] text = inpText.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in text)
            {
                if (!textDic.ContainsKey(word.ToLower()))
                {
                    textDic[word.ToLower()] = 1;
                }
                else
                {
                    textDic[word.ToLower()]++;
                }
            }

            return textDic.OrderByDescending(w=>w.Value).ToDictionary(u=>u.Key, u=>u.Value);

        }
    }
}
