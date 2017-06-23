using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Financy.Entities;
using Financy.Models;
using Modelo.Inventario;

namespace ControlResidentes.Controllers
{
    public class MovimientoInventarioResidenteController : Controller
    {
        private FinancyContext db = new FinancyContext();

        // GET: /MovimientoInventarioResidente/
        public ActionResult Index()
        {
            var movimientoinventarioresidente = db.MovimientoInventarioResidente.Include(m => m.MovimientoInventario);
            return View(movimientoinventarioresidente.ToList());
        }

        // GET: /MovimientoInventarioResidente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimientoInventarioResidente movimientoinventarioresidente = db.MovimientoInventarioResidente.Find(id);
            if (movimientoinventarioresidente == null)
            {
                return HttpNotFound();
            }
            return View(movimientoinventarioresidente);
        }

        // GET: /MovimientoInventarioResidente/Create
        public ActionResult Create()
        {
            string usuario = System.Web.HttpContext.Current.Session["User"].ToString();
            ViewBag.MovimientoInventarioId = new SelectList(db.MovimientoInventario, "MovimientoInventarioId", "Consecutivo");
        //    ViewBag.EstadoMovimientoId = new SelectList(db.EstadoMovimientoes, "EstadoMovimientoId", "Descripcion");
        //    ViewBag.TerceroId = new SelectList(db.Terceroes, "TerceroId", "RazonSocial");
            var _tmusu = from c in db.TipoMovimiento join cm in db.UsuarioTipoMovimiento on c.TipoMovimientoId equals cm.TipoMovimientoId where cm.Usuario.Login == usuario select c;
            //validar los movimientos de entrada y salida de medicamentos --> preconfigurarlos
            ViewBag.TipoMovimientoId = new SelectList(_tmusu, "TipoMovimientoId", "Descripcion");
        //    ViewBag.UbicacionDestinoId = new SelectList(db.UbicacionDestino, "UbicacionDestinoId", "Descripcion");
            MovimientoInventario movimiento = new MovimientoInventario();

            movimiento.Fecha = DateTime.Now;
            MovimientoInventarioResidente movimientoResidente = new MovimientoInventarioResidente();
            movimientoResidente.MovimientoInventario = movimiento;

            return View();
        }

        // POST: /MovimientoInventarioResidente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MovimientoInventarioResidenteId,MovimientoInventarioId,PacienteId,Usuario,FechaOperacion")] MovimientoInventarioResidente movimientoinventarioresidente)
        {
            if (ModelState.IsValid)
            {
                db.MovimientoInventarioResidente.Add(movimientoinventarioresidente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovimientoInventarioId = new SelectList(db.MovimientoInventario, "MovimientoInventarioId", "Consecutivo", movimientoinventarioresidente.MovimientoInventarioId);
            return View(movimientoinventarioresidente);
        }

        // GET: /MovimientoInventarioResidente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimientoInventarioResidente movimientoinventarioresidente = db.MovimientoInventarioResidente.Find(id);
            if (movimientoinventarioresidente == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovimientoInventarioId = new SelectList(db.MovimientoInventario, "MovimientoInventarioId", "Consecutivo", movimientoinventarioresidente.MovimientoInventarioId);
            return View(movimientoinventarioresidente);
        }

        // POST: /MovimientoInventarioResidente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MovimientoInventarioResidenteId,MovimientoInventarioId,PacienteId,Usuario,FechaOperacion")] MovimientoInventarioResidente movimientoinventarioresidente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimientoinventarioresidente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovimientoInventarioId = new SelectList(db.MovimientoInventario, "MovimientoInventarioId", "Consecutivo", movimientoinventarioresidente.MovimientoInventarioId);
            return View(movimientoinventarioresidente);
        }

        // GET: /MovimientoInventarioResidente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimientoInventarioResidente movimientoinventarioresidente = db.MovimientoInventarioResidente.Find(id);
            if (movimientoinventarioresidente == null)
            {
                return HttpNotFound();
            }
            return View(movimientoinventarioresidente);
        }

        // POST: /MovimientoInventarioResidente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovimientoInventarioResidente movimientoinventarioresidente = db.MovimientoInventarioResidente.Find(id);
            db.MovimientoInventarioResidente.Remove(movimientoinventarioresidente);
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
