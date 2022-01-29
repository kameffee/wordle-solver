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

        var wordResult = conditionData.Results.First();
        var characterResult = wordResult.CharacterResults.Where(result => result.Result.HasFlag(ResultType.Correct));

        foreach (var result in characterResult)
        {
            correctChars[result.Index] = result.Character;
        }

        return _wordProvider.All()
            .Where(word =>
            {
                char[] target = word.ToCharArray();
                for (int i = 0; i < 5; i++)
                {
                    char correctChar = correctChars[i];
                    if (correctChar == '\0') continue;

                    if (target[i] != correctChar)
                    {
                        return false;
                    }
                }

                return true;
            }).ToArray();
    }
}
