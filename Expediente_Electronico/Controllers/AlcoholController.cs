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
    public class AlcoholController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Alcohol
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var alcohol = db.Alcohol.Include(a => a.Expediente);
            return View(alcohol.ToList());
        }

        // GET: Alcohol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la condición.";
                return RedirectToAction("Index");
            }
            Alcohol alcohol = db.Alcohol.Find(id);
            if (alcohol != null)
            {
                if (alcohol.activo == 1)
                {
                    alcohol.estado_String = "Activo";
                }
                else
                {
                    alcohol.estado_String = "Inactivo";
                }
            }
            if (alcohol == null)
            {
                TempData["mensaje"] = "La condición no éxiste.";
                return RedirectToAction("Index");
            }
            return View(alcohol);
        }

        // GET: Alcohol/Create
        public ActionResult Create()
        {
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE");
            return View();
        }

        // POST: Alcohol/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alcohol alcohol)
        {
            try
            {
                alcohol.activo = 1;
                db.Alcohol.Add(alcohol);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {

                ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", alcohol.ID_EXPEDIENTE);
                return View(alcohol);
            }
        }

        // GET: Alcohol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la condición.";
                return RedirectToAction("Index");
            }
            Alcohol alcohol = db.Alcohol.Find(id);
            if (alcohol != null)
            {
                if (alcohol.activo == 1)
                {
                    alcohol.estado_String = "Activo";
                }
                else
                {
                    alcohol.estado_String = "Inactivo";
                }
            }
            if (alcohol == null)
            {
                TempData["mensaje"] = "La condición no éxiste.";
                return RedirectToAction("Index");
            }
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", alcohol.ID_EXPEDIENTE);
            return View(alcohol);
        }

        // POST: Alcohol/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alcohol alcohol)
        {
            try
            {
                db.Entry(alcohol).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Atualizado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {

                ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", alcohol.ID_EXPEDIENTE);
                return View(alcohol);
            }
        }

        // GET: Alcohol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {

                TempData["mensaje"] = "Especifique la condición.";
                return RedirectToAction("Index");
            }
            Alcohol alcohol = db.Alcohol.Find(id);
            if (alcohol != null)
            {
                if (alcohol.activo == 1)
                {
                    alcohol.estado_String = "Activo";
                }
                else
                {
                    alcohol.estado_String = "Inactivo";
                }
            }
            if (alcohol == null)
            {
                TempData["mensaje"] = "La condición no éxiste.";
                return RedirectToAction("Index");
            }
            return View(alcohol);
        }

        // POST: Alcohol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alcohol alcohol = db.Alcohol.Find(id);
            if (alcohol.activo == 0)
            {
                alcohol.activo = 1;
            }
            else
            {
                alcohol.activo = 0;
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
