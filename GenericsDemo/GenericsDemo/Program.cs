using System;
using System.Collections.Generic;
using GenericHeap;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            MaxHeap<int> maxHeap = new MaxHeap<int>();

            minHeap.Add(5);
            minHeap.Pop();

            maxHeap.Add(26);
            maxHeap.Add(23);
            maxHeap.Pop();

            minHeap.Add(4);
            minHeap.Add(3);
            minHeap.Add(7);
            minHeap.Add(10);
            minHeap.Add(1);
            minHeap.Add(15);
            minHeap.Add(30);
            minHeap.Add(20);
            minHeap.Add(5);
            minHeap.Add(2);
            minHeap.Add(9);
            minHeap.Add(6);
            minHeap.Add(8);
            minHeap.Add(12);
            minHeap.Add(11);


            minHeap.Peek();
            minHeap.Pop();
            minHeap.Remove(10);

            for(int i = 20; i > 0; i--)
            {
                maxHeap.Add(i);
            }

            maxHeap.Peek();
            maxHeap.Pop();
            maxHeap.Remove(4);
            maxHeap.Remove(17);
            maxHeap.Add(25);
            maxHeap.Add(35);
            maxHeap.Add(30);
        }
    }
}
