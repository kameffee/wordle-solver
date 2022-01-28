namespace Solver;

class Program
{
    public static void Main(string[] args)
    {
        string path = "../../../word_list.txt";

        if (args.Length > 0)
        {
            path = args[0];
        }

        ILogger logger = new Logger();
        IWordProvider wordDictionary = new WordDictionary(new WordLoader(path));
        UserWordInput userWordInput = new UserWordInput(wordDictionary, logger);
        ResultOutput resultOutput = new ResultOutput();

        logger.Log("Start");

        var wordList = wordDictionary.All();
        
        // logger.Log(string.Join(',', wordList));

        Console.Write("\n");

        var inputWord = userWordInput.WaitWordInput();
        logger.Log("");

        var inputResult = userWordInput.WaitResultInput();

        // 確認
        logger.Log($"--------");
        resultOutput.Output(inputWord.ToCharArray(), inputResult.ToCharArray());
        Console.Write("\n");
        logger.Log($"--------");

        logger.Log("End");
    }
}
