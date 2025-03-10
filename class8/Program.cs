using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class8
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;
            List<string> words = new List<string>();

            do{
                Console.Write("Please enter a word or type 'finish' to exit: ");
                word = Console.ReadLine();
                if (word.ToLower() != "finish")
                {
                    words.Add(word);
                }

            }while (word.ToLower() != "finish");

            Console.Write("The words you entered were: ");

            foreach (string w in words){
                Console.Write($"{w} ");
            }
        }
    }
}
