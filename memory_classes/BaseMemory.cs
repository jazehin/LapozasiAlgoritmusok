namespace LapozasiAlgoritmusok.memory_classes
{
    internal abstract class BaseMemory
    {
        protected int[] _array; //the processes' numbers are stored here
        protected int[] _order; //the order in which processes will be used e.g. [2, 3, 4, 1]

        public int Length { get => _array.Count(n => n != 0); }

        public int GetElementAt(int index) => _array[index];

        public bool Contains(int element) => _array.Contains(element);

        public virtual void InsertElement(int element) { }
        public virtual void InsertElement(int element, int place) { }
    }
}
