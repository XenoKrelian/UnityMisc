using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Misc
{
    //https://www.youtube.com/watch?v=3Dw5d7PlcTM&ab_channel=SebastianLague
    //https://www.youtube.com/watch?v=WCm3TqScBM8&ab_channel=AlgorithmswithAttitude

    // Index from 1
    // i left = 2i
    // i right = 2i+1
    // parent = i/2

    // Index from 0
    // i left = 2i+1
    // i right = 2i+2
    // parent = (i-1)/2
    public class Heap<T> where T : IHeapItem<T>
    {
        T[] items;
        int currentItemCount;

        public Heap(int maxHeapSize)
        {
            items = new T[maxHeapSize];
        }

        public void Add(T item)
        {
            item.HeapIndex = currentItemCount;
            items[currentItemCount] = item;
            SortUp(item);
            currentItemCount++;
        }

        public T RemoveFirst() //Swap first with last, and sort the new first down
        {
            T firstItem = items[0];
            currentItemCount--;
            items[0] = items[currentItemCount];
            items[0].HeapIndex = 0;
            SortDown(items[0]);
            return firstItem;
        }

        public void UpdateItem(T item)
        {
            SortUp(item);
        }

        public int Count
        {
            get
            {
                return currentItemCount;
            }
        }

        public bool Contains(T item)
        {
            return Equals(items[item.HeapIndex], item);
        }

        public void SortDown(T item)
        {
            while (true)
            {
                int childIndexLeft = item.HeapIndex * 2 + 1;
                int childIndexRight = item.HeapIndex * 2 + 2;
                if (childIndexLeft < currentItemCount)
                {
                    int swapIndex = childIndexLeft;

                    if (childIndexRight < currentItemCount)
                    {
                        if (items[childIndexLeft].CompareTo(items[childIndexRight]) < 0)
                        {
                            swapIndex = childIndexRight;
                        }
                    }

                    if (item.CompareTo(items[swapIndex]) < 0)
                    {
                        Swap(item, items[swapIndex]);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public void SortUp(T item)
        {
            int parentIndex = (item.HeapIndex - 1) / 2;
            while (true)
            {
                T parentItem = items[parentIndex];
                if (item.CompareTo(parentItem) > 0)
                {
                    Swap(item, parentItem);
                }
                else
                {
                    break;
                }
                parentIndex = (item.HeapIndex - 1) / 2;
            }
        }

        public void Swap(T itemA, T itemB)
        {
            items[itemA.HeapIndex] = itemB;
            items[itemB.HeapIndex] = itemA;
            int itemAIndex = itemA.HeapIndex;
            itemA.HeapIndex = itemB.HeapIndex;
            itemB.HeapIndex = itemAIndex;
        }
    }

    public interface IHeapItem<T> : IComparable<T>
    {
        int HeapIndex { get; set; }

    }
}
