using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMEP.Models;

namespace EMEP.Controllers
{
    public class FumadorController : Controller
    {
        private EMEPEntities db = new EMEPEntities();
        // GET: Fumador
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var fumador = db.Fumador.Include(f => f.Expediente);
            return View(fumador.ToList());
        }

        // GET: Fumador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la condición.";
                return RedirectToAction("Index");
            }
            Fumador fumador = db.Fumador.Find(id);
            if (fumador != null)
            {
                if (fumador.activo == 1)
                {
                    fumador.estado_String = "Activo";
                }
                else
                {
                    fumador.estado_String = "Inactivo";
                }
            }
            if (fumador == null)
            {
                TempData["mensaje"] = "La condición no éxiste.";
                return RedirectToAction("Index");
            }
            return View(fumador);
        }

        // GET: Fumador/Create
        public ActionResult Create()
        {
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE");
            return View();
        }

        // POST: Fumador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fumador fumador)
        {
            try
            {
                fumador.activo = 1;
                db.Fumador.Add(fumador);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", fumador.ID_EXPEDIENTE);
                return View(fumador);
            }
        }

        // GET: Fumador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la condición.";
                return RedirectToAction("Index");
            }
            Fumador fumador = db.Fumador.Find(id);
            if (fumador != null)
            {
                if (fumador.activo == 1)
                {
                    fumador.estado_String = "Activo";
                }
                else
                {
                    fumador.estado_String = "Inactivo";
                }
            }
            if (fumador == null)
            {
                TempData["mensaje"] = "La condición no éxiste.";
                return RedirectToAction("Index");
            }
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", fumador.ID_EXPEDIENTE);
            return View(fumador);
        }

        // POST: Fumador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fumador fumador)
        {
            try
            {
                db.Entry(fumador).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Atualizado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {

                ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", fumador.ID_EXPEDIENTE);
                return View(fumador);
            }
        }

        // GET: Fumador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la condición.";
                return RedirectToAction("Index");
            }
            Fumador fumador = db.Fumador.Find(id);
            if (fumador != null)
            {
                if (fumador.activo == 1)
                {
                    fumador.estado_String = "Activo";
                }
                else
                {
                    fumador.estado_String = "Inactivo";
                }
            }
            if (fumador == null)
            {
                TempData["mensaje"] = "La condición no éxiste.";
                return RedirectToAction("Index");
            }
            return View(fumador);
        }

        // POST: Fumador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fumador fumador = db.Fumador.Find(id);
            if (fumador.activo == 0)
            {
                fumador.activo = 1;
            }
            else
            {
                fumador.activo = 0;
            }
            db.SaveChanges();
            TempData["mensaje"] = "Estado actualizado.";
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
