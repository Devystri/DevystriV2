using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Devystri.Model.Admin;
using Devystri.Modules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devystri.Pages.Admin
{
#if RELEASE
    [Authorize]
#endif
    public class AddInternetOfThingsModel : PageModel
    {
        [BindProperty]
        public IotImportModel Iot { get; set; }
        [BindProperty]
        public List<SectionImport> Sections { get; set; }
        [BindProperty]
        public List<IoT> ListIots { get; set; }

        public int Id { get; set; }

        public string Message { get; set; }
        public bool Success { get; set; }

        private ImageImport imageImport = new ImageImport("wwwroot/upload/iots/");
        private MyDbContext dbContext;

        public AddInternetOfThingsModel(MyDbContext context)
        {
            dbContext = context;
        }
        public void OnGet(int id = 0)
        {
            Id = id;
            LoadPage();
        }

        public void OnGetAddSection(int id)
        {
            var newSection = new Section();
            newSection.ProjectId = id;
            dbContext.Sections.Add(newSection);
            dbContext.SaveChanges();
            Id = id;
            LoadPage();
        }

        public void OnPost()
        {
            Id = Iot.Id;
            SaveApp();
            LoadPage();
        }

        public IActionResult OnPostDelete()
        {
            var form = HttpContext.Request.Form;
            foreach (var el in form)
            {
                if (el.Value[0] == "on")
                {
                    int id = int.Parse(el.Key);
                    dbContext.Iots.Remove((IoT)dbContext.Iots.First(item => item.Id == id));

                }
            }
            try
            {
                dbContext.SaveChanges();
                Success = true;
                Message = "L'objet a été supprimée avec succès.";
            }
            catch (Exception)
            {
                Message = "L'objet n'a pas pu être supprimé.";
            }
            return RedirectToPage("/Admin/AddInternetOfThings");
        }

        public void LoadPage()
        {
            ListIots = dbContext.Iots.ToList();

            if (Id == 0)
            {
                Iot = new IotImportModel();
                Sections = new List<SectionImport>();
            }
            else
            {
                if (ListIots.Exists(item => item.Id == Id))
                {

                    Iot = new IotImportModel(ListIots.First(item => item.Id == Id));
                    Sections = ImportTools.ToSectionImportList(dbContext.Sections.Where(item => item.ProjectId == Id).ToList());

                }
                else
                {
                    Sections = new List<SectionImport>();
                    Iot = new IotImportModel();
                    Id = 0;
                }
            }

        }

        public void SaveApp()
        {
            ListIots = dbContext.Iots.ToList();
            Success = false;
            if (ListIots.Exists(item => item.Id == Iot.Id))
            {
                var toEdit = ListIots.FirstOrDefault(item => item.Id == Iot.Id);
                if (toEdit != null)
                {
                    toEdit.Name = Iot.Name;
                    toEdit.Description = Iot.Description;
                    toEdit.Price = Iot.Price;
                    toEdit.PresentationRessourceName = ImportTools.ImageName(Iot.PresentationRessource, toEdit.PresentationRessourceName, imageImport);
                    toEdit.LogoName = ImportTools.ImageName(Iot.Logo, toEdit.LogoName, imageImport);
                    toEdit.Presentation2RessourceName = ImportTools.ImageName(Iot.Presentation2Ressource, toEdit.Presentation2RessourceName, imageImport);
                    toEdit.Presentation3RessourceName = ImportTools.ImageName(Iot.Presentation3Ressource, toEdit.Presentation3RessourceName, imageImport);
                    toEdit.Stat = Iot.State;
                    dbContext.Iots.Update(toEdit);
                    var sections = dbContext.Sections.Where(item => item.ProjectId == Id).ToList();
                    if(Sections is not null)
                    {
                        foreach (var item in Sections)
                        {

                            var el = sections.FirstOrDefault(el => item.Id == el.Id);
                            el.Description = item.Description;
                            el.ImageSrc = ImportTools.ImageName(item.Image, el.ImageSrc, imageImport);
                            el.Title = item.Title;
                            sections.Remove(sections.FirstOrDefault(sec => sec.Id == item.Id));

                            dbContext.Sections.Update(el);
                        }
                        foreach (var section in sections)
                        {
                            dbContext.Sections.Remove(dbContext.Sections.FirstOrDefault(item => item.Id == section.Id));
                        }
                    }
                    
                    Success = true;
                    Message = "Les modifications ont été apportés avec succès.";

                }
                else
                {
                    Success = true;
                    Message = "Impossible de modifier cet objet pour une raison inconnue.";
                }


            }
            else
            {
                var empty = new IotImportModel();

                if (Iot == empty)
                {
                    Success = false;
                    Message = "Impossible d'ajouter un objet connecté sans informations.";
                    return;
                }
                var iot = Iot.ToIot();
                dbContext.Iots.Add(iot);
                Message = "L'objet a correctement été ajouté.";
                Success = true;

            }
            if (!imageImport.Import(HttpContext.Request.Form.Files))
            {
                Message = "Impossible d'ajouter les nouveaux fichiers pour une raison inconnue.";
                Success = false;
                return;
            }
            try
            {
                dbContext.SaveChanges();
                Success = true;

            }
            catch (Exception)
            {
                Success = false;
                Message = "Impossible de sauvegarder les modifications pour une raison inconnue.";
            }
        }
    }
}
