using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Models
{
    public class GraphDTO
    {
        public AnketaGrafOcjena PrvoPitanje { get; set; }
        public AnketaGrafOcjena DrugoPitanje { get; set; }
        public AnketaGrafOcjena CetvrtoPitanje { get; set; }
        public AnketaGrafDaNe PetoPitanje { get; set; }
        public AnketaGrafDaNe SedmoPitanje { get; set; }
        public AnketaGrafSelect DesetoPitanje { get; set; }
    }
}
