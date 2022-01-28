namespace Solver;

class Program
{
    public static void Main(string[] args)
    {
        ILogger logger = new Logger();
        IWordProvider wordDictionary = new WordDictionary();
        UserWordInput userWordInput = new UserWordInput(logger);
        ResultOutput resultOutput = new ResultOutput();

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
        resultOutput.Output(inputWord.ToCharArray(), inputResult.ToCharArray());
        Console.Write("\n");
        logger.Log($"--------");

        logger.Log("End");
    }
}
