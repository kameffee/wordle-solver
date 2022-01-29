namespace Solver;

public class Logger : ILogger
{
    public void Log(string log)
    {
        Console.WriteLine(log);
    }

    public void LogError(string log)
    {
        var tmp = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(log);
        Console.ForegroundColor = tmp;
    }
}