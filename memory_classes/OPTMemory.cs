using System.Collections.Generic;

namespace LapozasiAlgoritmusok.memory_classes
{
    internal class OPTMemory : BaseMemory
    {
        private List<int> _processes;

        public OPTMemory(int capacity, List<int> processes)
        {
            _array = new int[capacity];
            _processes = processes;
        }

        public override void InsertElement(int element, int place)
        {
            int numberOfEmptyMemoryPlaces = _array.Count(element => element == 0);
            //Console.WriteLine(numberOfEmptyMemoryPlaces);
            if (numberOfEmptyMemoryPlaces > 0)
            {
                _array[Math.Abs(numberOfEmptyMemoryPlaces - 4)] = element;
                return;
            }

            int indexToChangeAt = GetIndexToChange(place);

            _array[indexToChangeAt] = element;
        }

        private int GetIndexToChange(int place)
        {
            List<int> unusedProcesses = _processes.GetRange(place, _processes.Count - place);
            List<int> order = new(4);

            for (int i = 0; i < _array.Length; i++)
            {
                int numberToAddToList = unusedProcesses.IndexOf(_array[i]) == -1 ? int.MaxValue : unusedProcesses.IndexOf(_array[i]);
                order.Add(numberToAddToList);
            }

            return order.IndexOf(order.Max());
        }
    }
}
