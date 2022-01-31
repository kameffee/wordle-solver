using System.Runtime.InteropServices;

namespace Solver;

class Program
{
    public static void Main(string[] args)
    {
        // 同じ階層にあるテキストファイルを参照
        string path = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "word_list.txt");;

        if (args.Length > 0)
        {
            path = args[0];
        }

        if (!File.Exists(path))
        {
            Console.WriteLine($"ERROR: ファイルが存在しません.\n{path}");
            Environment.ExitCode = 1;
            return;
        }

        SolveService solveService = new(path, new Logger());
        solveService.Run();

        Environment.ExitCode = 0;
    }
}
