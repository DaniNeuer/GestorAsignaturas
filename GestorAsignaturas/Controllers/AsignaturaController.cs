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
            // La accion index mandara las asignatorias enlistadas por el metodo ToList()
            return View(bd.Asignaturas.ToList());
        }
        //GET: Asignatura/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if(id == null)
            {
                // Si id es nulo, retorna un código de estado HTTP BadRequest (400)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // creamos un objeto del modelo asignatura y en ella almacenamos a la asignatura que se busca por el Find(id)
            Asignatura asignatura = bd.Asignaturas.Find(id);
            // Si la asignatura no existe, retorna un código de estado HTTP NotFound (404)
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }
        // GET: Asignatura/Crear
        public ActionResult Crear()
        {
            return View();
        }
        // sobrecarga usando los adornor [HttpPost] y con el [ValidateAntiForgeryToken] se usa para proteccion contra ataques
        // POST: Asignatura/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ID,Nombre,Codigo,Creditos,CD,CP,AA,Area")] Asignatura asignatura)
        {
            // Verifica si el estado del modelo es válido
            if (ModelState.IsValid)
            {
                // Agrega la nueva asignatura a la base de datos
                bd.Asignaturas.Add(asignatura);
                // Guarda los cambios en la base de datos
                bd.SaveChanges();
                // Redirige a la acción Index para mostrar la lista de asignaturas
                return RedirectToAction("Index");
            }
            // Si el estado del modelo no es válido, retorna la vista con los datos de la asignatura
            return View(asignatura);
        }
        // GET: Asignatura/Editar/5
        // Acción del controlador para mostrar la vista de edición de una asignatura existente
        public ActionResult Editar(int? id)
        {
            // Verifica si el parámetro id es nulo
            if (id == null)
            {
                // Si id es nulo, retorna un código de estado HTTP BadRequest (400)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Busca la asignatura en la base de datos usando el id proporcionado
            Asignatura asignatura = bd.Asignaturas.Find(id);
            // Verifica si la asignatura existe en la base de datos
            if (asignatura == null)
            {
                // Si la asignatura no existe, retorna un código de estado HTTP NotFound (404)
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: Asignatura/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ID,Nombre,Codigo,Creditos,CD,CP,AA,Area")] Asignatura asignatura)
        {
            // Verifica si el estado del modelo es válido
            if (ModelState.IsValid)
            {
                // Marca la entidad Asignatura como modificada en el contexto de datos
                bd.Entry(asignatura).State = EntityState.Modified;
                // Guarda los cambios en la base de datos
                bd.SaveChanges();
                // Redirige a la acción Index para mostrar la lista de asignaturas
                return RedirectToAction("Index");
            }
            // Si el estado del modelo no es válido, retorna la vista con los datos de la asignatura
            return View(asignatura);
        }

        //GET: Asignatura/Borrar/5
        // Acción del controlador para mostrar la vista de confirmación de borrado de una asignatura
        public ActionResult Borrar(int? id)
        {
            // Verifica si el parámetro id es nulo
            if (id == null)
            {
                // Si id es nulo, retorna un código de estado HTTP BadRequest (400)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Busca la asignatura en la base de datos usando el id proporcionado
            Asignatura asignatura = bd.Asignaturas.Find(id);
            if(asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }
        // POST: Asignatura/Borrar/5
        // Acción del controlador para manejar la confirmación del borrado de una asignatura
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarBorrar(int id)
        {
            // Busca la asignatura en la base de datos usando el id proporcionado
            Asignatura asignatura = bd.Asignaturas.Find(id);

            // Remueve la asignatura de la base de datos
            bd.Asignaturas.Remove(asignatura);

            // Guarda los cambios en la base de datos
            bd.SaveChanges();

            // Redirige a la acción Index para mostrar la lista de asignaturas
            return RedirectToAction("Index");
        }

        // Método para liberar los recursos utilizados por el contexto de datos
        protected override void Dispose(bool disposing)
        {
            // Si disposing es true, libera los recursos del contexto de datos
            if (disposing)
            {
                bd.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}