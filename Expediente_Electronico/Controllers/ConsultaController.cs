using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Expediente_Electronico.Models;

namespace Expediente_Electronico.Controllers
{
    public class ConsultaController : Controller
    {
        private EMEPDB db = new EMEPDB();

        // GET: Consulta EMEP
        public ActionResult Index(string dato, string buscar, string filtro, int? page)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }

            ViewBag.actual = dato;
            ViewBag.Medico1 = string.IsNullOrEmpty(dato) ? "medico" : "";
            ViewBag.Espe1 = dato == "Especialidad" ? "esp" : "Especialidad";

            if (buscar != null)
            {
                page = 1;
            }
            else
            {
                buscar = filtro;
            }

            ViewBag.filtroActual = buscar;

            var consulta = from co in db.Consulta
                           select co;
            if (!string.IsNullOrEmpty(buscar))
            {
                consulta = consulta.Where(co => co.Medico.nombre.Contains(buscar)
               || co.Medico.nombre.Contains(buscar)
               || co.Medico.p_Apellido.Contains(buscar)
               || co.Medico.s_Apellido.Contains(buscar)
               || co.Especialidad.descripcion.Contains(buscar)
               || co.Consultorio.numero.Contains(buscar)
               || co.precio.ToString().Contains(buscar));
            }

            switch (dato)
            {
                case "medico":
                    consulta = consulta.OrderByDescending(co => co.Medico.nombre);
                    break;
                case "Especialidad":
                    consulta = consulta.OrderBy(co => co.Especialidad.descripcion);
                    break;
                case "esp":
                    consulta = consulta.OrderByDescending(co => co.Especialidad.descripcion);
                    break;
                default:
                    consulta = consulta.OrderBy(co => co.Medico.nombre);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(consulta.ToPagedList(pageNumber, pageSize));
        }



        // GET: Consulta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique una consulta";
                return RedirectToAction("Index");
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                TempData["mensaje"] = "No existe la consulta";
                return RedirectToAction("Index");
            }
            return View("Details", consulta);
        }

        // GET: Consulta/Create
        public ActionResult Create()
        {
            ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion");
            ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion");
            ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM");
            return View("Create");
        }

        // POST: Consulta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consulta consulta)
        {

            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }

            
            var existe = from ex in db.Consulta
                         select ex;

            bool validar1 = existe.Any(ex => ex.ID_MEDICO== consulta.ID_MEDICO);           
            bool validar2 = existe.Any(ex => ex.ID_CONSULTORIO == consulta.ID_CONSULTORIO);
            bool validar3 = existe.Any(ex => ex.ID_ESPECIALIDAD == consulta.ID_ESPECIALIDAD);

            if (validar1 == true)
            {
               
                ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM",consulta.ID_MEDICO);
                ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion", consulta.ID_CONSULTORIO);
                ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion", consulta.ID_ESPECIALIDAD);
                TempData["mensaje"] = "El medico ya se encuantra ocupado. Seleccione otro Medico.";
                return View("Create", consulta);
            }


            if (validar2 == true)
            {
                ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM", consulta.ID_MEDICO);
                ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion", consulta.ID_CONSULTORIO);
                ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion", consulta.ID_ESPECIALIDAD);
                TempData["mensaje"] = "La consultorio ya se encuantra ocupado. Seleccione otro consultorio.";
                return View("Create", consulta);
            }

            if (validar3 == true) { 
            
               
                ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM", consulta.ID_MEDICO);
                ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion", consulta.ID_CONSULTORIO);
                ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion", consulta.ID_ESPECIALIDAD);
                TempData["mensaje"] = "La especialidad ya se encuantra ocupada. Seleccione otra especiallidad.";
                return View("Create", consulta);
            }

           

            try
            {
                db.Consulta.Add(consulta);
                db.SaveChanges();
                TempData["mensaje"] = "Consulta guardada satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch 
            {



                ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion", consulta.ID_CONSULTORIO);
                ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion", consulta.ID_ESPECIALIDAD);
                ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM", consulta.ID_MEDICO);
                TempData["mensaje"] = "Consulta NO registrada";
                return View("Create", consulta);
            }
        }

        // GET: Consulta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la consulta";
                return RedirectToAction("Index");
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                TempData["mensaje"] = "No existe la consulta";
                return RedirectToAction("Index");
            }
            ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion", consulta.ID_CONSULTORIO);
            ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion", consulta.ID_ESPECIALIDAD);
            ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM", consulta.ID_MEDICO);
            return View("Edit", consulta);
        }

        // POST: Consulta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Consulta consulta)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }

            try
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {
                TempData["mensaje"] = "El tour no se logro actualizar";
                ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion", consulta.ID_CONSULTORIO);
                ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion", consulta.ID_ESPECIALIDAD);
                ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM", consulta.ID_MEDICO);
                return View("Edit", consulta);
            }       
        }

        // GET: Consulta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consulta consulta = db.Consulta.Find(id);
            db.Consulta.Remove(consulta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}