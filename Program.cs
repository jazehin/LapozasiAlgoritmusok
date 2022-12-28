using LapozasiAlgoritmusok.algorithm_classes;
using System.Linq.Expressions;
using System.Runtime.Versioning;

namespace LapozasiAlgoritmusok
{
    internal class Program
    {
        static Option usedAlgorithm = Option.FIFO;
        static ComparisonType comparisonType = ComparisonType.RandomGenerált;
        static Restart runAgain = Restart.Nem;
        static BaseAlgorithm? algorithm;
        static readonly int numberOfRandomProcesses = 1000;
        public static readonly int numberOfMemoryPlaces = 4;

        static void Main()
        {
            do {
                algorithm = null;
                usedAlgorithm = (Option)Choose(typeof(Option), "Válasszon lapcsere stratégiát:");
                RunAlgorithm(ReadFile());
                Console.WriteLine("\nFolyamat befejezve.");
                Console.ReadKey(false);

                runAgain = (Restart)Choose(typeof(Restart), "Szeretné újra lefuttatni a programot?");
            } while (runAgain == Restart.Igen);
        }

        private static void RunAlgorithm(List<int> processes)
        {
            switch (usedAlgorithm)
            {
                case Option.FIFO:
                    algorithm = new FIFO(processes);
                    break;
                case Option.OPT:
                    algorithm = new OPT(processes);
                    break;
                case Option.LRU:
                    algorithm = new LRU(processes);
                    break;
                case Option.SC:
                    algorithm = new SC(processes);
                    break;
                case Option.Összevetés:
                    comparisonType = (ComparisonType)Choose(typeof(ComparisonType), $"Milyen módon szeretné őket összehasonlítani?\n(Random generált -> {numberOfRandomProcesses} véletlenszerű folyamattal; Előre megadott -> a fájlban megadott folyamatlistával)");
                    Compare(comparisonType == ComparisonType.ElőreMegadott ? processes : new List<int>());
                    break;
                case Option.Kilépés:
                    Environment.Exit(0);
                    break;
                default:
                    throw new NotImplementedException("Ez a programrész még nincs megvalósítva.");
            }

            if (algorithm is null) return;
            algorithm.Start();
        }

        private static void Compare(List<int> processes)
        {
            // if the user chose random generation, generate the processes here
            if (processes.Count == 0)
            {
                Random rnd = new();
                for (int i = 0; i < numberOfRandomProcesses; i++)
                {
                    processes.Add(rnd.Next(1, 6));
                }
            }

            List<BaseAlgorithm> algorithms = GetAlgorithms(processes);
            List<int> pageFaults = new();
            List<double> times = new();

            foreach (var algorithm in algorithms)
            {
                DateTime startDate = DateTime.Now;
                pageFaults.Add(algorithm.Start());
                DateTime endDate = DateTime.Now;
                times.Add((endDate - startDate).TotalSeconds);
            }

            string algoNameString = "Algoritmus neve";
            string pageFaultString = "Laphibák száma";
            string requiredTimeString = "Szükséges idő (mp)";

            int algoNameLength = Math.Max(
                algorithms.Max(algorithm => algorithm.GetType().Name.Length), 
                algoNameString.Length);
            int pageFaultLength = Math.Max(
                pageFaults.Max(number => number.ToString().Length), 
                pageFaultString.Length);
            int requiredTimeLength = Math.Max(
                times.Max(time => time.ToString().Length),
                requiredTimeString.Length);

            Console.Clear();
            Console.WriteLine($"--{ExtendString("", algoNameLength, '-')}---{ExtendString("", pageFaultLength, '-')}---{ExtendString("", requiredTimeLength, '-')}--");
            Console.WriteLine($"| {ExtendString(algoNameString, algoNameLength, ' ')} | {ExtendString(pageFaultString, pageFaultLength, ' ')} | {ExtendString(requiredTimeString, requiredTimeLength, ' ')} |");

            for (int i = 0; i < algorithms.Count; i++)
            {
                Console.WriteLine($"|-{ExtendString("", algoNameLength, '-')}-|-{ExtendString("", pageFaultLength, '-')}-|-{ExtendString("", requiredTimeLength, '-')}-|");
                Console.WriteLine($"| {ExtendString(algorithms[i].GetType().Name, algoNameLength, ' ')} | {ExtendString(pageFaults[i].ToString(), pageFaultLength, ' ')} | {ExtendString(times[i].ToString(), requiredTimeLength, ' ')} |");
            }

            Console.WriteLine($"--{ExtendString("", algoNameLength, '-')}---{ExtendString("", pageFaultLength, '-')}---{ExtendString("", requiredTimeLength, '-')}--");

        }

        private static List<BaseAlgorithm> GetAlgorithms(List<int> processes)
        {
            List<BaseAlgorithm> list = new()
            {
                new FIFO(processes, true),
                new LRU(processes, true),
                new OPT(processes, true),
                new SC(processes, true)
            };

            return list;
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

        private static int Choose(Type type, string prompt)
        {
            int choice = 0;
            bool choosen = false;
            string[] enumNames = Enum.GetNames(type);

            for (int i = 0; i < enumNames.Length; i++)
            {
                if (enumNames[i].ToUpper() == enumNames[i]) continue;

                for (int j = 1; j < enumNames[i].Length; j++)
                {
                    string charAsString = enumNames[i][j].ToString();
                    if (charAsString.ToUpper() == charAsString)
                    {
                        enumNames[i] = $"{enumNames[i].Substring(0, j)} {charAsString.ToLower()}{enumNames[i].Substring(j + 1)}";
                    }
                }
            }

            int longestNameLength = enumNames.Max(element => element.Length);

            do {
                Console.Clear();
                Console.WriteLine(prompt);

                for (int i = 0; i < enumNames.Length; i++)
                {
                    Console.WriteLine($"- {ExtendString(enumNames[i], longestNameLength, ' ')}{(choice == i ? " <" : "")}");
                }

                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    choice--;
                    if (choice == -1) choice = enumNames.Length - 1;
                }
                else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    choice++;
                    if (choice == enumNames.Length) choice = 0;
                }
                else if (key == ConsoleKey.Spacebar || key == ConsoleKey.Enter)
                {
                    choosen = !choosen;
                }
            } while (!choosen);


            return choice;
        }

        private static string ExtendString(string str, int length, char character)
        {
            for (int i = str.Length; i < length; i++)
            {
                str += character;
            }

            return str;
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

    internal enum Option
    {
        FIFO,
        LRU,
        OPT,
        SC,
        Összevetés,
        Kilépés
    }

    internal enum ComparisonType
    {
        ElőreMegadott,
        RandomGenerált
    }

    internal enum Restart
    {
        Igen,
        Nem
    }
}