using System;
using System.Linq;
using System.Text;

namespace DataStructures.Tests
{
    //NOTE: This only uses the array as a holder of the data, any other
    //      methods or properties I implemented myself.
    //TODO: Modulus
    public class Queue<T>
    {
        const int _lengthMultiplier = 2;
        int _head;
        int _tail;
        int _queueSize = 10;
        T[] _internalArray;


        public Queue()
        {
             _internalArray = new T[_queueSize];
        }


        public void Enqueue(T itemToEnqeue)
        {
            SetHeadPosition();
            _internalArray[_head] = itemToEnqeue;
            _head++;
        }

        private void SetHeadPosition()
        {
            if (_head > _queueSize - 1 && Length < _queueSize)
                _head = 0;
            else
            {
                IncreaseQueueSize();
                _head++;
            }
        }

        private void IncreaseQueueSize()
        {
            _queueSize = _queueSize * 2;
            var newArray = new T[_queueSize];
            _internalArray.CopyTo(newArray, 0);
            _internalArray = newArray;
        }

        internal T Dequeue()
        {
            T returnObject = _internalArray[_tail];
            
            _tail++;

            if (_tail > _queueSize - 1)
                _tail = 0;

            return returnObject;
        }


        public int Length
        {
            get
            {
                return _head - _tail;
            }
        }

    }
}
