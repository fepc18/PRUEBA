using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.ActivosFijos;
using Financy.Models;
using DAL.ActivosFijosDAL;
using DAL.ActivosFIjos.Dtos;

namespace ActivosFijos.Controllers
{
    public class RevisionActivoFijoController : Controller
    {
        private FinancyContext db = new FinancyContext();
        private IActivosFijosDAL _ActivosFijosDAL;
        public ActionResult Revision()
        {
            return View(db.UbicacionDestinoes.ToList());
        }



        // GET: /RevisionActivoFijo/
        public ActionResult Index()
        {
            var revisionactivofijoes = db.RevisionActivoFijoes.Include(r => r.UbicacionDestino);
            return View(revisionactivofijoes.ToList());
        }

        // GET: /RevisionActivoFijo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevisionActivoFijo revisionactivofijo = db.RevisionActivoFijoes.Find(id);
            if (revisionactivofijo == null)
            {
                return HttpNotFound();
            }
            return View(revisionactivofijo);
        }


        // GET: /RevisionActivoFijo/Create
        public ActionResult RevisionActivos(int id) //revision
        {
            _ActivosFijosDAL = (IActivosFijosDAL)(new ActivosFijosDAL());
            List<ListadoActivosFijos> listadoActivosFijos = _ActivosFijosDAL.ListarActivosFijos(id).ToList();
           // ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestinoes, "UbicacionDestinoId", "Codigo");
            return View(listadoActivosFijos);
        }


        // GET: /RevisionActivoFijo/Create
        public ActionResult Create(int id)//Destino
        {
            RevisionActivoFijo revision = new RevisionActivoFijo();
            revision.UbicacionDestinoId = id;
            return View(revision);
        }

        // POST: /RevisionActivoFijo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RevisionActivoFijo revisionactivofijo)
        {

            //SI YA EXISTE NO CREAR SOLO REDIRECCIONAR
            revisionactivofijo.Observacion = "";
            revisionactivofijo.Usuario = "";
            revisionactivofijo.FechaOperacion = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.RevisionActivoFijoes.Add(revisionactivofijo);
                db.SaveChanges();
                _ActivosFijosDAL = (IActivosFijosDAL)(new ActivosFijosDAL());
                string resultado = _ActivosFijosDAL.crearRevisionActivoFijoDetalle(revisionactivofijo.RevisionActivoFijoId);
                /// exception
                return RedirectToAction("RevisionActivos", revisionactivofijo.RevisionActivoFijoId);
            }

            
           // ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestinoes, "UbicacionDestinoId", "Codigo", revisionactivofijo.UbicacionDestinoId);
            return View(revisionactivofijo);
        }

        // GET: /RevisionActivoFijo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevisionActivoFijo revisionactivofijo = db.RevisionActivoFijoes.Find(id);
            if (revisionactivofijo == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestinoes, "UbicacionDestinoId", "Codigo", revisionactivofijo.UbicacionDestinoId);
            return View(revisionactivofijo);
        }

        // POST: /RevisionActivoFijo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RevisionActivoFijoId,SedeId,UbicacionDestinoId,Fecha,Observacion,Usuario,FechaOperacion")] RevisionActivoFijo revisionactivofijo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revisionactivofijo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestinoes, "UbicacionDestinoId", "Codigo", revisionactivofijo.UbicacionDestinoId);
            return View(revisionactivofijo);
        }

        // GET: /RevisionActivoFijo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevisionActivoFijo revisionactivofijo = db.RevisionActivoFijoes.Find(id);
            if (revisionactivofijo == null)
            {
                return HttpNotFound();
            }
            return View(revisionactivofijo);
        }

        // POST: /RevisionActivoFijo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RevisionActivoFijo revisionactivofijo = db.RevisionActivoFijoes.Find(id);
            db.RevisionActivoFijoes.Remove(revisionactivofijo);
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
