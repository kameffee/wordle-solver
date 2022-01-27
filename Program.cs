using System.Text;
using System;
using System.IO;
using System.Text;
using System.Collections;


namespace Solver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> list = new List<string>();

            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine(Environment.SystemDirectory);
            using (var stream = new StreamReader("../../../word_list.txt", Encoding.UTF8))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    if (line.Length == 5)
                    {
                        list.Add(line);
                    }
                }
            }

            foreach (var word in list)
            {
                Console.Write(word + ",");
            }

            Console.WriteLine("End");
        }
    }
}
