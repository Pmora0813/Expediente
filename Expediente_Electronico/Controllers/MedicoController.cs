using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Expediente_Electronico.Models;

namespace Expediente_Electronico.Controllers
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
            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Otro", Value = "Masculino" });
            ViewBag.Opcion = sexolist;

            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion");
            return View();
        }

        // POST: Medico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medico medico)
        {

            try
            {
                List<SelectListItem> sexolist = new List<SelectListItem>();
                sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "1" });
                sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "2" });
                sexolist.Add(new SelectListItem() { Text = "Otro", Value = "3" });
                ViewBag.Opcion = sexolist;


                medico.ID_TIPO_USUARIO = 2;
                medico.estado = 1;
                medico.estado_String = "Activo";
                db.Medico.Add(medico);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito";
                return RedirectToAction("Index");
            }
            catch
            {

                ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
                return View(medico);
            }

        }

        // GET: Medico/Edit/5
        public ActionResult Edit(int? id)
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
            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "1" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "2" });
            sexolist.Add(new SelectListItem() { Text = "Otro", Value = "3" });
            ViewBag.Opcion = sexolist;
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
            return View(medico);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medico medico)
        {

            try
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();

                TempData["mensaje"] = "Medico actualizado.";
                return RedirectToAction("Index");
            }
            catch
            {
                List<SelectListItem> sexolist = new List<SelectListItem>();
                sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "1" });
                sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "2" });
                sexolist.Add(new SelectListItem() { Text = "Otro", Value = "3" });
                ViewBag.Opcion = sexolist;
                ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
                return View(medico);
            }
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
            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "1" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "2" });
            sexolist.Add(new SelectListItem() { Text = "Otro", Value = "3" });
            ViewBag.Opcion = sexolist;
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMe(Medico medico)
        {
            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "1" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "2" });
            sexolist.Add(new SelectListItem() { Text = "Otro", Value = "3" });
            ViewBag.Opcion = sexolist;
            try
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Actualizado con éxito.";
                return RedirectToAction("IndexMe");
            }
            catch
            {

                ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", medico.ID_TIPO_USUARIO);
                return View(medico);
            }
        }
        // GET: Medico/Delete/5
        public ActionResult Delete(int? id)
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
            db.SaveChanges();
            return RedirectToAction("Delete");
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
