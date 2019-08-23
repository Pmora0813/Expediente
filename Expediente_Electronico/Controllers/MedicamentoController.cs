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
    public class MedicamentoController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Medicamento
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var medicamento = db.Medicamento.Include(m => m.Expediente);
            return View(medicamento.ToList());
        }

        // GET: Medicamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el medicamento.";
                return RedirectToAction("Index");
            }
            Medicamento medicamento = db.Medicamento.Find(id);

            if (medicamento == null)
            {
                TempData["mensaje"] = "El medicamento no éxiste.";
                return RedirectToAction("Index");
            }
            return View(medicamento);
        }

        // GET: Medicamento/Create
        public ActionResult Create()
        {
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE");
            return View();
        }

        // POST: Medicamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medicamento medicamento)
        {
            try
            {
                db.Medicamento.Add(medicamento);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", medicamento.ID_EXPEDIENTE);
                return View(medicamento);

            }
        }

        // GET: Medicamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el medicamento.";
                return RedirectToAction("Index");
            }
            Medicamento medicamento = db.Medicamento.Find(id);
            if (medicamento == null)
            {
                TempData["mensaje"] = "El medicamento no éxiste.";
                return RedirectToAction("Index");
            }
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", medicamento.ID_EXPEDIENTE);
            return View(medicamento);
        }

        // POST: Medicamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamento).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Atualizado con éxito.";
                return RedirectToAction("Index");
            }
            ViewBag.ID_EXPEDIENTE = new SelectList(db.Expediente, "id", "ID_PACIENTE", medicamento.ID_EXPEDIENTE);
            return View(medicamento);
        }

        // GET: Medicamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el medicamento.";
                return RedirectToAction("Index");
            }
            Medicamento medicamento = db.Medicamento.Find(id);
            if (medicamento == null)
            {
                TempData["mensaje"] = "El medicamento no éxiste.";
                return RedirectToAction("Index");
            }
            return View(medicamento);
        }

        // POST: Medicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicamento medicamento = db.Medicamento.Find(id);
            db.Medicamento.Remove(medicamento);
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
