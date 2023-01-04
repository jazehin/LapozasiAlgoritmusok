using LapozasiAlgoritmusok.memory_classes;

namespace LapozasiAlgoritmusok.algorithm_classes
{
    internal class SC : BaseAlgorithm
    {
        private bool[] _referenceBits;
        public SC(List<int> processes, bool runThrough = false)
        {
            _processes = processes;
            _numberOfPageFaults = 0;
            _memory = new SCMemory(_memoryPlaces);
            _referenceBits = new bool[_memoryPlaces];
            for (int i = 0; i < _referenceBits.Length; i++)
            {
                _referenceBits[i] = true;
            }
            _place = 0;
            _runThrough = runThrough;
        }

        protected override void Next()
        {
            Print();

            int process = _processes[_place];
            if (_memory.NumberOfNotZeroElements < _memoryPlaces || !_memory.Contains(process))
            {
                int indexToInsertInto = (_memory as SCMemory).IndexToInsertInto;

                while (_referenceBits[indexToInsertInto])
                {
                    _referenceBits[indexToInsertInto] = false;
                    (_memory as SCMemory).UpdateOrder();
                    Print();
                    indexToInsertInto = (_memory as SCMemory).IndexToInsertInto;
                }

                _memory.InsertElement(process);
                _referenceBits[indexToInsertInto] = true;
                _numberOfPageFaults++;
                Print();
            }
            else if (_memory.Contains(process))
            {
                int indexToResetRefBit = _memory.IndexOf(process);
                _referenceBits[indexToResetRefBit] = true;
                Print();
            }

            _place++;
        }

        protected override void Print()
        {
            if (_runThrough) return;

            Console.Clear();
            string firstLineText = $"{this.GetType().Name}: {Program.ListToString(_processes)}";
            Console.WriteLine(firstLineText);

            int markerIndex = firstLineText.Length - 1;
            int numberOfCommas = 0;
            for (int i = 0; i < firstLineText.Length && markerIndex == firstLineText.Length - 1; i++)
            {
                if (firstLineText[i] == ',')
                {
                    if (numberOfCommas == _place)
                    {
                        markerIndex = i - 1;
                    }
                    else
                    {
                        numberOfCommas++;
                    }
                }
            }

            Console.SetCursorPosition(markerIndex, Console.GetCursorPosition().Top);
            Console.WriteLine("^\n");

            Console.WriteLine("Memória:");
            for (int i = 0; i < _memoryPlaces; i++)
            {
                Console.WriteLine($"{i + 1}. {_memory.ElementAt(i)} - referenciabit: {(_referenceBits[i] ? 1 : 0)}");
            }

            Console.WriteLine($"\nLaphibák száma: {_numberOfPageFaults}");

            Console.ReadKey();
        }
    }
}
