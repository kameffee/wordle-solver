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
}
