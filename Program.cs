namespace Solver;

class Program
{
    public static void Main(string[] args)
    {
        ILogger logger = new Logger();
        IWordProvider wordDictionary = new WordDictionary();
        UserWordInput userWordInput = new UserWordInput(logger);

        logger.Log("Start");

        var wordList = wordDictionary.LoadWordList();
        foreach (var word in wordList)
        {
            Console.Write(word + ",");
        }

        logger.Log(string.Join(',', wordList));

        Console.Write("\n");

        var inputWord = userWordInput.WaitWordInput();
        logger.Log($"InputWord: {inputWord}");

        var inputResult = userWordInput.WaitResultInput();

        // 確認
        logger.Log($"--------");
        logger.Log($"{inputWord}");
        logger.Log($"{inputResult}");
        logger.Log($"--------");

        logger.Log("End");
    }
}
