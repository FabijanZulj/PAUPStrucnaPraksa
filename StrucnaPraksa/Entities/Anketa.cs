using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Entities
{
    public class Anketa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdAnkete { get; set; }
        public string IdUsera { get; set; }
        [Required]
        public DateTime Godina { get; set; }
        [Required]
        public int Prvo { get; set; }
        [Required]
        public int Drugo { get; set; }
        [Required]
        public string Trece { get; set; }
        [Required]
        public int Cetvrto { get; set; }
        [Required]
        public string Peto { get; set; }
        public string Sesto { get; set; }
        [Required]
        public string Sedmo { get; set; }
        public string SedmoKomentar { get; set; }
        [Required]
        public string Osmo { get; set; }
        [Required]
        public string Deveto { get; set; }
        [Required]
        public string Deseto { get; set; }
        public string DesetoKomentar { get; set; }
        [Required]
        public string Jedanaesto { get; set; }
        [Required]
        public string Dvanaesto { get; set; }
    }
}
