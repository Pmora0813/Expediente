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
    public class Paciente_AsociadoController : Controller
    {
        private EMEPDB db = new EMEPDB();
        Paciente_Asociado obj = null;
        Paciente_Dueño_Asociado pda = null;
        // GET: Paciente_Asociado
        public ActionResult Index()
        {
            string correoSesion = Session["CorreoId"].ToString();
            var pacientes = from m in db.Paciente_Asociado
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

        public ActionResult IndexASO()
        {
            string correoSesion = Session["CorreoId"].ToString();

            var duennoAso = db.Paciente_Dueño_Asociado.Where(x => x.ID_PACIENTE_DUE==correoSesion).ToList();

            var pacientes = db.Paciente_Asociado.ToList();
            var ListaAsociado = new List<Paciente_Asociado>();

            var ListaAsociado2 = new List<Paciente_Asociado>();
            foreach (var item in duennoAso)
            {
                foreach (var item2 in pacientes)
                {
                    if (item.ID_PACIENTE_DUE.Equals(item2.correo))
                    {
                        ListaAsociado.Add(item2);
                    }
                }
            }
            

            foreach (var paciente in ListaAsociado)
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
                ListaAsociado2.Add(paciente);
            }
            return View(ListaAsociado2.ToList());
        }

        // GET: Paciente_Asociado/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Paciente.";
                return RedirectToAction("Index");
            }
            var pacientes = db.Paciente_Asociado.Where(x => x.cedula.Equals(id));
            foreach (var item in pacientes)
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
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public ActionResult DetailsASO(string id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Paciente.";
                return RedirectToAction("Index");
            }
            var pacientes = db.Paciente_Asociado.Where(x => x.cedula.Equals(id));
            foreach (var item in pacientes)
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
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        // GET: Paciente_Asociado/Create
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

        // POST: Paciente_Asociado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente_Asociado paciente_Asociado)
        {

            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Otro", Value = "Masculino" });
            ViewBag.Opcion = sexolist;

            try
            {

                paciente_Asociado.estado = 1;
                paciente_Asociado.ID_TIPO_USUARIO = 4;
                paciente_Asociado.estado_String = "Activo";             
                db.Paciente_Asociado.Add(paciente_Asociado);
                db.SaveChanges();
                TempData["mensaje"] = "Paciente guardado con éxito.";
                obj = paciente_Asociado;

                pacienteDuenno_Asociado();
                return RedirectToAction("Index");

            }
            catch
            {

                ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", paciente_Asociado.ID_TIPO_USUARIO);
                return View(paciente_Asociado);
            }
        }

        private void pacienteDuenno_Asociado()
        {
            string correoDuenno = Session["CorreoId"].ToString();

            pda = new Paciente_Dueño_Asociado();
            pda.ID_PACIENTE_DUE = correoDuenno;
            pda.ID_PACIENTE_ASO = obj.correo;
            db.Paciente_Dueño_Asociado.Add(pda);
            db.SaveChanges();
        }

        // GET: Paciente_Asociado/Edit/5
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
                return RedirectToAction("Index");
            }
            var pacientes = db.Paciente_Asociado.Where(x => x.cedula.Equals(id));
            foreach (var item in pacientes)
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
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", obj.ID_TIPO_USUARIO);
            return View(obj);
        }

        // POST: Paciente_Asociado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente_Asociado paciente_Asociado)
        {
            List<SelectListItem> sexolist = new List<SelectListItem>();
            sexolist.Add(new SelectListItem() { Text = "Masculino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Femenino", Value = "Masculino" });
            sexolist.Add(new SelectListItem() { Text = "Otro", Value = "Masculino" });
            ViewBag.Opcion = sexolist;
            try
            {
                paciente_Asociado.estado = 1;
                paciente_Asociado.ID_TIPO_USUARIO = 4;
                paciente_Asociado.estado_String = "Activo";
                db.Entry(paciente_Asociado).State = EntityState.Modified;
                db.SaveChanges();

                TempData["mensaje"] = "Paciente Actualizado con éxito.";
                return RedirectToAction("Index");
            }
            catch
            {

                ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", paciente_Asociado.ID_TIPO_USUARIO);
                return View(paciente_Asociado);
            }
        }

        // GET: Paciente_Asociado/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique el Paciente.";
                return RedirectToAction("Index");
            }
            var pacientes = db.Paciente_Asociado.Where(x => x.cedula.Equals(id));
            foreach (var item in pacientes)
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
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // POST: Paciente_Asociado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            var paciente = db.Paciente_Asociado.Where(x => x.cedula.Equals(id));
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
            TempData["mensaje"] = "Se cambio estado correctante.";
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
