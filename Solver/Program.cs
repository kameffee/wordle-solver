using System.Globalization;

namespace Solver;

class Program
{
    public static void Main(string[] args)
    {
        string path = "../../../../word_list.txt";

        if (args.Length > 0)
        {
            path = args[0];
        }

        ILogger logger = new Logger();
        IWordProvider wordDictionary = new WordDictionary(new WordLoader(path));
        UserWordInput userWordInput = new UserWordInput(wordDictionary, logger);
        UserResultInput userResultInput = new UserResultInput(logger);
        ResultOutput resultOutput = new ResultOutput();
        ConditionData conditionData = new ConditionData();
        CandidateCalculator candidateCalculator = new CandidateCalculator(wordDictionary);

        var wordList = wordDictionary.All();
        // logger.Log(string.Join(',', wordList));

        Console.Write("\n");

        for (int i = 0; i < 5; i++)
        {
            var inputWord = userWordInput.WaitWordInput(i + 1);
            logger.Log("");

            var inputResult = userResultInput.WaitResultInput().ToCharArray();
            CharacterResult[] characterResults = new CharacterResult[5];
            for (var i1 = 0; i1 < inputWord.Length; i1++)
            {
                char c = inputWord[i1];
                char num = inputResult[i1];
                ResultType type = (ResultType)int.Parse(num.ToString(), NumberStyles.None);
                characterResults[i1] = new CharacterResult(i1, type, c);
            }

            conditionData.Add(new WordResult(characterResults));

            // 確認
            logger.Log($"[{i}]:");
            resultOutput.Output(inputWord.ToCharArray(), inputResult);
            Console.Write("\n");
            logger.Log($"----候補----");
            var condidateWords = candidateCalculator.Calculate(conditionData);
            logger.Log(string.Join(',', condidateWords));
        }

        logger.Log("End");
    }
}
