using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Entities
{
    public class Dnevnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdDnevnika { get; set; }
        [Required]
        public string IdUsera { get; set; }
        [Required]
        public string FileUrl { get; set; }
        [Required]
        public DateTime Godina { get; set; }
    }
}
