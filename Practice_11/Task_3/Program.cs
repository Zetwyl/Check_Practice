using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {
        class Word
        {
            public string Source { get; }
            public string Target { get; set; }
            public Word(string source, string target)
            {
                Source = source;
                Target = target;
            }
        }
        class Dictionary
        {
            Word[] words;
            public Dictionary()
            {
                words = new Word[]
                {
                    new Word("red", "красный"),
                    new Word("blue", "синий"),
                    new Word("green", "зеленый")
                };
            }


            public string this[string source]
            {
                get
                {
                    foreach (Word w in words)
                    {
                        if (w.Source == source)
                        {
                            return w.Target;
                        }
                    }
                    return null;
                }
                set
                {
                    foreach (Word w in words)
                    {
                        if (w.Source == source)
                        {
                            w.Target = value;
                            break;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var dict = new Dictionary();

            Console.WriteLine(dict["blue"]);
            dict["blue"] = "голубой";
            Console.WriteLine(dict["blue"]);
        }
    }
}
