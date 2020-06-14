using StrucnaPraksa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Models
{
    public class PregledStudenata
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Anketa anketa { get; set; }

        public Dnevnik dnevnik { get; set; }
        public Izvjesce izvjesce { get; set; }

        public int idUsera { get; set; }
    }
}
