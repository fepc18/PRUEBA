using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Financy.Models;
using Modelo.ActivosFijos;

namespace ActivosFijos.Controllers
{
    public class ActivoFijoController : Controller
    {
        private FinancyContext db = new FinancyContext();

        // GET: ActivoFijo
        public ActionResult Index()
        {
            var activoFijoes = db.ActivoFijoes.Include(a => a.EstadoActivoFijo).Include(a => a.GrupoActivo).Include(a => a.Tercero).Include(a => a.UbicacionDestino);
            return View(activoFijoes.ToList());
        }

        // GET: ActivoFijo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivoFijo activoFijo = db.ActivoFijoes.Find(id);
            if (activoFijo == null)
            {
                return HttpNotFound();
            }
            return View(activoFijo);
        }

        // GET: ActivoFijo/Details/5
        public ActionResult Alta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivoFijo activoFijo = db.ActivoFijoes.Find(id);
            if (activoFijo == null)
            {
                return HttpNotFound();
            }
            return View(activoFijo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta( ActivoFijo activoFijo)
        {
            DateTime fechaAlta = activoFijo.FechaAlta;
            activoFijo = db.ActivoFijoes.Find(activoFijo.ActivoFijoId);
            activoFijo.FechaAlta = fechaAlta;
            activoFijo.EstadoIngreso = EstadoIngreso.Alta;
            
                db.Entry(activoFijo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
            ViewBag.EstadoActivoFijoId = new SelectList(db.EstadoActivoFijoes, "EstadoActivoFijoId", "Descripcion", activoFijo.EstadoActivoFijoId);
            ViewBag.GrupoActivoId = new SelectList(db.GrupoActivoes, "GrupoActivoId", "Nombre", activoFijo.GrupoActivoId);
            ViewBag.TerceroId = new SelectList(db.Terceroes.Where(x => x.Empleado == true && x.Activo == true), "TerceroId", "RazonSocial", activoFijo.TerceroId);
            ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestinoes, "UbicacionDestinoId", "Descripcion", activoFijo.UbicacionDestinoId);
            return View(activoFijo);
        }

        // POST: ActivoFijo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ActivoFijo activoFijo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activoFijo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoActivoFijoId = new SelectList(db.EstadoActivoFijoes, "EstadoActivoFijoId", "Descripcion", activoFijo.EstadoActivoFijoId);
            ViewBag.GrupoActivoId = new SelectList(db.GrupoActivoes, "GrupoActivoId", "Nombre", activoFijo.GrupoActivoId);
            ViewBag.TerceroId = new SelectList(db.Terceroes.Where(x => x.Empleado == true && x.Activo == true), "TerceroId", "RazonSocial", activoFijo.TerceroId);
            ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestinoes, "UbicacionDestinoId", "Descripcion", activoFijo.UbicacionDestinoId);
            return View(activoFijo);
        }


        // GET: ActivoFijo/Create
        public ActionResult Create()
        {
            ViewBag.EstadoActivoFijoId = new SelectList(db.EstadoActivoFijoes, "EstadoActivoFijoId", "Descripcion");
            ViewBag.GrupoActivoId = new SelectList(db.GrupoActivoes, "GrupoActivoId", "Nombre");
            ViewBag.TerceroId = new SelectList(db.Terceroes.Where(x=>x.Empleado==true && x.Activo == true) , "TerceroId", "RazonSocial");
            ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestinoes, "UbicacionDestinoId", "Descripcion");
            return View();
        }

        // POST: ActivoFijo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ActivoFijo activoFijo)
        {
            activoFijo.FechaOperacion = DateTime.Now;
            activoFijo.FechaAlta = Convert.ToDateTime("01/01/1900");
            activoFijo.Usuario = "";
            activoFijo.PeriodoIngreso = "";
            if (ModelState.IsValid)
            {
                db.ActivoFijoes.Add(activoFijo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoActivoFijoId = new SelectList(db.EstadoActivoFijoes, "EstadoActivoFijoId", "Descripcion", activoFijo.EstadoActivoFijoId);
            ViewBag.GrupoActivoId = new SelectList(db.GrupoActivoes, "GrupoActivoId", "Nombre", activoFijo.GrupoActivoId);
            ViewBag.TerceroId = new SelectList(db.Terceroes.Where(x => x.Empleado == true && x.Activo==true), "TerceroId", "RazonSocial", activoFijo.TerceroId);
            ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestinoes, "UbicacionDestinoId", "Descripcion", activoFijo.UbicacionDestinoId);
            return View(activoFijo);
        }

        // GET: ActivoFijo/Edit/5
        

        // POST: ActivoFijo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     /*   [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivoFijoId,Codigo,NumeroSerie,Marca,Modelo,Color,UbicacionDestinoId,EstadoActivoFijoId,TipoIngreso,FechaAdquisicion,FechaAlta,ValorUnitario,GrupoActivoId,NumeroFactura,FechaOperacion,Usuario,PeriodoIngreso,TerceroId,DescripcionEstado,MenorCuantia,EstadoIngreso")] ActivoFijo activoFijo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activoFijo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoActivoFijoId = new SelectList(db.EstadoActivoFijoes, "EstadoActivoFijoId", "Descripcion", activoFijo.EstadoActivoFijoId);
            ViewBag.GrupoActivoId = new SelectList(db.GrupoActivoes, "GrupoActivoId", "Nombre", activoFijo.GrupoActivoId);
            ViewBag.TerceroId = new SelectList(db.Terceroes.Where(x=>x.Empleado==true && x.Activo == true) , "TerceroId", "RazonSocial", activoFijo.TerceroId);
            ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestinoes, "UbicacionDestinoId", "Descripcion", activoFijo.UbicacionDestinoId);
            return View(activoFijo);
        }
        */
        // GET: ActivoFijo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivoFijo activoFijo = db.ActivoFijoes.Find(id);
            if (activoFijo == null)
            {
                return HttpNotFound();
            }
            return View(activoFijo);
        }

        // POST: ActivoFijo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivoFijo activoFijo = db.ActivoFijoes.Find(id);
            db.ActivoFijoes.Remove(activoFijo);
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
