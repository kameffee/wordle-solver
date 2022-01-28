namespace Solver;

public class ResultOutput
{
    private readonly ConsoleColor _correctBackgroundColor = ConsoleColor.DarkGreen;
    private readonly ConsoleColor _correctForegroundColor = ConsoleColor.Black;

    private readonly ConsoleColor _wrongBackgroundColor = ConsoleColor.DarkYellow;
    private readonly ConsoleColor _wrongForegroundColor = ConsoleColor.Black;

    public void Output(char[] chars, char[] result)
    {
        for (var i = 0; i < chars.Length; i++)
        {
            var character = chars[i];
            var symbol = result[i];
            if (IsCorrect(symbol))
            {
                Correct(character);
            }
            else if (IsWrong(symbol))
            {
                Wrong(character);
            }
            else
            {
                Not(character);
            }
        }
    }

    private bool IsCorrect(char symbol)
    {
        return symbol == '2';
    }

    private bool IsWrong(char symbol)
    {
        return symbol == '1';
    }

    private void Correct(char character)
    {
        Console.BackgroundColor = _correctBackgroundColor;
        Console.ForegroundColor = _correctForegroundColor;
        Console.Write(character);
        Console.ResetColor();
    }

    private void Wrong(char character)
    {
        Console.BackgroundColor = _wrongBackgroundColor;
        Console.ForegroundColor = _wrongForegroundColor;
        Console.Write(character);
        Console.ResetColor();
    }

    private void Not(char character)
    {
        Console.Write(character);
    }
}