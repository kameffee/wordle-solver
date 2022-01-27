namespace Solver;

public class UserWordInput
{
    private readonly ILogger _logger;

    public UserWordInput(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 施行したワードの入力待ち
    /// </summary>
    public string WaitWordInput()
    {
        // 入力待ち
        string? input = "";
        while (string.IsNullOrEmpty(input) || input.Length != 5)
        {
            _logger.Log($"施行した5文字のワード入力してください。");
            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 5)
            {
                _logger.LogError("ERROR: 入力エラー");
            }
        }

        return input;
    }

    /// <summary>
    /// 施行の結果を入力待ち
    /// </summary>
    public string WaitResultInput()
    {
        Console.WriteLine($"施行した結果を入力してください。 correct:[g],  wrong:[y], not: [n]");

        string? input = "";
        while (string.IsNullOrEmpty(input) || input.Length != 5 || !Validate(input))
        {
            _logger.Log($"施行した5文字のワード入力してください。");
            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 5)
            {
                _logger.LogError("ERROR: 入力エラー");
            }
            else if (!Validate(input))
            {
                _logger.LogError("ERROR: 入力エラー. 次のいずれかを5つ入力してください。[g,y,n]");
            }
        }

        return input;
    }

    // 許容されるコマンド文字
    private readonly char[] _commandChars = { 'g', 'y', 'n' };

    private bool Validate(string input)
    {
        foreach (var inputChar in input.ToCharArray())
        {
            // 入力コマンドチェック
            if (_commandChars.All(command => command != inputChar))
            {
                return false;
            }
        }

        return true;
    }
}
