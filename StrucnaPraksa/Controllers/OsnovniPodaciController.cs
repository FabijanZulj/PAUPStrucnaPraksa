using Microsoft.AspNetCore.Mvc;
using StrucnaPraksa.Entities;
using StrucnaPraksa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Controllers
{
    [ApiController]
    [Route("/api/osnovniPodaci")]
    public class OsnovniPodaciController : ControllerBase
    {
        private IOsnovniPodaciService _osnovniPodaciService;

        public OsnovniPodaciController(IOsnovniPodaciService osnovniPodaciService)
        {
            _osnovniPodaciService = osnovniPodaciService;
        }

        [HttpGet("getOsnovniPodaci/{id}")]
        public OsnovniPodaci GetOsnovniPodaci(string id)
        {
            return _osnovniPodaciService.getPodaciById(id);
        }
        [HttpPost("setOsnovniPodaci")]
        public int SetOsnovniPodaci(OsnovniPodaci podaci)
        {
            return _osnovniPodaciService.setOsnovniPodaciForId(podaci);
        }
    }
}
