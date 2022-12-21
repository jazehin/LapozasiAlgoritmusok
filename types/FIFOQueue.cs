using LapozasiAlgoritmusok.types;

namespace LapozasiAlgoritmusok.Type
{
    internal class FIFOQueue : BaseQueue
    {
        public FIFOQueue(int capacity)
        {
            _array = new int[capacity];
            _order = new int[capacity];
            for (int i = 0; i < _order.Length; i++)
            {
                _order[i] = i + 1;
            }
        }

        public int Length
        {
            get => _array.Count(n => n != 0);
        }

        public int GetElementAt(int index) => _array[index];


        public bool Contains(int element) => _array.Contains(element);

        public void InsertElement(int element)
        {
            List<int> list = _order.ToList();

            _array[list.IndexOf(1)] = element;

            for (int i = 0; i < _order.Length; i++)
            {
                if (_order[i] == 1) _order[i] = 4;
                else _order[i]--;
            }

            


            /*
            int index = 0;
            while (_order[index] != 1) index++;

            _array[index] = element;
            _order[index] = 4;

            int secondaryIndex = 0;
            while (secondaryIndex == index || _order[secondaryIndex] != 4) secondaryIndex++;
            _order[secondaryIndex] = 3;

            index = secondaryIndex;
            secondaryIndex = 0;
            while (secondaryIndex == index || _order[secondaryIndex] != 3) secondaryIndex++;
            _order[secondaryIndex] = 2;

            index = secondaryIndex;
            secondaryIndex = 0;
            while (secondaryIndex == index || _order[secondaryIndex] != 2) secondaryIndex++;
            _order[secondaryIndex] = 1;
            */

        }




    }
}
