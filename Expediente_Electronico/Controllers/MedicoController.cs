using Expediente_Electronico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EMEP.Controllers
{
    public class MedicoController : Controller
    {
        private EMEPDB db = new EMEPDB();

        // GET: Medico
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var medicos = db.Medico.Include(m => m.Tipo_Usuario);

            foreach (var medico in medicos)
            {
                if (medico.estado == 1)
                {

                    medico.estado_String = "Activo";
                }
                if (medico.estado == 2)
                {
                    medico.estado_String = "Inactivo";
                }
            }
            return View(medicos.ToList());
        }
        public ActionResult IndexMe()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }

            string correoSesion = Session["CorreoId"].ToString();
            var medicos = from m in db.Medico
                          where m.correo == correoSesion
                          select m;

            foreach (var medico in medicos)
            {
                if (medico.correo.Equals(correoSesion))
                {
                    if (medico.estado == 1)
                    {

                        medico.estado_String = "Activo";
                    }
                    if (medico.estado == 2)
                    {
                        medico.estado_String = "Inactivo";
                    }
                }
                medicos.Include(medico.ToString());
            }
            return View(medicos.ToList());
        }

      

        // GET: Medico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el medico.";
                return RedirectToAction("Index");
            }
            Medico medico = db.Medico.Find(id);
            if (medico.estado == 1)
            {

                medico.estado_String = "Activo";
            }
            if (medico.estado == 2)
            {
                medico.estado_String = "Inactivo";
            }
            if (medico == null)
            {
                TempData["mensaje"] = "Medico no encotrado.";
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        public ActionResult DetailsMe(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el medico.";
                return RedirectToAction("Index");
            }
            Medico medico = db.Medico.Find(id);
            if (medico.estado == 1)
            {

                medico.estado_String = "Activo";
            }
            if (medico.estado == 2)
            {
                medico.estado_String = "Inactivo";
            }
            if (medico == null)
            {
                TempData["mensaje"] = "Medico no encontrado.";
                return RedirectToAction("Index");
            }
            return View(medico);
        }


        // GET: Medico/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion");
            return View();
        }

        // POST: Medico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medico medico)
        {
            medico.ID_TIPO_USUARIO = 2;
            if (ModelState.IsValid)
            {
                db.Medico.Add(medico);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito";
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
            return View(medico);
        }


        // GET: Medico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el medico.";
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {

                TempData["mensaje"] = "Medico no encontrado.";
            }
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
            return View(medico);
        }

        // POST: Medico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();

                TempData["mensaje"] = "Actualizado con éxito.";
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
            return View(medico);
        }


        public ActionResult EditMe(int? id)
        {
            if (id == null)
            {

                TempData["mensaje"] = "Especifique el medico.";
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {

                TempData["mensaje"] = "Medico no entontrado.";
            }
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
            return View(medico);
        }

        // POST: Medico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMe(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Actualizado con éxito.";
                return RedirectToAction("IndexMe");
            }
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
            return View(medico);
        }

        // GET: Medico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {

                TempData["mensaje"] = "Especifique el medico.";
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {

                TempData["mensaje"] = "Medico no encontrado.";
            }
            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medico.Find(id);
            if (medico.estado == 1)
            {
                medico.estado = 0;

            }
            else
            {
                medico.estado = 1;
            }
            db.SaveChanges();
            TempData["mensaje"] = "Estado Actualizado.";
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
