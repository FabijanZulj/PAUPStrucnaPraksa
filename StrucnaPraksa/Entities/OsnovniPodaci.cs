using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Entities
{
    public class OsnovniPodaci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdPodataka { get; set; }
        [Required]
        public string IdUsera { get; set; }
        [Required]
        public string Studij { get; set; }
        public DateTime? Termin { get; set; }
        [Required]
        public string Poduzece { get; set; }
        [Required]
        public string NazivMentora { get; set; }
    }
}
