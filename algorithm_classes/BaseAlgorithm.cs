using LapozasiAlgoritmusok.memory_classes;

namespace LapozasiAlgoritmusok.algorithm_classes
{
    internal abstract class BaseAlgorithm
    {
        protected BaseMemory _memory;
        protected List<int> _processes;
        protected int _numberOfPageFaults;
        protected int _place;
        protected readonly int _memoryPlaces = Program.numberOfMemoryPlaces;
        protected bool _runThrough;

        public int NumberOfPageFaults
        {
            get => _numberOfPageFaults;
        }

        private bool IsDone
        {
            get => _place >= _processes.Count;
        }
        public int Start()
        {
            do {
                Next();
            } while (!IsDone);
            return NumberOfPageFaults;
        }

        protected virtual void Print() 
        {
            if (_runThrough) return;

            Console.Clear();
            string algoText = $"{this.GetType().Name}: ";
            Console.WriteLine($"{algoText}{Program.ListToString(_processes)}");

            Console.SetCursorPosition(algoText.Length + _place * 3, Console.GetCursorPosition().Top);
            Console.WriteLine("^\n");

            Console.WriteLine("Memória:");
            for (int i = 0; i < _memoryPlaces; i++)
            {
                Console.WriteLine($"{i + 1}. {_memory.ElementAt(i)}");
            }

            Console.WriteLine($"\nLaphibák száma: {_numberOfPageFaults}");

            Console.ReadKey();
        }
        protected virtual void Next() { }
    }
}
