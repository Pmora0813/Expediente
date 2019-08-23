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
    public class CirugiaController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Cirugia
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var cirugia = db.Cirugia.Include(c => c.Expediente);
            return View(cirugia.ToList());
        }

        // GET: Cirugia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la cirugua.";
                return RedirectToAction("Index");
            }
            Cirugia cirugia = db.Cirugia.Find(id);

            if (cirugia == null)
            {
                TempData["mensaje"] = "La cirugia no éxiste.";
                return RedirectToAction("Index");

            }
            return View(cirugia);
        }

        // GET: Cirugia/Create
        public ActionResult Create()
        {
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE");
            return View();
        }

        // POST: Cirugia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cirugia cirugia)
        {
            try
            {
                db.Cirugia.Add(cirugia);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", cirugia.ID_EXPEDIENTE);
                return View(cirugia);
            }
        }

        // GET: Cirugia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la cirugua.";
                return RedirectToAction("Index");
            }
            Cirugia cirugia = db.Cirugia.Find(id);

            if (cirugia == null)
            {
                TempData["mensaje"] = "La cirugia no éxiste.";
                return RedirectToAction("Index");

            }
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", cirugia.ID_EXPEDIENTE);
            return View(cirugia);
        }

        // POST: Cirugia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cirugia cirugia)
        {
            try
            {
                db.Cirugia.Add(cirugia);
                db.SaveChanges();
                TempData["mensaje"] = "Actualizado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", cirugia.ID_EXPEDIENTE);
                return View(cirugia);
            }
        }

        // GET: Cirugia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la cirugua.";
                return RedirectToAction("Index");
            }
            Cirugia cirugia = db.Cirugia.Find(id);

            if (cirugia == null)
            {
                TempData["mensaje"] = "La cirugia no éxiste.";
                return RedirectToAction("Index");

            }
            return View(cirugia);
        }

        // POST: Cirugia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cirugia cirugia = db.Cirugia.Find(id);
            db.Cirugia.Remove(cirugia);
            db.SaveChanges();
            TempData["mensaje"] = "Eliminado con éxito.";
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
