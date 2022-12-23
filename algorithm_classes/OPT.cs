using LapozasiAlgoritmusok.memory_classes;

namespace LapozasiAlgoritmusok.algorithm_classes
{
    internal class OPT : BaseAlgorithm
    {
        private OPTMemory _queue;
        public OPT(List<int> processes)
        {
            _processes = processes;
            _numberOfPageFaults = 0;
            _queue = new(_memoryPlaces, _processes);
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
            if (_queue.Length < _memoryPlaces || !_queue.Contains(process))
            {
                _queue.InsertElement(process, _place);
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
                Console.WriteLine($"{i + 1}. {_queue.GetElementAt(i)}");
            }

            Console.WriteLine($"\nLaphibák száma: {_numberOfPageFaults}");

            Console.ReadKey();
        }
    }
}
