using StrucnaPraksa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Services
{
    public interface IOsnovniPodaciService
    {
        OsnovniPodaci getPodaciById(string id);
        int setOsnovniPodaciForId(OsnovniPodaci podaci);
        IEnumerable<OsnovniPodaci> GetAll();
    }
}
