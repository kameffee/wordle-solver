namespace Solver;

public class ConsoleWrite : IConsoleOutput
{
    private readonly ConsoleColor _correctBackgroundColor = ConsoleColor.DarkGreen;
    private readonly ConsoleColor _correctForegroundColor = ConsoleColor.Black;

    private readonly ConsoleColor _wrongBackgroundColor = ConsoleColor.DarkYellow;
    private readonly ConsoleColor _wrongForegroundColor = ConsoleColor.Black;
    
    public void WriteCorrect(char str)
    {
        Console.BackgroundColor = _correctBackgroundColor;
        Console.ForegroundColor = _correctForegroundColor;
        Console.Write(str);
        Console.ResetColor();
    }
    
    public void WriteWrong(char str)
    {
        Console.BackgroundColor = _wrongBackgroundColor;
        Console.ForegroundColor = _wrongForegroundColor;
        Console.Write(str);
        Console.ResetColor();
    }
    
    public void WriteNot(char str)
    {
        Console.Write(str);
    }
}
