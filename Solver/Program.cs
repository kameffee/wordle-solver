namespace Solver;

class Program
{
    public static void Main(string[] args)
    {
        string path = "../../../word_list.txt";

        if (args.Length > 0)
        {
            path = args[0];
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("ERROR: ファイルが存在しません.");
            return;
        }

        SolveService solveService = new(path, new Logger());
        solveService.Run();
    }
}
