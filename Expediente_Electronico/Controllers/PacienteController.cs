using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Expediente_Electronico.Models;

namespace esExpediente_Electronico.Controllers
{
    public class PacienteController : Controller
    {
        private EMEPDB db = new EMEPDB();
        public static List<Paciente> listaPaciente = new List<Paciente>();
        Paciente obj = null;
        // GET: Paciente
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var paciente = db.Paciente.Include(p => p.Tipo_Usuario);
            foreach (var pacientes in paciente)
            {

                if (pacientes.estado == 1)
                {

                    pacientes.estado_String = "Activo";
                }
                if (pacientes.estado == 2)
                {
                    pacientes.estado_String = "Inactivo";

                }
            }
            return View(paciente.ToList());
        }

        public ActionResult Indexp()
        {

            string correoSesion = Session["CorreoId"].ToString();
            var pacientes = from m in db.Paciente
                            where m.correo == correoSesion
                            select m;

            foreach (var paciente in pacientes)
            {
                if (paciente.correo.Equals(correoSesion))
                {
                    if (paciente.estado == 1)
                    {

                        paciente.estado_String = "Activo";
                    }
                    if (paciente.estado == 2)
                    {
                        paciente.estado_String = "Inactivo";
                    }
                }
                pacientes.Include(paciente.ToString());
            }
            return View(pacientes.ToList());
        }


        // GET: Paciente/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Paciente.";
                return RedirectToAction("Indexp");
            }
            var paciente = db.Paciente.Where(x => x.cedula.Equals(id));
            foreach (var item in paciente)
            {
                obj = item;
                if (obj.estado == 1)
                {

                    obj.estado_String = "Activo";
                }
                if (obj.estado == 0)
                {
                    obj.estado_String = "Inactivo";
                }
            }

            if (obj == null)
            {
                TempData["mensaje"] = "No éxiste el Paciente.";
                return RedirectToAction("Indexp");
            }
            return View(obj);
        }


        // GET: Paciente/Create
        public ActionResult Create()
        {
            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Otro", Value = "Masculino" });
            ViewBag.Opcion = sexolist;
            ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion");
            return View();
        }

        // POST: Paciente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)
        {
            try
            {
                List<SelectListItem> sexolist = new List<SelectListItem>();
                sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "Masculino" });
                sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "Masculino" });
                sexolist.Add(new SelectListItem() { Text = "Otro", Value = "Masculino" });
                ViewBag.Opcion = sexolist;
                //listaPaciente.Add(paciente);
                paciente.ID_TIPO_USUARIO = 3;
                paciente.estado = 1;
                paciente.estado_String = "Activo";
                db.Paciente.Add(paciente);
                TempData["mensaje"] = "Paciente guardado con éxito.";
                db.SaveChanges();
                return RedirectToAction("indexp");

            }
            catch
            {
                ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion", paciente.ID_TIPO_USUARIO);
                return View(paciente);
            }
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(string id)
        {
            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Otro", Value = "Masculino" });
            ViewBag.Opcion = sexolist;
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Paciente.";
                return RedirectToAction("Indexp");
            }
            var paciente = db.Paciente.Where(x => x.cedula.Equals(id));
            foreach (var item in paciente)
            {
                obj = item;

                if (item == null)
                {
                    TempData["mensaje"] = "No exite el Paciente.";
                    return RedirectToAction("Indexp");
                }
                ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion", obj.ID_TIPO_USUARIO);

            }
            return View(obj);
        }

        // POST: Paciente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Otro", Value = "Masculino" });
            ViewBag.Opcion = sexolist;
            try
            {
                paciente.estado = 1;
                paciente.estado_String = "Activo";
                paciente.ID_TIPO_USUARIO = 3;
                db.Entry(paciente).State = EntityState.Modified;
              
                db.SaveChanges();
                
                TempData["mensaje"] = "Paciente Actualizado.";
                return RedirectToAction("Indexp");
            }
            catch
            {
                ViewBag.listaTipo = new SelectList(db.Tipo_Usuario, "id", "descripcion", paciente.ID_TIPO_USUARIO);
                return View(paciente);
            }
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Paciente.";
                return RedirectToAction("Indexp");
            }
            var paciente = db.Paciente.Where(x => x.cedula.Equals(id));
            foreach (var item in paciente)
            {
                obj = item;
            }
            if (paciente != null)
            {
                if (obj.estado == 1)
                {
                    obj.estado_String = "Activo";
                }
                else
                {
                    obj.estado_String = "Inactivo";
                }
            }
            if (obj == null)
            {
                TempData["mensaje"] = "No exite el Paciente.";
                return RedirectToAction("Indexp");
            }
            return View(obj);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var paciente = db.Paciente.Where(x => x.cedula.Equals(id));
            foreach (var item in paciente)
            {
                if (item.estado == 0)
                {
                    item.estado = 1;
                }
                else
                {
                    item.estado = 0;
                }
            }
            db.SaveChanges();
            TempData["mensaje"] = "Estado actualizado.";
            return RedirectToAction("Indexp");
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
