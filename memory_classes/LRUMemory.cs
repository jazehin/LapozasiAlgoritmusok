using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapozasiAlgoritmusok.memory_classes
{
    internal class LRUMemory : BaseMemory
    {
        private List<int> _processes;

        public LRUMemory(int capacity, List<int> processes)
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
            List<int> usedProcesses = _processes.GetRange(0, place);
            List<int> order = new(4);

            for (int i = 0; i < _array.Length; i++)
            {
                order.Add(usedProcesses.LastIndexOf(_array[i]));
            }

            return order.IndexOf(order.Min());
        }
    }
}
