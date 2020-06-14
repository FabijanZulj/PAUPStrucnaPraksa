using StrucnaPraksa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using GrapeCity.Documents.Html;
using StrucnaPraksa.Entities;
using StrucnaPraksa.Helpers;

namespace StrucnaPraksa.Services
{
    public class GraphService : IGraphService
    {
        private readonly AppDbContext _anketaContext;



        public GraphService(AppDbContext anketaContext)
        {
            _anketaContext = anketaContext;
        }
        public GraphDTO getAllGraphData(int godina)
        {
            string[] imenaOcjena = new string[] { "Jedan", "Dva", "Tri", "Cetiri", "Pet", "Sest", "Sedam", "Osam", "Devet", "Deset" };
            GraphDTO GraphData = new GraphDTO();
            AnketaGrafOcjena prvoPitanje = new AnketaGrafOcjena();
            prvoPitanje.Pitanje = "Koliko ste zadovoljni našim studentima na praksi? Ocijenite ocjenom od 1 do 10.";
            for (int i = 0; i < 10; i++)
            {
                prvoPitanje.GetType().GetProperty(imenaOcjena[i]).SetValue(prvoPitanje, _anketaContext.Ankete.Count(anketa => anketa.Prvo == i + 1 && anketa.Godina.Year == godina));
            }
            GraphData.PrvoPitanje = prvoPitanje;

            AnketaGrafOcjena drugoPitanje = new AnketaGrafOcjena();
            drugoPitanje.Pitanje = "Ocijenite znanje i kompetencije studenata na praksi. Ocijenite ocjenom od 1 do 10.";
            for (int i = 0; i < 10; i++)
            {
                drugoPitanje.GetType().GetProperty(imenaOcjena[i]).SetValue(drugoPitanje, _anketaContext.Ankete.Count(anketa => anketa.Drugo == i + 1 && anketa.Godina.Year == godina));
            }
            GraphData.DrugoPitanje = drugoPitanje;

            AnketaGrafOcjena cetvrtoPitanje = new AnketaGrafOcjena();
            cetvrtoPitanje.Pitanje = "Ocijenite opravdanost (važnost) stručnog studija na Međimurskom veleučilištu u Čakovcu? Ocijenite ocjenom od 1 do 10.";
            for (int i = 0; i < 10; i++)
            {
                cetvrtoPitanje.GetType().GetProperty(imenaOcjena[i]).SetValue(cetvrtoPitanje, _anketaContext.Ankete.Count(anketa => anketa.Cetvrto == i + 1 && anketa.Godina.Year == godina));
            }
            GraphData.CetvrtoPitanje = cetvrtoPitanje;

            AnketaGrafDaNe petoPitanje = new AnketaGrafDaNe();
            petoPitanje.Pitanje = "Smatrate li da treba povećati udio prakse kroz studij?";
            petoPitanje.Da = _anketaContext.Ankete.Count(anketa => anketa.Peto == "Da" && anketa.Godina.Year == godina);
            petoPitanje.Ne = _anketaContext.Ankete.Count(anketa => anketa.Peto == "Ne" && anketa.Godina.Year == godina);
            GraphData.PetoPitanje = petoPitanje;


            AnketaGrafDaNe sedmoPitanje = new AnketaGrafDaNe();
            sedmoPitanje.Pitanje = "Da li ste spremni prihvatiti studente na praksu u dužem razdoblju od trenutačno planirane?";
            sedmoPitanje.Da = _anketaContext.Ankete.Count(anketa => anketa.Sedmo == "Da" && anketa.Godina.Year == godina);
            sedmoPitanje.Ne = _anketaContext.Ankete.Count(anketa => anketa.Sedmo == "Ne" && anketa.Godina.Year == godina);
            GraphData.SedmoPitanje = sedmoPitanje;


            AnketaGrafSelect desetoPitanje = new AnketaGrafSelect();
            desetoPitanje.Pitanje = "Kako vidite gospodarstvo i naše studente za nekoliko godina?";
            desetoPitanje.odgovorA = _anketaContext.Ankete.Count(anketa => anketa.Deseto == "a" && anketa.Godina.Year == godina);
            desetoPitanje.odgovorB = _anketaContext.Ankete.Count(anketa => anketa.Deseto == "b" && anketa.Godina.Year == godina);
            desetoPitanje.odgovorC = _anketaContext.Ankete.Count(anketa => anketa.Deseto == "c" && anketa.Godina.Year == godina);
            desetoPitanje.odgovorD = _anketaContext.Ankete.Count(anketa => anketa.Deseto == "d" && anketa.Godina.Year == godina);
            GraphData.DesetoPitanje = desetoPitanje;

            return GraphData;

        }

        public void generateIzvjesce(string pdfPath, object dataObject)
        {
            var builder = new Stubble.Core.Builders.StubbleBuilder();
            string templatePath = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),"PDFTemplates", "prijavnicaTemplate.html"));
            var boundTemplate = builder.Build().Render(templatePath , dataObject );
            using(var re = new GcHtmlRenderer(boundTemplate))
            {
                re.RenderToPdf(pdfPath);
            }
        }
        public async Task<DownloadableFile> generatePrijavnica(int userId)
        {
            User user = _anketaContext.Users.FirstOrDefault(user => user.Id == userId);
            OsnovniPodaci op = _anketaContext.OsnovniPodaci.FirstOrDefault(podaci => podaci.IdUsera == userId.ToString());
            Anketa ank = _anketaContext.Ankete.FirstOrDefault(anketa => anketa.IdUsera == userId.ToString());
            Dnevnik dnv = _anketaContext.Dnevnici.FirstOrDefault(dnevnik => dnevnik.IdUsera == userId.ToString());
            Izvjesce izv = _anketaContext.Izvjesca.FirstOrDefault(izvjesce => izvjesce.IdUsera == userId.ToString());

            if (ank == null || dnv == null || izv == null)
            {
                throw new ErrorDetails(400, "Nisu predani svi dokumenti i nemoguce je generirati prijavnicu");
            }
            string pathToPossibleFile = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Prijavnice", $"{user.Id}.pdf");
            //string pathToPossibleFile = $"Resources/Prijavnice/{user.Id}.pdf";

            if (File.Exists(pathToPossibleFile))
            {
                File.Delete(pathToPossibleFile);
            }
            try
            {
                generateIzvjesce(pathToPossibleFile, new { Student = user.Ime + " " + user.Prezime, Studij = op.Studij, Mjesto = op.Poduzece, Vrijeme = op.Termin.Value.ToShortDateString(), Datum = DateTime.Now.ToShortDateString() }); ;
                return await getDownloadableFileForUrlAsync(pathToPossibleFile);
            }
            catch (Exception e)
            {
                throw new ErrorDetails(400, "Pogreska u generiranju prijavnice"+ e.Message + e.ToString()+ e.StackTrace);
            }
        }




        // HELPER 


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
    }
}
