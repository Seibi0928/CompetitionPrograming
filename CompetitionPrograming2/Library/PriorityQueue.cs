using System;
using System.Collections.Generic;
using System.Linq;

namespace CompetitionPrograming2.Library
{
    public class PriorityQueue<T> : IEnumerable<T>, IReadOnlyCollection<T> where T : IComparable<T>
    {
        private readonly Priority priority;
        private List<T> heap = new List<T> { default(T) };

        private PriorityQueue() { }
        public PriorityQueue(Priority p)
        {
            priority = p;
        }
        public int Count => heap.Count - 1;
        public T Peek()
        {
            if (Count <= 0) { throw new Exception("要素が空です"); }
            return heap[1];
        }
        public T Dequeue()
        {
            if (Count <= 0) { throw new Exception("要素が空です"); }

            var max = heap[1];
            heap[1] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            MaxHeapify(1);
            return max;
        }
        public void Enqueue(T key)
        {
            HeapIncreaseKey(key);
        }
        public void EnqueueRange(IEnumerable<T> keys)
        {
            foreach (var key in keys) { HeapIncreaseKey(key); }
        }
        public void Clear()
        {
            heap = new List<T>() { default(T) };
        }
        private void MaxHeapify(int i)
        {
            int largest;
            int l = Left(i);
            int r = Right(i);

            if (l <= heap.Count - 1 && Compare(heap[i], heap[l]) < 0)
            {
                largest = l;
            }
            else
            {
                largest = i;
            }

            if (r <= heap.Count - 1 && Compare(heap[r], heap[largest]) > 0)
            {
                largest = r;
            }

            if (largest == i) { return; }

            var temp = heap[i];
            heap[i] = heap[largest];
            heap[largest] = temp;
            MaxHeapify(largest);
        }
        private void HeapIncreaseKey(T key)
        {
            heap.Add(key);
            int lastIndex = heap.Count - 1;
            while (lastIndex > 1 && Compare(heap[Parent(lastIndex)], heap[lastIndex]) < 0)
            {
                var temp = heap[lastIndex];
                heap[lastIndex] = heap[Parent(lastIndex)];
                heap[Parent(lastIndex)] = temp;
                lastIndex = Parent(lastIndex);
            }
        }
        private static int Parent(int i) => i / 2;
        private static int Left(int i) => i * 2;
        private static int Right(int i) => i * 2 + 1;
        private int Compare(T x, T y)
        {
            var isLarger = priority == Priority.Larger;
            if (typeof(string) == typeof(T))
            {
                return isLarger ? StringComparer.Ordinal.Compare(x, y) : StringComparer.Ordinal.Compare(y, x);
            }

            return isLarger ? x.CompareTo(y) : y.CompareTo(x);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => heap.Skip(1).GetEnumerator();
        public System.Collections.IEnumerator GetEnumerator()
        {
            return heap.Skip(0).GetEnumerator();
        }
    }
}
