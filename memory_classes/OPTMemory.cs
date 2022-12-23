namespace LapozasiAlgoritmusok.memory_classes
{
    internal class OPTMemory : BaseMemory
    {
        private List<int> _processes;

        public OPTMemory(int capacity, List<int> processes)
        {
            _array = new int[capacity];
            _order = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                _order[i] = i + 1;
            }
            _processes = processes;
        }

        public override void InsertElement(int element, int place)
        {
            int numberOfEmptyMemoryPlaces = _array.Count(element => element == 0);
            Console.WriteLine(numberOfEmptyMemoryPlaces);
            if (numberOfEmptyMemoryPlaces > 0)
            {
                _array[Math.Abs(numberOfEmptyMemoryPlaces - 4)] = element;
                return;
            }

            UpdateOrder(place);

            List<int> list = _order.ToList();

            _array[list.IndexOf(list.Max())] = element;
        }

        public override void InsertElement(int element) => throw new NotImplementedException();

        private void UpdateOrder(int place)
        {
            List<int> unusedProcesses = _processes.GetRange(place, _processes.Count - place);

            for (int i = 0; i < _array.Length; i++)
            {
                _order[i] = unusedProcesses.IndexOf(_array[i]);
            }
        }
    }
}
