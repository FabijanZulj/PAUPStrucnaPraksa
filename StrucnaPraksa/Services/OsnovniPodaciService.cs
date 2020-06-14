using StrucnaPraksa.Entities;
using StrucnaPraksa.Helpers;
using StrucnaPraksa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Services
{
    public class OsnovniPodaciService : IOsnovniPodaciService
    {

        private readonly AppDbContext _podaciContext;



        public OsnovniPodaciService (AppDbContext podaciContext)
        {
            _podaciContext = podaciContext;
        }
        public IEnumerable<OsnovniPodaci> GetAll()
        {
            return _podaciContext.OsnovniPodaci;
        }

        public OsnovniPodaci getPodaciById(string id)
        {
            return _podaciContext.OsnovniPodaci.FirstOrDefault(x => x.IdUsera == id && x.Termin.Value.Year == DateTime.Now.Year);
        }

        public int setOsnovniPodaciForId(OsnovniPodaci podaci)
        {
            podaci.Termin = DateTime.Now;
            _podaciContext.OsnovniPodaci.Add(podaci);
            return _podaciContext.SaveChanges();
        }
    }
}
