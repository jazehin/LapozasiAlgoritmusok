namespace LapozasiAlgoritmusok.memory_classes
{
    internal class SCMemory : BaseMemory
    {
        private int[] _order; //the order in which processes will be used e.g. [2, 3, 4, 1]
        public SCMemory(int capacity)
        {
            _array = new int[capacity];
            _order = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                _order[i] = i + 1;
            }
        }

        private List<int> AsList
        {
            get => _order.ToList();
        }

        public int IndexToInsertInto
        {
            get => AsList.IndexOf(1);
        }

        public int IndexOf(int element) => _array.ToList().IndexOf(element);

        public override void InsertElement(int element)
        {
            _array[AsList.IndexOf(1)] = element;

            UpdateOrder();
        }

        public void UpdateOrder()
        {
            for (int i = 0; i < _order.Length; i++)
            {
                if (_order[i] == 1) _order[i] = _order.Length;
                else _order[i]--;
            }
        }
    }
}
