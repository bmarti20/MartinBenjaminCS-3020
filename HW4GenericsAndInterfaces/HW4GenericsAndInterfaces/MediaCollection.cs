using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HW4GenericsAndInterfaces
{
    public enum FileType { WAV, MP3, MP4, AVI, MOV, PNG, JPG }
    public enum MediaType { Audio, Video, Image }
    interface IMedia
    {
        string Path { get; set; }
        FileInfo File { get; set; }
        FileType FileType { get; set; }
        MediaType MediaType { get; set; }
        DateTime DateAdded { get; set; }
    }

    public class MediaCollection<T> : IMedia
    {
        List<T> queue = new List<T>();

        public string Path { get; set; }
        public FileInfo File { get; set; }
        public FileType FileType { get; set; }
        public MediaType MediaType { get; set; }
        public DateTime DateAdded { get; set; }

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
