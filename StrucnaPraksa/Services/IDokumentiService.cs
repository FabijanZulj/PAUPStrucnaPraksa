using Microsoft.AspNetCore.Http;
using StrucnaPraksa.Entities;
using StrucnaPraksa.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Services
{
    public interface IDokumentiService
    {
        List<PregledStudenata> getAllUserDocumentsAdmin(int godina);
        DokumentiModel getAllDokumentiForUser(string id);
        Anketa setAnketaForUser(string id, Anketa anketa);
        Anketa updateAnketa(Anketa anketa);
        Izvjesce setIzvjesceForUser(IFormFile izvjesceFile, string userId);
        int deleteIzvjesceForUser(string userId);
        int deleteDnevnikForUser(string userId);
        Dnevnik setDnevnikForUser(IFormFile dnevnikFile, string userId);
        Anketa getAnketaForUser(string id);
        Task<DownloadableFile> getIzvjesceForUser(string id);
        Task<DownloadableFile> getDnevnikForUser(string id);
    }
}
