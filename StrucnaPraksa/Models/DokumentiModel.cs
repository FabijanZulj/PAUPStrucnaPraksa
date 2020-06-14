using StrucnaPraksa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Models
{
    public class DokumentiModel
    {
        public int userId { get; set; }
        public Anketa Anketa { get; set; }
        public Izvjesce Izvjesce { get; set; }
        public Dnevnik Dnevnik { get; set; }
    }
}
