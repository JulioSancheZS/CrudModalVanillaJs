using CrudModalVanillaJs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudModalVanillaJs.Controllers
{
    public class PersonaController : Controller
    {
        PersonaDbContext db = new PersonaDbContext();
        // GET: Persona
        public ActionResult Index()
        {
           
            return View();
        }

        public JsonResult Lista()
        {

            List<PersonaViewModel> lista = db.Personas.Select(x => new PersonaViewModel
            {
                ID = x.PersonaID,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Edad = x.Edad
            }).ToList();


            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPersonaId(int Id)
        {
            Personas model = db.Personas.Where(x => x.PersonaID == Id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            //List<Personas> value = db.Personas.Where(x => x.PersonaID == Id)
            //    .Select(x => new Personas
            //    {
            //        Nombre = x.Nombre,
            //        Apellido = x.Apellido,
            //        Edad = x.Edad,
            //        PersonaID = x.PersonaID

            //    }).ToList();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Guardar(PersonaViewModel model)
        {
            var result = false;

            if (!ModelState.IsValid)
            {
                return Json(model);
            }

            try
            {
               
                if (model.ID > 0)
                    {
                        Personas oPersona = db.Personas.SingleOrDefault(x => x.PersonaID == model.ID);

                        oPersona.Nombre = model.Nombre;
                        oPersona.Apellido = model.Apellido;
                        oPersona.Edad = model.Edad;
                        db.Entry(oPersona).State = EntityState.Modified;
                        db.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        Personas oPersona = new Personas();
                        oPersona.Nombre = model.Nombre;
                        oPersona.Apellido = model.Apellido;
                        oPersona.Edad = model.Edad;
                        db.Personas.Add(oPersona);
                        db.SaveChanges();
                        result = true;
                    }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Eliminar(int Id)
        {
            bool result = false;
            try
            {

                Personas oPersona = db.Personas.SingleOrDefault(x => x.PersonaID == Id);

                if (oPersona != null)
                {
                    db.Personas.Remove(oPersona);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}