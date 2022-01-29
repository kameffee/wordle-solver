namespace Solver;

public class WordResult
{
    public CharacterResult[] CharacterResults => _characterResults;
    private readonly CharacterResult[] _characterResults;

    public WordResult(CharacterResult[] characterResults)
    {
        _characterResults = characterResults;
    }
}