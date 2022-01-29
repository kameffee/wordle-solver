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
        char[] wrongChars;

        var wordResult = conditionData.Results.First();
        var characterResult = wordResult.CharacterResults.Where(result => result.Result.HasFlag(ResultType.Correct));

        foreach (var result in characterResult)
        {
            correctChars[result.Index] = result.Character;
        }

        wrongChars = wordResult.CharacterResults
            .Where(result => result.Result.HasFlag(ResultType.Wrong))
            .Select(result => result.Character)
            .ToArray();

        char[] notChars = wordResult.CharacterResults
            .Where(result => result.Result == (ResultType.Not))
            .Select(result => result.Character)
            .ToArray();

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
