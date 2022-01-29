namespace Solver;

public interface IWordProvider
{
    string[] All();

    bool Exists(string word);
}
