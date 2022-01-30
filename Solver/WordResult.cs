using System.Globalization;

namespace Solver;

public class WordResult
{
    public CharacterResult[] CharacterResults => _characterResults;
    public string Word => _word;

    private readonly string _word;
    private readonly CharacterResult[] _characterResults;

    public WordResult(CharacterResult[] characterResults)
    {
        _characterResults = characterResults;
        _word = new(characterResults.Select(result => result.Character).ToArray());
    }

    /// <param name="inputWord">eg. stamp</param>
    /// <param name="inputResult">eg. 11002</param>
    public WordResult(string inputWord, string inputResult)
    {
        // 試行結果を作成
        _characterResults = new CharacterResult[5];
        for (var i1 = 0; i1 < inputWord.Length; i1++)
        {
            char c = inputWord[i1];
            char num = inputResult[i1];
            ResultType type = (ResultType)int.Parse(num.ToString(), NumberStyles.None);
            _characterResults[i1] = new CharacterResult(i1, type, c);
        }
    }
}
