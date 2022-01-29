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
        while (true)
        {
            _logger.Log($"試行した結果を入力してください。 correct:[2],  wrong:[1], not: [0]");
            input = Console.ReadLine();

            if (Validate(input))
            {
                break;
            }
        }

        return input;
    }

    public bool Validate(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            _logger.LogError("ERROR: 入力エラー. なにも入力されていません。");
            return false;
        }

        if (input.Length != 5)
        {
            _logger.LogError("ERROR: 入力エラー.");
            return false;
        }

        foreach (var inputChar in input.ToCharArray())
        {
            // 入力コマンドチェック
            if (_commandChars.All(command => command != inputChar))
            {
                _logger.LogError("ERROR: 入力エラー. 次のいずれかを5つ入力してください。[0,1,2]");
                return false;
            }
        }

        return true;
    }
}
