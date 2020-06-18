using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StrucnaPraksa.Entities;
using StrucnaPraksa.Models;
using StrucnaPraksa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Controllers
{
    [ApiController]
    [Route("/api/dokumenti")]
    public class DokumentiController : ControllerBase
    {
        private readonly ILogger<DokumentiController> _logger;
        private IDokumentiService _dokumentiService;

        public DokumentiController(ILogger<DokumentiController> logger, IDokumentiService dokumentiService)
        {
            _logger = logger;
            _dokumentiService = dokumentiService;
        }
        [HttpGet("getDocuments")]
        [Authorize()]
        public DokumentiModel getDocuments()
        {
            string userId = User.Claims.ElementAt(0).Value;   
            return _dokumentiService.getAllDokumentiForUser(userId);
        }

        [HttpGet("getIzvjesce")]
        [Authorize()]
        public async Task<IActionResult> getIzvjesce()
        {
            string userId = User.Claims.ElementAt(0).Value;
            DownloadableFile dlF = await _dokumentiService.getIzvjesceForUser(userId);
            return File(dlF.Data, dlF.ContentType, dlF.fileName);
        }

        [HttpPost("setIzvjesce")]
        [Authorize()]
        public Izvjesce setIzvjesce(IFormFile izvjesceFile)
        {

            string userId = User.Claims.ElementAt(0).Value;
            return _dokumentiService.setIzvjesceForUser(izvjesceFile, userId);
        }

        [HttpDelete("deleteIzvjesce")]
        [Authorize()]
        public int deleteIzvjesce()
        {

            string userId = User.Claims.ElementAt(0).Value;
            return _dokumentiService.deleteIzvjesceForUser(userId);
        }

        [HttpDelete("deleteDnevnik")]
        [Authorize()]
        public int deleteDnevnik()
        {

            string userId = User.Claims.ElementAt(0).Value;
            return _dokumentiService.deleteDnevnikForUser(userId);
        }


        [HttpPost("setDnevnik")]
        [Authorize()]
        public Dnevnik setDnevnik(IFormFile dnevnikFile)
        {

            string userId = User.Claims.ElementAt(0).Value;
            return _dokumentiService.setDnevnikForUser(dnevnikFile, userId);
        }


        [HttpPost("updateAnketa")]
        [Authorize()]
        public Anketa updateAnketa([FromBody]Anketa anketa)
        {
            string userId = User.Claims.ElementAt(0).Value;
            return _dokumentiService.updateAnketa(anketa);
        }



        [HttpPost("setAnketa")]
        [Authorize()]
        public Anketa setAnketa([FromBody]Anketa anketa)
        {
            string userId = User.Claims.ElementAt(0).Value;
            return _dokumentiService.setAnketaForUser(userId,anketa);
        }

        [HttpGet("getAnketa")]
        [Authorize()]
        public Anketa getAnketa()
        {
            string userId = User.Claims.ElementAt(0).Value;
            return _dokumentiService.getAnketaForUser(userId);
        }

        [HttpGet("getDnevnik")]
        [Authorize()]
        public async Task<IActionResult> getDnevnikAsync()
        {
            string userId = User.Claims.ElementAt(0).Value;
            DownloadableFile dlF = await _dokumentiService.getDnevnikForUser(userId);
            return File(dlF.Data, dlF.ContentType, dlF.fileName);
        }

        // ADMIN ENDPOINTS =========================================================================================================================

        [HttpGet("getDocumentsAdmin")]
        [Authorize(Roles = Role.Admin)]
        public List<PregledStudenata> getDocumentsAdmin(int godina)
        {
            return _dokumentiService.getAllUserDocumentsAdmin(godina);
        }

        [HttpGet("getIzvjesceAdmin")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> getIzvjesceAdmin(string userId)
        {
            DownloadableFile dlF = await _dokumentiService.getIzvjesceForUser(userId);
            return File(dlF.Data, dlF.ContentType, dlF.fileName);
        }
        [HttpGet("getAnketaAdmin")]
        [Authorize(Roles = Role.Admin)]
        public Anketa getAnketaAdmin(string userId)
        {
            return _dokumentiService.getAnketaForUser(userId);
        }
        [HttpGet("getDnevnikAdmin")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> getDnevnikAdmin(string userId)
        {
            DownloadableFile dlF = await _dokumentiService.getDnevnikForUser(userId);
            return File(dlF.Data, dlF.ContentType, dlF.fileName);
        }

    }
}
