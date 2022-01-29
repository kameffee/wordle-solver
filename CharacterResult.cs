namespace Solver;

public struct CharacterResult
{
    public int Index => _index;
    public ResultType Result => _result;
    public char Character => _charcter;

    private readonly int _index;
    private readonly ResultType _result;
    private readonly char _charcter;

    public CharacterResult(int index, ResultType result, char character)
    {
        _index = index;
        _result = result;
        _charcter = character;
    }
}
