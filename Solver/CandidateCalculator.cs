namespace Solver;

/// <summary>
/// 候補計算
/// </summary>
public class CandidateCalculator
{
    private readonly IWordProvider _wordProvider;
    private readonly ILogger _logger;

    public CandidateCalculator(IWordProvider wordProvider, ILogger logger)
    {
        _wordProvider = wordProvider;
        _logger = logger;
    }

    public string[] Calculate(ConditionData conditionData)
    {
        char[] correctChars = new char[5];
        List<char>[] notList = new List<char>[5];

        for (var i = 0; i < notList.Length; i++)
        {
            notList[i] = new List<char>();
        }

        var wordResult = conditionData.Results;
        var correctResults = wordResult
            .SelectMany(result => result.CharacterResults)
            .Where(result => result.Result == ResultType.Correct)
            .Distinct();

        foreach (var result in correctResults)
        {
            correctChars[result.Index] = result.Character;
        }

        char[] wrongChars = wordResult
            .SelectMany(result => result.CharacterResults)
            .Where(result => result.Result == ResultType.Wrong)
            .Select(result => result.Character)
            .Distinct()
            .ToArray();

        // 一度黄色になった箇所は、その文字はその箇所ではNotとして登録
        foreach (var characterResult in wordResult
                     .SelectMany(result => result.CharacterResults)
                     .Where(result => result.Result == ResultType.Wrong).ToArray())
        {
            notList[characterResult.Index].Add(characterResult.Character);
        }

        _logger.Log("Wrond: " + string.Join(',', wrongChars));


        var notCharArray = wordResult
            .SelectMany(result => result.CharacterResults)
            .Where(result => result.Result == ResultType.Not)
            .Select(result => result.Character)
            .Distinct()
            .ToArray();

        // 全ての箇所にNotとして登録
        for (var i = 0; i < notList.Length; i++)
        {
            foreach (var c in notCharArray)
            {
                // 確定になっている場合はNotに入れない
                if (correctChars[i] == c)
                {
                    continue;
                }

                notList[i].Add(c);
            }
        }

        _logger.Log("Not: " + string.Join(',', notCharArray));

        return _wordProvider.All()
            .Where(word =>
            {
                char[] target = word.ToCharArray();

                // 1文字ずつ見ていく
                for (int i = 0; i < 5; i++)
                {
                    char correctChar = correctChars[i];

                    if (correctChar == '\0')
                        continue;

                    if (target[i] != correctChar)
                    {
                        return false;
                    }
                }

                if (notCharArray.Any())
                {
                    for (var i = 0; i < target.Length; i++)
                    {
                        var targetChar = target[i];
                        var isAny = notList[i].Any(c => c == targetChar);
                        if (isAny)
                        {
                            return false;
                        }
                    }
                }

                if (wrongChars.Any())
                {
                    // 含まれていなければいけない文字がなければ
                    if (!wrongChars.All(wrongChar => target.Any(c => c == wrongChar)))
                    {
                        return false;
                    }
                }


                return true;
            }).ToArray();
    }
}
