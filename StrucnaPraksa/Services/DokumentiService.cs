using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using StrucnaPraksa.Entities;
using StrucnaPraksa.Helpers;
using StrucnaPraksa.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StrucnaPraksa.Services
{
    public class DokumentiService : IDokumentiService
    {
        private readonly AppDbContext _dokumentiContext;
        private readonly IWebHostEnvironment _env;
        public DokumentiService(AppDbContext dokumentiContext, IWebHostEnvironment env)
        {
            _dokumentiContext = dokumentiContext;
            _env = env;
        }

        public DokumentiModel getAllDokumentiForUser(string id)
        {
            DokumentiModel dm = new DokumentiModel();
            Anketa anketa = _dokumentiContext.Ankete.FirstOrDefault(x => x.IdUsera == id && x.Godina.Year == DateTime.Now.Year);
            Izvjesce izvjesce = _dokumentiContext.Izvjesca.FirstOrDefault(x => x.IdUsera == id && x.Godina.Year == DateTime.Now.Year);
            Dnevnik dnevnik = _dokumentiContext.Dnevnici.FirstOrDefault(x => x.IdUsera == id && x.Godina.Year == DateTime.Now.Year);
            dm.Anketa = anketa;
            dm.Dnevnik = dnevnik;
            dm.Izvjesce = izvjesce;
            return dm;
        }

        public Anketa getAnketaForUser(string id)
        {
            Anketa an = _dokumentiContext.Ankete.FirstOrDefault(anketa => anketa.IdUsera == id);
            if (an == null) throw new ErrorDetails(403, "Anketu nije moguce pronaci za zadanog usera");
            return an;
        }



        public Anketa setAnketaForUser(string id, Anketa anketa)
        {
            anketa.IdUsera = id;
            anketa.Godina = DateTime.Now;
            _dokumentiContext.Ankete.Add(anketa);
            _dokumentiContext.SaveChanges();
            return anketa;
        }
       
        public async Task<DownloadableFile> getDnevnikForUser(string id)
        {

            Dnevnik dn = _dokumentiContext.Dnevnici.FirstOrDefault(dnevnik => dnevnik.IdUsera == id);

            return await getDownloadableFileForUrlAsync(dn.FileUrl);


        }



        public Dnevnik setDnevnikForUser(IFormFile dnevnikFile, string userId)
        {
            var folderName = Path.Combine("Resources", "Documents");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (dnevnikFile.Length > 0)
            {
                var fileName = "dnevnik_" + userId + ContentDispositionHeaderValue.Parse(dnevnikFile.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                System.Diagnostics.Debug.WriteLine("file name: ---------" + fileName);
                System.Diagnostics.Debug.WriteLine("full path: ---------" + fullPath);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    dnevnikFile.CopyTo(stream);
                }

                Dnevnik dn = new Dnevnik();
                dn.FileUrl = dbPath;
                dn.IdUsera = userId;
                dn.Godina = DateTime.Now;
                _dokumentiContext.Dnevnici.Add(dn);
                _dokumentiContext.SaveChanges();
                return dn;
            }
            return null;
        }

        public Izvjesce setIzvjesceForUser(IFormFile izvjesceFile, string userId)
        {
            var folderName = Path.Combine("Resources", "Documents");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (izvjesceFile.Length > 0)
            {
                var fileName = "izvjesce_"+ userId + ContentDispositionHeaderValue.Parse(izvjesceFile.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    izvjesceFile.CopyTo(stream);
                }

                Izvjesce iz = new Izvjesce();
                iz.FileUrl = dbPath;
                iz.IdUsera = userId;

                iz.Godina = DateTime.Now;
                _dokumentiContext.Izvjesca.Add(iz);
                _dokumentiContext.SaveChanges();
                return iz;
            }
            return null;
        }
        public async Task<DownloadableFile> getIzvjesceForUser(string id)
        {
            Izvjesce iz = _dokumentiContext.Izvjesca.FirstOrDefault(izvjesce => izvjesce.IdUsera == id);

            return await getDownloadableFileForUrlAsync(iz.FileUrl);
        }



        private async Task<DownloadableFile> getDownloadableFileForUrlAsync(string fileUrlFromDb)
        {
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(), fileUrlFromDb);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            DownloadableFile downloadableFile = new DownloadableFile();
            downloadableFile.Data = memory.ToArray();
            downloadableFile.ContentType = ContentTypeHelper.GetContentType(path);
            downloadableFile.fileName = Path.GetFileName(path);
            return downloadableFile;
        }

        public int deleteIzvjesceForUser(string userId)
        {
            Izvjesce izvj = _dokumentiContext.Izvjesca.FirstOrDefault(izvjesce => izvjesce.IdUsera == userId);
            if (izvj == null) throw new ErrorDetails(403, "Izvjesce nije moguce pronaci");
            _dokumentiContext.Remove(izvj);
            return _dokumentiContext.SaveChanges();
        }

        public int deleteDnevnikForUser(string userId)
        {
            Dnevnik dne = _dokumentiContext.Dnevnici.FirstOrDefault(dnevnik => dnevnik.IdUsera == userId);
            if (dne == null) throw new ErrorDetails(403, "Dnevnik nije moguce pronaci");
            _dokumentiContext.Remove(dne);
            return _dokumentiContext.SaveChanges();
        }

        public Anketa updateAnketa(Anketa anketa)
        {
            _dokumentiContext.Update(anketa);
            _dokumentiContext.SaveChanges();
            return anketa;
        }

        public List<PregledStudenata> getAllUserDocumentsAdmin(int godina)
        {
            List<PregledStudenata> allDocuments = new List<PregledStudenata>();
            List<User> allUsers = _dokumentiContext.Users.ToList();

            foreach(User user in allUsers)
            {
                PregledStudenata dm = new PregledStudenata();
                Anketa anketa = _dokumentiContext.Ankete.FirstOrDefault(x => Convert.ToInt32(x.IdUsera) == user.Id && x.Godina.Year == godina);
                Izvjesce izvjesce = _dokumentiContext.Izvjesca.FirstOrDefault(x => Convert.ToInt32(x.IdUsera) == user.Id && x.Godina.Year == godina);
                Dnevnik dnevnik = _dokumentiContext.Dnevnici.FirstOrDefault(x => Convert.ToInt32(x.IdUsera) == user.Id && x.Godina.Year == godina);
                dm.anketa = anketa;
                dm.dnevnik = dnevnik;
                dm.izvjesce = izvjesce;
                dm.Ime = user.Ime;
                dm.Prezime = user.Prezime;
                dm.idUsera = user.Id;
                allDocuments.Add(dm);
            }

            return allDocuments;
        }
    }
}
