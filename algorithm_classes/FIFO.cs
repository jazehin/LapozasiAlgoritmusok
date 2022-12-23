using LapozasiAlgoritmusok.memory_classes;

namespace LapozasiAlgoritmusok.algorithm_classes
{
    internal class FIFO : BaseAlgorithm
    {
        private FIFOMemory _memory;
        public FIFO(List<int> processes)
        {
            _processes = processes;
            _numberOfPageFaults = 0;
            _memory = new(_memoryPlaces);
            _place = 0;
        }

        private bool IsDone
        {
            get => _place >= _processes.Count;
        }
        public override void Start()
        {
            do
            {
                Next();
            } while (!IsDone);
        }

        protected override void Next()
        {
            Print();

            int process = _processes[_place];
            if (_memory.Length < _memoryPlaces || !_memory.Contains(process))
            {
                _memory.InsertElement(process);
                _numberOfPageFaults++;
                Print();
            }

            _place++;
        }

        protected override void Print()
        {
            Console.Clear();
            string algoText = $"{this.GetType().Name}: ";
            Console.WriteLine($"{algoText}{Program.ListToString(_processes)}");

            Console.SetCursorPosition(algoText.Length + _place * 3, Console.GetCursorPosition().Top);
            Console.WriteLine("^\n");

            Console.WriteLine("Memória:");
            for (int i = 0; i < _memoryPlaces; i++)
            {
                int processNumber = _memory.GetElementAt(i);
                Console.WriteLine($"{i + 1}. {(processNumber == 0 ? "-" : processNumber)}");
            }

            Console.WriteLine($"\nLaphibák száma: {_numberOfPageFaults}");

            Console.ReadKey();
        }

    }
}
