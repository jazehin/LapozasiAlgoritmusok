using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapozasiAlgoritmusok.Type
{
    internal class QueueList : Queue<int>
    {
        public int GetElementAt(int index)
        {
            int[] array = this.ToArray();
            return (array.Length > index ? array[index] : 0);
        }
    }
}
