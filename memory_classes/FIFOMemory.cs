namespace LapozasiAlgoritmusok.memory_classes
{
    internal class FIFOMemory : BaseMemory
    {
        private int[] _order; //the order in which processes will be used e.g. [2, 3, 4, 1]
        public FIFOMemory(int capacity)
        {
            _array = new int[capacity];
            _order = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                _order[i] = i + 1;
            }
        }

        public override void InsertElement(int element)
        {
            List<int> list = _order.ToList();

            _array[list.IndexOf(1)] = element;

            for (int i = 0; i < _order.Length; i++)
            {
                if (_order[i] == 1) _order[i] = _order.Length;
                else _order[i]--;
            }
        }
    }
}
