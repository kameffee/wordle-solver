namespace Solver;

public class ConditionData
{
    public IEnumerable<WordResult> Results => _results;
    private Stack<WordResult> _results = new Stack<WordResult>();

    public ConditionData()
    {
    }

    public void Add(WordResult result)
    {
        _results.Push(result);
    }

    public void Reset()
    {
        _results.Clear();
    }
}
