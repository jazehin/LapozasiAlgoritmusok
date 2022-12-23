namespace LapozasiAlgoritmusok.algorithm_classes
{
    internal abstract class BaseAlgorithm
    {
        protected List<int> _processes;
        protected int _numberOfPageFaults;
        protected int _place;
        protected readonly int _memoryPlaces = Program.numberOfMemoryPlaces;

        public int NumberOfPageFaults
        {
            get => _numberOfPageFaults;
        }

        protected virtual void Next() { }

        public virtual void Start() { }

        protected virtual void Print() { }
    }
}
