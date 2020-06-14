using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StrucnaPraksa.Models;
using StrucnaPraksa.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Controllers
{
    [ApiController]
    [Route("/api/graph")]
    public class GraphsController : ControllerBase
    {
        private IGraphService _graphService;

        public GraphsController(IGraphService graphService)
        {
            _graphService= graphService;
        }

        [HttpGet("getGraphData")]
        [Authorize(Roles = Role.Admin)]
        public GraphDTO getGraphData(int godina)
        {
            return _graphService.getAllGraphData(godina);
        }

        [HttpGet("generatePrijavnicaUser")]
        [Authorize()]
        public async Task<IActionResult> generatePrijavnicaUser()
        {
            int userId = Convert.ToInt32(User.Claims.ElementAt(0).Value);
            DownloadableFile prijavnica = await _graphService.generatePrijavnica(userId);
            return File(prijavnica.Data, prijavnica.ContentType, prijavnica.fileName);
        }

        [HttpGet("generatePrijavnicaAdmin")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> generatePrijavnica(int userId)
        {
            DownloadableFile prijavnica = await _graphService.generatePrijavnica(userId);
            return File(prijavnica.Data, prijavnica.ContentType, prijavnica.fileName);
        }
    }
}
