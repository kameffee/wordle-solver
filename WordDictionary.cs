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

    public bool Exists(string word)
    {
        return _words.Any(s => s.Equals(word));
    }
}
