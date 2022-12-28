namespace LapozasiAlgoritmusok.memory_classes
{
    internal abstract class BaseMemory
    {
        protected int[] _array; //the processes' numbers are stored here

        public int NumberOfNotZeroElements
        { 
            get => _array.Count(n => n != 0);
        }

        public int ElementAt(int index) => _array[index];
        public int IndexOf(int element) => _array.ToList().IndexOf(element);

        public bool Contains(int element) => _array.Contains(element);
        public virtual void InsertElement(int element) { }
        public virtual void InsertElement(int element, int place) { }
    }
}
