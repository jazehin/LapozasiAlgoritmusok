using LapozasiAlgoritmusok.algorithm_classes;

namespace LapozasiAlgoritmusok
{
    internal class Program
    {
        static Algorithm usedAlgorithm = Algorithm.None;
        static BaseAlgorithm? algorithm = null;
        public static readonly int numberOfMemoryPlaces = 4;

        static void Main()
        {
            ChooseAlgorithm();
            RunAlgorithm(ReadFile());
            Console.ReadKey(false);
        }

        private static void RunAlgorithm(List<int> processes)
        {
            switch (usedAlgorithm)
            {
                case Algorithm.FIFO:
                    algorithm = new FIFO(processes);
                    break;
                case Algorithm.OPT:
                    algorithm = new OPT(processes);
                    break;
                case Algorithm.LRU:
                    algorithm = new LRU(processes);
                    break;
                case Algorithm.SC:
                    algorithm = new SC(processes);
                    break;
                default:
                    throw new NotImplementedException("Ezen algoritmus még nincs megvalósítva.");
            }

            algorithm.Start();

            Console.WriteLine("\nFolyamat befejezve.");
        }

        public static string ListToString(List<int> list)
        {
            string temp = "";

            for (int i = 0; i < list.Count; i++)
            {
                temp += list[i] + (i == list.Count - 1 ? "" : ", ");
            }

            return temp;
        }

        private static void ChooseAlgorithm()
        {
            int choice = 0;
            string[] enumNames = Enum.GetNames(typeof(Algorithm));

            do
            {
                Console.Clear();
                Console.WriteLine("Válasszon lapcsere stratégiát/algoritmust:");

                for (int i = 1; i < enumNames.Length; i++)
                {
                    Console.WriteLine($"- {enumNames[i]}{(choice == i - 1 ? "\t<" : "")}");
                }

                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    choice--;
                    if (choice == -1) choice = enumNames.Length - 2;
                }
                else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    choice++;
                    if (choice == enumNames.Length - 1) choice = 0;
                }
                else if (key == ConsoleKey.Spacebar || key == ConsoleKey.Enter)
                {
                    usedAlgorithm = (Algorithm)(choice + 1);
                }

            } while (usedAlgorithm == Algorithm.None);


        }

        private static List<int> ReadFile()
        {
            List<int> processes = new();

            using StreamReader sr = new(@".\..\..\..\res\processes.txt", System.Text.Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                string? value = sr.ReadLine();

                if (!int.TryParse(value, out int page))
                {
                    throw new Exception("Hibás érték került a processes.txt fájlba.");
                }

                processes.Add(page);
            }

            return processes;
        }
    }

    internal enum Algorithm
    {
        None,
        FIFO,
        LRU,
        OPT,
        SC
    }
}