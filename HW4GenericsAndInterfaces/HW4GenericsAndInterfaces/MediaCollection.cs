using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HW4GenericsAndInterfaces
{
    public class MediaCollection<T>
    {
        List<T> queue = new List<T>();

        public MediaCollection()
        {
            
        }

        public void Enqueue(T val)
        {
            queue.Insert(0, val);
        }

        public T Dequeue()
        {
            T temp = queue[queue.Count - 1];
            queue.RemoveAt(queue.Count - 1);
            return temp;
        }

        public T Peek()
        {
            return queue[queue.Count - 1];
        }
    }
}
