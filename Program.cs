namespace Solver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWordProvider wordDictionary = new WordDictionary();

            Console.WriteLine("Start");

            var wordList = wordDictionary.LoadWordList();
            foreach (var word in wordList)
            {
                Console.Write(word + ",");
            }
            
            Console.Write("\n");

            Console.WriteLine("End");
        }
    }
}
