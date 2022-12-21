using LapozasiAlgoritmusok.Algorithms;
using System.Text;

namespace LapozasiAlgoritmusok
{
    internal class Program
    {
        static Algorithm usedAlgorithm = Algorithm.None;
        static BaseAlgorithm algorithm;

        static void Main()
        {
            ChooseAlgorithm();
            CreateClass(ReadFile());
            algorithm.Start();
            Console.ReadKey();
        }

        private static void CreateClass(List<int> processes)
        {
            switch (usedAlgorithm)
            {
                case Algorithm.FIFO:
                    algorithm = new FIFO(processes);
                    break;
                default:
                    throw new NotImplementedException("Ezen algoritmus még nincs megvalósítva.");
            }
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
            List<int> processes = new List<int>();

            using StreamReader sr = new(@".\..\..\..\res\lapsor.txt", Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                string? value = sr.ReadLine();
                int page;

                if (!int.TryParse(value, out page))
                {
                    throw new Exception("Hibás érték került a lapsor.txt fájlba.");
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