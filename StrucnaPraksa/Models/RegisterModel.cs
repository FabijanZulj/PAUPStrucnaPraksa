using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Models
{
    public class RegisterModel
    {
        [MinLength(5, ErrorMessage = "Korisnicko ime se mora sastojati od vise od 5 znakova")]
        public string Username { get; set; }
        [MinLength(5, ErrorMessage = "Lozinka se mora sastojati od vise od 5 znakova")]
        public string Password { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
    }
}
