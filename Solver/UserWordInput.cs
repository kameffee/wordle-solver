namespace Solver;

public class UserWordInput
{
    private readonly IWordProvider _wordProvider;
    private readonly ILogger _logger;

    public UserWordInput(IWordProvider wordProvider, ILogger logger)
    {
        _wordProvider = wordProvider;
        _logger = logger;
    }

    /// <summary>
    /// 施行したワードの入力待ち
    /// </summary>
    public string WaitWordInput(int phase)
    {
        // 入力待ち
        string? input = "";
        while (true)
        {
            _logger.Log($"{phase}回目に試行した5文字のワード入力してください。");
            input = Console.ReadLine();

            if (Validate(input))
            {
                break;
            }
           
        }

        return input;
    }

    public bool Validate(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            _logger.LogError("ERROR: 入力エラー. なにも入力されていません。");
            return false;
        }

        if (word.Length != 5)
        {
            _logger.LogError("ERROR: 入力エラー. アルファベット5文字で入力してください。");
            return false;
        }

        if (!_wordProvider.Exists(word))
        {
            _logger.LogError("ERROR: 存在しないワード");
            return false;
        }

        return true;
    }
}
