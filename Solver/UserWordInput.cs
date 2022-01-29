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
        while (string.IsNullOrEmpty(input) || input.Length != 5 || !ValidateWord(input))
        {
            _logger.Log($"{phase}回目に試行した5文字のワード入力してください。");
            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 5)
            {
                _logger.LogError("ERROR: 入力エラー");
            }
            else if (!ValidateWord(input))
            {
                _logger.LogError("ERROR: 存在しないワード");
            }
        }

        return input;
    }

    private bool ValidateWord(string word)
    {
        return _wordProvider.Exists(word);
    }
}
