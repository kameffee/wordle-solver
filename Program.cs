namespace Solver;

class Program
{
    public static void Main(string[] args)
    {
        IWordProvider wordDictionary = new WordDictionary();
        UserWordInput userWordInput = new UserWordInput();

        Console.WriteLine("Start");

        var wordList = wordDictionary.LoadWordList();
        foreach (var word in wordList)
        {
            Console.Write(word + ",");
        }

        Console.Write("\n");

        var inputWord = userWordInput.WaitWordInput();
        Console.WriteLine($"InputWord: {inputWord}");

        var inputResult = userWordInput.WaitResultInput();

        // 確認
        Console.WriteLine($"--------");
        Console.WriteLine($"{inputWord}");
        Console.WriteLine($"{inputResult}");
        Console.WriteLine($"--------");

        Console.WriteLine("End");
    }
}
