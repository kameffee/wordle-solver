using System.Globalization;

namespace Solver;

public class SolveService
{
    private readonly ILogger _logger;
    private readonly IWordProvider _wordDictionary;
    private readonly UserWordInput _userWordInput;
    private readonly UserResultInput _userResultInput;
    private readonly ResultOutput _resultOutput = new();
    private readonly ConditionData _conditionData = new();
    private readonly CandidateCalculator _candidateCalculator;

    public SolveService(string path, ILogger logger)
    {
        _logger = logger;
        _wordDictionary = new WordDictionary(new WordLoader(path));
        _userWordInput = new UserWordInput(_wordDictionary, _logger);
        _userResultInput = new UserResultInput(_logger);
        _candidateCalculator = new CandidateCalculator(_wordDictionary);
    }

    public void Run()
    {
        var wordList = _wordDictionary.All();
        // logger.Log(string.Join(',', wordList));

        Console.Write("\n");

        for (int i = 0; i < 6; i++)
        {
            // ワード入力
            var inputWord = _userWordInput.WaitWordInput(i + 1);
            _logger.Log("");

            // 試行結果入力
            var inputResult = _userResultInput.WaitResultInput().ToCharArray();

            // 試行結果を作成
            CharacterResult[] characterResults = new CharacterResult[5];
            for (var i1 = 0; i1 < inputWord.Length; i1++)
            {
                char c = inputWord[i1];
                char num = inputResult[i1];
                ResultType type = (ResultType)int.Parse(num.ToString(), NumberStyles.None);
                characterResults[i1] = new CharacterResult(i1, type, c);
            }

            _conditionData.Add(new WordResult(characterResults));

            // 確認
            _logger.Log($"[{i}]:");
            _resultOutput.Output(inputWord.ToCharArray(), inputResult);
            Console.Write("\n");
            _logger.Log($"----候補----");
            var condidateWords = _candidateCalculator.Calculate(_conditionData);
            _logger.Log(string.Join(',', condidateWords));
        }
        
        _logger.Log("End");
    }
}
