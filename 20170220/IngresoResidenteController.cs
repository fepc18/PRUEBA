using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Financy.Models;
using Modelo.ControlResidentes;
using DAL.Comun;
using DAL.ControlResidentes;
using Modelo.Comun;
using Modelo.POS;
using Modelo.Hospitalizacion;
using DAL.ControlResidentes.Dtos;
namespace ControlResidentes.Controllers
{
    public class IngresoResidenteController : Controller
    {
        private FinancyContext db = new FinancyContext();
        private IComunDAL _ComunDAL;
        private IControlResidentesDAL _ControlResidentesDAL;
        // GET: IngresoResidente
        public ActionResult Index(String Criterio)
        {
            //var ingresoResidentes = db.IngresoResidentes.Include(i => i.Sede).Include(i => i.TipoSustancia).Include(i => i.TipoAdiccion);
            _ControlResidentesDAL = (IControlResidentesDAL)(new ControlResidentesDAL());
          //  var ingresoResidentes = _ControlResidentesDAL.ListarIngresoResidentes();

            Criterio = Criterio == null ? "" : Criterio;

            //IQueryable<ListadoIngresoResidentes> ingresoResidentes;
            List<ListadoIngresoResidentes> ingresoResidentes;
            if (!Criterio.Equals(""))
                ingresoResidentes = _ControlResidentesDAL.ListarIngresoResidentes();
            else
                ingresoResidentes = _ControlResidentesDAL.ListarIngresoResidentes()
                                    .Where(x=>x.Paciente.Contains(Criterio) || x.Identificacion.Contains(Criterio)).ToList();
            


            return View(ingresoResidentes.ToList());
        }

        // GET: IngresoResidente/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoResidente ingresoResidente = db.IngresoResidentes.Find(id);
            if (ingresoResidente == null)
            {
                return HttpNotFound();
            }
            return View(ingresoResidente);
        }

        // GET: IngresoResidente/Create
        public ActionResult Create()
        {
            _ComunDAL = (IComunDAL)(new ComunDAL());
            var listPacientes = _ComunDAL.listarPacientesSinIngresar();
            ViewBag.PacienteId = new SelectList(listPacientes.OrderBy(X => X.Nombre), "Id", "Nombre");
            ViewBag.SedeId = new SelectList(db.Sedes, "SedeId", "Nombre");
            ViewBag.TipoSustanciaId = new SelectList(db.TipoSustancias, "TipoSustanciaId", "Descripcion");
            ViewBag.TipoAdiccionId = new SelectList(db.TipoAdiccions, "TipoAdiccionId", "Descripcion");
            return View();
        }

        // POST: IngresoResidente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngresoResidente ingresoResidente)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
               return RedirectToAction("Login","Account");
            else
            {
                ingresoResidente = corregirNulos(ingresoResidente);
                string usuario = System.Web.HttpContext.Current.Session["User"].ToString();
                ingresoResidente.FechaOperacion = DateTime.Now;
                ingresoResidente.Usuario = usuario;
                try
                {
                    db.IngresoResidentes.Add(ingresoResidente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }catch(Exception ex){ }
                _ComunDAL = (IComunDAL)(new ComunDAL());
                var listPacientes = _ComunDAL.listarPacientesSinIngresar();
                ViewBag.PacienteId = new SelectList(listPacientes.OrderBy(X => X.Nombre), "Id", "Nombre", ingresoResidente.PacienteId);
                
                ViewBag.SedeId = new SelectList(db.Sedes, "SedeId", "Nombre", ingresoResidente.SedeId);
                ViewBag.TipoSustanciaId = new SelectList(db.TipoSustancias, "TipoSustanciaId", "Descripcion", ingresoResidente.TipoSustanciaId);
                ViewBag.TipoAdiccionId = new SelectList(db.TipoAdiccions, "TipoAdiccionId", "Descripcion", ingresoResidente.TipoAdiccionId);
                return View(ingresoResidente);
            }
         
        }
        private IngresoResidente corregirNulos(IngresoResidente ingresoResidente)
        {
            if (ingresoResidente.Observaciones == null)
                ingresoResidente.Observaciones = "";
            if (ingresoResidente.RecibidoTratamientoTerapeutico == null)
                ingresoResidente.RecibidoTratamientoTerapeutico = false;
            if (ingresoResidente.recibidoTratamientoPsiquiatrico == null)
                ingresoResidente.recibidoTratamientoPsiquiatrico = false;
            if (ingresoResidente.InstitucionTratamientoTerapeutico == null)
                ingresoResidente.InstitucionTratamientoTerapeutico = "";
            if (ingresoResidente.InstitucionTratamientoPsiquiatrico == null)
                ingresoResidente.InstitucionTratamientoPsiquiatrico = "";
            if (ingresoResidente.NombreFamiliaAmigo == null)
                ingresoResidente.NombreFamiliaAmigo = "";
            if (ingresoResidente.Acudiente == null)
                ingresoResidente.Acudiente = "";
            if (ingresoResidente.DocumentoIdentidadAcudiente == null)
                ingresoResidente.DocumentoIdentidadAcudiente = "";
            if (ingresoResidente.DireccionAcudiente == null)
                ingresoResidente.DireccionAcudiente = "";
            if (ingresoResidente.Parentesco == null)
                ingresoResidente.Parentesco = "";
            if (ingresoResidente.TelefonoAcudiente == null)
                ingresoResidente.TelefonoAcudiente = "";
            if (ingresoResidente.EmailAcudiente == null)
                ingresoResidente.EmailAcudiente = "";
            if (ingresoResidente.Celular == null)
                ingresoResidente.Celular = "";
            if (ingresoResidente.DireccionFamiliaAmigo == null)
                ingresoResidente.DireccionFamiliaAmigo = "";
            if (ingresoResidente.TelefonoFamiliaAmigo == null)
                ingresoResidente.TelefonoFamiliaAmigo = "";
            if (ingresoResidente.CelularFamiliaAmigo == null)
                ingresoResidente.CelularFamiliaAmigo = "";
            return ingresoResidente;
        }
        // GET: IngresoResidente/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id   == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoResidente ingresoResidente = db.IngresoResidentes.Find(id);
            if (ingresoResidente == null)
            {
                return HttpNotFound();
            }


            _ComunDAL = (IComunDAL)(new ComunDAL());
            var listPacientes = _ComunDAL.listarPacientesSinIngresar();
            ViewBag.PacienteId = new SelectList(listPacientes.OrderBy(X => X.Nombre), "Id", "Nombre", ingresoResidente.PacienteId);

            ViewBag.SedeId = new SelectList(db.Sedes, "SedeId", "Nombre", ingresoResidente.SedeId);
            ViewBag.TipoSustanciaId = new SelectList(db.TipoSustancias, "TipoSustanciaId", "Descripcion", ingresoResidente.TipoSustanciaId);
            ViewBag.TipoAdiccionId = new SelectList(db.TipoAdiccions, "TipoAdiccionId", "Descripcion", ingresoResidente.TipoAdiccionId);
            return View(ingresoResidente);
        }

        // POST: IngresoResidente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IngresoResidente ingresoResidente)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Account");

            ingresoResidente = corregirNulos(ingresoResidente);
            string usuario = System.Web.HttpContext.Current.Session["User"].ToString();
            ingresoResidente.FechaOperacion = DateTime.Now;
            ingresoResidente.Usuario = usuario;

            db.Entry(ingresoResidente).State = EntityState.Modified;
                db.SaveChanges();
                //var ingresoResidentes = db.IngresoResidentes.Include(i => i.Sede).Include(i => i.TipoSustancia).Include(i => i.TipoAdiccion);
            //    _ControlResidentesDAL = (IControlResidentesDAL)(new ControlResidentesDAL());
              //  var ingresoResidentes = _ControlResidentesDAL.ListarIngresoResidentes();
            return RedirectToAction("Index");
            
            _ComunDAL = (IComunDAL)(new ComunDAL());
            var listPacientes = _ComunDAL.listarPacientesSinIngresar();
            ViewBag.PacienteId = new SelectList(listPacientes.OrderBy(X => X.Nombre), "Id", "Nombre", ingresoResidente.PacienteId);

            ViewBag.SedeId = new SelectList(db.Sedes, "SedeId", "Nombre", ingresoResidente.SedeId);
            ViewBag.TipoSustanciaId = new SelectList(db.TipoSustancias, "TipoSustanciaId", "Descripcion", ingresoResidente.TipoSustanciaId);
            ViewBag.TipoAdiccionId = new SelectList(db.TipoAdiccions, "TipoAdiccionId", "Descripcion", ingresoResidente.TipoAdiccionId);
            return View(ingresoResidente);
        }

        // GET: IngresoResidente/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoResidente ingresoResidente = db.IngresoResidentes.Find(id);
            if (ingresoResidente == null)
            {
                return HttpNotFound();
            }
            return View(ingresoResidente);
        }

        // POST: IngresoResidente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            IngresoResidente ingresoResidente = db.IngresoResidentes.Find(id);
            db.IngresoResidentes.Remove(ingresoResidente);
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
        // GET: Locker
        public ActionResult AsignarLocker(int IngresoId)
        {
            ViewBag.IngresoId=IngresoId;
            IngresoResidente ingresoResidente = db.IngresoResidentes.Where(x => x.IngresoResidenteId == IngresoId).FirstOrDefault();
            _ComunDAL = (IComunDAL)(new ComunDAL());            
            Paciente paciente = _ComunDAL.obtenerPaciente(ingresoResidente.PacienteId);
            Sede sede = db.Sedes.Where(x => x.SedeId == ingresoResidente.SedeId).FirstOrDefault();
            ViewData["Paciente"] = paciente.Nombre;
            ViewData["Sede"] = sede.Nombre ;
            ViewData["Identificacion"] = paciente.Identificacion;
            ViewData["FechaIngreso"] = ingresoResidente.FechaIngreso.ToString().Substring(0,10);
            ViewData["TipoAdiccion"] = ingresoResidente.TipoAdiccion.Descripcion;
            var lockers = db.Lockers.Include(l => l.Sede);
            return View(lockers.ToList());
        }
        // GET: Locker
        public ActionResult AsignarLockerPaciente(int id, int IngresoId)
        {
            IngresoResidente ingresoResidente = db.IngresoResidentes.Where(x => x.IngresoResidenteId == IngresoId).FirstOrDefault();
            Locker locker = db.Lockers.Where(x => x.LockerId == id).FirstOrDefault();
            var asignacionAnterior = db.LockerAsignadoes.Where(x => x.Locker.LockerId == locker.LockerId && x.vigente==true).FirstOrDefault();
            if (asignacionAnterior != null)
            {
                asignacionAnterior.FechaRetiro = DateTime.Now;
                asignacionAnterior.vigente = false;
                db.Entry(asignacionAnterior).State = EntityState.Modified;
                db.SaveChanges();
            }
            locker.EstadoLockerId = EstadoLocker.Ocupado;
            db.Entry(locker).State = EntityState.Modified;
            db.SaveChanges();
            LockerAsignado lockerAsignado = new LockerAsignado();
            lockerAsignado.PacienteId = ingresoResidente.PacienteId;
            lockerAsignado.Locker = locker;
            lockerAsignado.FechaAsignacion = DateTime.Now;
            lockerAsignado.vigente = true;
            db.Entry(lockerAsignado).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Locker
        public ActionResult AsignarCama(int IngresoId,int SedeId,int EdificioId,int PisoId)
        {
            ViewBag.IngresoId = IngresoId;
            IngresoResidente ingresoResidente = db.IngresoResidentes.Where(x => x.IngresoResidenteId == IngresoId).FirstOrDefault();
            _ComunDAL = (IComunDAL)(new ComunDAL());
            Paciente paciente = _ComunDAL.obtenerPaciente(ingresoResidente.PacienteId);
            Sede sede = db.Sedes.Where(x => x.SedeId == ingresoResidente.SedeId).FirstOrDefault();
            ViewData["Paciente"] = paciente.Nombre;
            ViewData["Sede"] = sede.Nombre;
            ViewData["Identificacion"] = paciente.Identificacion;
            ViewData["FechaIngreso"] = ingresoResidente.FechaIngreso.ToString().Substring(0, 10);
            ViewData["TipoAdiccion"] = ingresoResidente.TipoAdiccion.Descripcion;
            ViewBag.SedeId = new SelectList(db.Sedes, "SedeId", "Nombre");
            var camas = db.Camas.Include(l => l.Habitacion);
            if (PisoId > 0)
            {
                camas = camas.Where(x => x.Habitacion.PisoId == PisoId);
            }
            else if (EdificioId > 0)
            {
                camas = camas.Where(x => x.Habitacion.Piso.EdificioId == EdificioId);
            }
            else if (SedeId > 0)
            {
                camas = camas.Where(x => x.Habitacion.Piso.Edificio.SedeId == SedeId);
            }
            
            return View(camas.ToList());
        }
        public JsonResult GetEdificiosList(int idSede)
        {
            return Json(new SelectList(db.Edificios.Where(x => x.SedeId == idSede).ToList(), "EdificioId", "Nombre"));
            
        }
        public JsonResult GetPisosList(int idEdificio)
        {
            return Json(new SelectList(db.Pisoes.Where(x => x.EdificioId == idEdificio).ToList(), "PisoId", "Nombre"));

        }
        public JsonResult GetHabitacionesList(int idPiso)
        {
            return Json(new SelectList(db.Habitacions.Where(x => x.PisoId == idPiso).ToList(), "HabitacionId", "Nombre"));
        }
        // GET: Locker
        public ActionResult AsignarCamaPaciente(int id, int IngresoId)
        {
            IngresoResidente ingresoResidente = db.IngresoResidentes.Where(x => x.IngresoResidenteId == IngresoId).FirstOrDefault();
            Cama cama = db.Camas.Where(x => x.CamaId == id).FirstOrDefault();
            var asignacionAnterior = db.CamaAsignada.Where(x => x.Cama.CamaId == cama.CamaId && x.vigente == true).FirstOrDefault();
            if (asignacionAnterior != null)
            {
                asignacionAnterior.FechaRetiro = DateTime.Now;
                asignacionAnterior.vigente = false;
                db.Entry(asignacionAnterior).State = EntityState.Modified;
                db.SaveChanges();
            }
            cama.EstadoCamaId = EstadoCama.Ocupado;
            db.Entry(cama).State = EntityState.Modified;
            db.SaveChanges();
            CamaAsignada camaAsignada = new CamaAsignada();
            camaAsignada.PacienteId = ingresoResidente.PacienteId;
            camaAsignada.Cama = cama;
            camaAsignada.FechaAsignacion = DateTime.Now;
            camaAsignada.vigente = true;
            db.Entry(camaAsignada).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
