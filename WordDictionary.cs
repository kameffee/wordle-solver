namespace Solver;

public class WordDictionary : IWordProvider
{

    private readonly string[] _words;
    
    public WordDictionary(WordLoader wordLoader)
    {
        _words = wordLoader.Load();
    }

    public string[] All()
    {
        return _words;
    }
}