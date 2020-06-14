using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Entities
{
    public class Izvjesce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdIzvjesca { get; set; }
        [Required]
        public string IdUsera { get; set; }
        [Required]
        public string FileUrl { get; set; }
        [Required]
        public DateTime Godina { get; set; }
    }
}
