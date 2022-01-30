namespace Solver;

public class ResultOutput
{
    private readonly IConsoleOutput _output;

    public ResultOutput(IConsoleOutput output)
    {
        _output = output;
    }

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
        _output.WriteCorrect(character);
    }

    private void Wrong(char character)
    {
        _output.WriteWrong(character);
    }

    private void Not(char character)
    {
        _output.WriteNot(character);
    }
}
