namespace Solver;

public class UserWordInput
{
    /// <summary>
    /// 施行したワードの入力待ち
    /// </summary>
    public string WaitWordInput()
    {
        // 入力待ち
        string? input = "";
        while (string.IsNullOrEmpty(input) || input.Length != 5)
        {
            Console.WriteLine($"施行した5文字のワード入力してください。");
            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: 入力エラー");
                Console.ForegroundColor = ConsoleColor.White;
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
        while (string.IsNullOrEmpty(input) || input.Length != 5)
        {
            Console.WriteLine($"施行した5文字のワード入力してください。");
            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: 入力エラー");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        return input;
    }
}
