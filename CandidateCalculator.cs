namespace Solver;

/// <summary>
/// 候補計算
/// </summary>
public class CandidateCalculator
{
    private readonly IWordProvider _wordProvider;

    public CandidateCalculator(IWordProvider wordProvider)
    {
        _wordProvider = wordProvider;
    }

    public string[] Calculate(ConditionData conditionData)
    {
        char[] correctChars = new char[5];

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

        Console.WriteLine("Wrond: " + string.Join(',', wrongChars));

        char[] notChars = wordResult
            .SelectMany(result => result.CharacterResults)
            .Where(result => result.Result == ResultType.Not)
            .Select(result => result.Character)
            .Distinct()
            .ToArray();

        Console.WriteLine("Not: " + string.Join(',', notChars));

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

                if (notChars.Any())
                {
                    // 含まれてはいけない文字
                    if (target.Any(targetChar => notChars.Any(notChar => notChar == targetChar)))
                    {
                        return false;
                    }
                }

                if (wrongChars.Any())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        char targetChar = target[i];
                        // どこかに含まれる文字に当てはまるか 
                        if (wrongChars.Any(c => c == targetChar))
                        {
                            return true;
                        }
                    }

                    return false;
                }


                return true;
            }).ToArray();
    }
}
