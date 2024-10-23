using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.Files
{
    public class FileExtensionAttribute : Attribute
    {
        public string Extension { get; set; }
        public FileExtensionAttribute(string ext) 
        {
            this.Extension = ext;
        }
    }
}
