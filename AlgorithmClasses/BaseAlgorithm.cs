using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapozasiAlgoritmusok.Algorithms
{
    internal abstract class BaseAlgorithm
    {
        protected List<int> _pages;
        protected int _numberOfPageFaults;
        protected int _place;
        protected readonly int _memoryPlaces = 4;

        public int NumberOfPageFaults
        {
            get => _numberOfPageFaults;
        }

        protected virtual void Next() { }

        public virtual void Start() { }

        
    }
}
