using LapozasiAlgoritmusok.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LapozasiAlgoritmusok.Algorithms
{
    internal class FIFO : BaseAlgorithm
    {
        private QueueList _queue;
        public FIFO(List<int> pages)
        {
            _pages = pages;
            _numberOfPageFaults = 0;
            _queue = new();
            _place = -1;
        }

        private bool IsDone
        {
            get => _place >= _pages.Count;
        }
        public override void Start()
        {
            do
            {
                Next();
            } while (!IsDone);
        }

        protected override void Next()
        {
            Console.Clear();
            string algoText = $"{this.GetType().Name}: ";
            Console.WriteLine($"{algoText}{Program.ListToString(_pages)}");
            if (_place >= 0) 
            { 
                Console.SetCursorPosition(algoText.Length + _place * 3, Console.GetCursorPosition().Top);
                Console.WriteLine("^\n");

                
                Console.WriteLine("Memória:");
                for (int i = 0; i < _memoryPlaces; i++)
                {
                    Console.WriteLine($"{i + 1}. {_queue.GetElementAt(i)}");
                }

                if (_queue.Count < _memoryPlaces)
                {
                    _queue.Enqueue(_pages[_place]);
                }

                Console.WriteLine("Esemény: ");
            }
            else
            {
                Console.WriteLine("\n");
            }

            _place++;
            Console.ReadKey();
        }

    }
}
