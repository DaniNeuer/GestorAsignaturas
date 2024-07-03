using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using GestorAsignaturas.DAL;
using GestorAsignaturas.Models;
namespace GestorAsignaturas.Controllers
{
    public class AsignaturaController : Controller
    {
        private GestorData bd = new GestorData();
        // GET: Asignatura
        public ActionResult Index()
        {
            return View(bd.Asignaturas.ToList());
        }
        //GET: Asignatura/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = bd.Asignaturas.Find(id);
            if(asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }
        //GET: Asignatura/Crear
        public ActionResult Crear()
        {
            return View();
        }
        //POST: Asignatura/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include ="ID,Nombre,Codigo,Creditos,Horas")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                bd.Asignaturas.Add(asignatura);
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignatura);
        }
        //GET: Asignatura/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = bd.Asignaturas.Find(id);
            if(asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }
        //POsT: Asignatura/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include ="ID,nombre,Codigo,Creditos,Horas")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                bd.Entry(asignatura).State=EntityState.Modified;
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignatura);
        }
    }
}