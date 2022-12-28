using LapozasiAlgoritmusok.algorithm_classes;

namespace LapozasiAlgoritmusok
{
    internal class Program
    {
        static Option usedAlgorithm = Option.FIFO;
        static ComparisonType comparisonType = ComparisonType.RandomGenerált;
        static Restart runAgain = Restart.Nem;
        static BaseAlgorithm? algorithm = null;
        public static readonly int numberOfMemoryPlaces = 4;

        static void Main()
        {
            do {
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
                    comparisonType = (ComparisonType)Choose(typeof(ComparisonType), "Milyen módon szeretné őket összehasonlítani? (RandomGenerált -> 100 véletlenszerű folyamattal; ElőreMegadott)");
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
                    Console.WriteLine($"- {ExtendString(enumNames[i], longestNameLength)}{(choice == i ? " <" : "")}");
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

        private static string ExtendString(string str, int length)
        {
            for (int i = str.Length; i < length; i++)
            {
                str += ' ';
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