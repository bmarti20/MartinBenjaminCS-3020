using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace HW4GenericsAndInterfaces
{
    class Image : IMedia
    {
        public string Path { get; set; }
        public FileInfo File { get; set; }
        public string[] FileType { get; set; }
        public string MediaType { get; set; }
        public DateTime DateAdded { get; set; }

        public Image(string path, FileInfo file, string[] filetype, string[] mediatype)
        {
            Path = path;
            File = file;
            FileType = filetype;
            MediaType = mediatype[2];
            
        }
    }
}
