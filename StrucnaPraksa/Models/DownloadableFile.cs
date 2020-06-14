using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Models
{
    public class DownloadableFile
    {
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public string fileName { get; set; }
    }
}
