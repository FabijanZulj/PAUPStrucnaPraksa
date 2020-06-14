using StrucnaPraksa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Services
{
    public interface IGraphService
    {
        GraphDTO getAllGraphData(int godina);
        Task<DownloadableFile> generatePrijavnica(int userId);
    }
}
