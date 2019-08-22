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
    public class AdministradorController : Controller
    {
        private EMEPDB db = new EMEPDB();

        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var administrador = db.Administrador.Include(a => a.Tipo_Usuario);
            foreach (var item in administrador)
            {
                if (item.estado == 1)
                {

                    item.estado_String = "Activo";
                }
                if (item.estado == 0)
                {

                    item.estado_String = "Inactivo";
                }
            }
            return View(administrador.ToList());
        }

        // GET: Administrador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Administrador.";
                return RedirectToAction("Index");
            }
            Administrador administrador = db.Administrador.Find(id);
            if (administrador.estado == 1)
            {

                administrador.estado_String = "Activo";
            }
            if (administrador.estado == 0)
            {

                administrador.estado_String = "Inactivo";
            }
            if (administrador == null)
            {
                TempData["mensaje"] = "Administrador no encontrado.";
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion");
            return View();
        }

        // POST: Administrador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Administrador administrador)
        {

            try
            {
                administrador.estado = 1;
                db.Administrador.Add(administrador);
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", administrador.ID_TIPO_USUARIO);
                return View(administrador);
            }


        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                TempData["mensaje"] = "Especifique la Administrador.";
                return RedirectToAction("Index");
            }
            Administrador administrador = db.Administrador.Find(id);
            if (administrador.estado == 1)
            {

                administrador.estado_String = "Activo";
            }
            if (administrador.estado == 0)
            {

                administrador.estado_String = "Inactivo";
            }
            if (administrador == null)
            {
                TempData["mensaje"] = "Administrador no encontrado.";
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", administrador.ID_TIPO_USUARIO);
            return View(administrador);
        }

        // POST: Administrador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Administrador administrador)
        {
            try
            {
                db.Entry(administrador).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Actualizado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", administrador.ID_TIPO_USUARIO);
                return View(administrador);
            }

        }


        // GET: Administrador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la Administrador.";
                return RedirectToAction("Index");
            }
            Administrador administrador = db.Administrador.Find(id);
            if (administrador.estado == 1)
            {

                administrador.estado_String = "Activo";
            }
            if (administrador.estado == 0)
            {

                administrador.estado_String = "Inactivo";
            }
            if (administrador == null)
            {
                TempData["mensaje"] = "Administrador no encontrado.";
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador administrador = db.Administrador.Find(id);

            if (administrador.estado == 0)
            {
                administrador.estado = 1;
            }
            else
            {
                administrador.estado = 0;
            }
            db.SaveChanges();
            TempData["mensaje"] = "Estado actualizado.";
            return RedirectToAction("Index");
        }


        public ActionResult InicioSesion()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            return View();
        }
        [HttpPost]
        public ActionResult InicioSesion(Administrador ad)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            string correo = ad.correo;
            string contrasenna = ad.contraseña;

            try
            {
                
                    var administradorDB = db.Administrador.Where(a => a.correo.Equals(correo) && a.contraseña.Equals(contrasenna)).FirstOrDefault();
                    var medicoDB = db.Medico.Where(a => a.correo.Equals(correo) && a.contrasenna.Equals(contrasenna)).FirstOrDefault();
                    var pacienteDB = db.Paciente.Where(a => a.correo.Equals(correo) && a.contrasenna.Equals(contrasenna)).FirstOrDefault();
                    var pacienteASO = db.Paciente_Asociado.Where(a => a.correo.Equals(correo) && a.contrasenna.Equals(contrasenna)).FirstOrDefault();

                    if (administradorDB != null && administradorDB.estado == 1)
                    {
                        Session["CorreoId"] = administradorDB.correo.ToString();
                        return RedirectToAction("IndexAd", "Home");
                    }
                    if (medicoDB != null && medicoDB.estado == 1)
                    {
                        Session["CorreoId"] = medicoDB.correo.ToString();
                        return RedirectToAction("IndexMed", "Home");
                    }
                    if (pacienteDB != null && pacienteDB.estado == 1)
                    {
                        Session["CorreoId"] = pacienteDB.correo.ToString();
                        return RedirectToAction("IndexPa", "Home");
                    }
                    if (pacienteASO != null && pacienteASO.estado == 1)
                    {
                        Session["CorreoId"] = pacienteDB.correo.ToString();
                        return RedirectToAction("IndexPa_ASO", "Home");
                    }
                
                TempData["mensaje"] = "Datos invalidos, verifique";
                return View();
            }
            catch
            {
                TempData["mensaje"] = "Datos invalidos, verifique";
                return View(ad);
            }
        }

        public ActionResult RegistroPacientes()
        {
            ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion");
            return View();
        }
        [HttpPost]
        public ActionResult RegistroPacientes(Paciente paciente)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            bool encontrado = false;
            var Lista_Pacientes = db.Paciente.ToList();

            foreach (var item in Lista_Pacientes)
            {
                if (item.correo.Equals(paciente.correo))
                {
                    encontrado = true;
                }
            }

            if (encontrado)
            {
                TempData["mensaje"] = "Paciente se encuentra Registrado.";
            }
            else
            {
                try
                {

                    paciente.ID_TIPO_USUARIO = 3;
                    paciente.estado = 1;
                    db.Paciente.Add(paciente);
                    TempData["mensaje"] = "Paciente guardado con éxito.";
                    db.SaveChanges();
                    return RedirectToAction("InicioSesion");

                }
                catch
                {
                    ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion", paciente.ID_TIPO_USUARIO);

                }
            }
            return View(paciente);
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
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
