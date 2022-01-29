namespace Solver;

/// <summary>
/// 試行結果入力
/// </summary>
public class UserResultInput
{
    private readonly ILogger _logger;

    // 許容されるコマンド文字
    private readonly char[] _commandChars = { '2', '1', '0' };

    public UserResultInput(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 施行の結果を入力待ち
    /// </summary>
    public string WaitResultInput()
    {
        string? input = "";
        while (string.IsNullOrEmpty(input) || input.Length != 5 || !Validate(input))
        {
            _logger.Log($"試行した結果を入力してください。 correct:[2],  wrong:[1], not: [0]");
            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 5)
            {
                _logger.LogError("ERROR: 入力エラー");
            }
            else if (!Validate(input))
            {
                _logger.LogError("ERROR: 入力エラー. 次のいずれかを5つ入力してください。[0,1,2]");
            }
        }

        return input;
    }

    public bool Validate(string input)
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
