using System.Text;

namespace Solver;

public class WordDictionary : IWordProvider
{
    private readonly string _path;

    public WordDictionary(string path)
    {
        _path = path;
    }

    public string[] LoadWordList()
    {
        var list = new List<string>();
        using (var stream = new StreamReader(_path, Encoding.UTF8))
        {
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                if (line.Length == 5)
                {
                    list.Add(line);
                }
            }
        }

        return list.ToArray();
    }
}
