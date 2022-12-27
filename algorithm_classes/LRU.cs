using LapozasiAlgoritmusok.memory_classes;

namespace LapozasiAlgoritmusok.algorithm_classes
{
    internal class LRU : BaseAlgorithm
    {
        public LRU(List<int> processes)
        {
            _processes = processes;
            _numberOfPageFaults = 0;
            _memory = new LRUMemory(_memoryPlaces, _processes);
            _place = 0;
        }

        protected override void Next()
        {
            Print();

            int process = _processes[_place];
            if (_memory.NumberOfNotZeroElements < _memoryPlaces || !_memory.Contains(process))
            {
                _memory.InsertElement(process, _place);
                _numberOfPageFaults++;
                Print();
            }

            _place++;
        }
    }
}
