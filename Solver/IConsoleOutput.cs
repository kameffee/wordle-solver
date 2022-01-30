namespace Solver;

public interface IConsoleOutput
{
    void WriteCorrect(char str);
    void WriteWrong(char str);
    void WriteNot(char str);
}