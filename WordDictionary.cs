using System.Text;

namespace Solver;

public class WordDictionary : IWordProvider
{
    public string[] LoadWordList()
    {
        var list = new List<string>();
        using (var stream = new StreamReader("../../../word_list.txt", Encoding.UTF8))
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
