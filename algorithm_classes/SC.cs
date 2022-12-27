using LapozasiAlgoritmusok.memory_classes;

namespace LapozasiAlgoritmusok.algorithm_classes
{
    internal class SC : BaseAlgorithm
    {
        private bool[] _referenceBits;
        public SC(List<int> processes)
        {
            throw new NotImplementedException();
            _processes = processes;
            _numberOfPageFaults = 0;
            _memory = new FIFOMemory(_memoryPlaces);
            _referenceBits = new bool[_memoryPlaces];
            _place = 0;
        }

        protected override void Next()
        {
            Print();

            int process = _processes[_place];
            if (_memory.NumberOfNotZeroElements < _memoryPlaces || !_memory.Contains(process))
            {
                _memory.InsertElement(process);
                _numberOfPageFaults++;
                Print();
            }

            _place++;
        }
    }
}
