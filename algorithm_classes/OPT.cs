using LapozasiAlgoritmusok.memory_classes;

namespace LapozasiAlgoritmusok.algorithm_classes
{
    internal class OPT : BaseAlgorithm
    {
        public OPT(List<int> processes, bool runThrough = false)
        {
            _processes = processes;
            _numberOfPageFaults = 0;
            _memory = new OPTMemory(_memoryPlaces, _processes);
            _place = 0;
            _runThrough = runThrough;
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
