using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.ViewModels;
using App.DAL;
using App.Entities;

namespace App.Controllers
{
    public class FormController : Controller
    {
        Requisicion r;
        RequisicionLinea rl;
        FormularioRequisicion fr;

        RequisicionRepository rr;
        RequisicionLineaRepository rlr;
        ProveedorRepository pvr;
        DepartamentoRepository dpr;

        public FormController()
        {
            r = new Requisicion();
            rl = new RequisicionLinea();
            fr = new FormularioRequisicion();

            rr = new RequisicionRepository();
            rlr = new RequisicionLineaRepository();
            pvr = new ProveedorRepository();
            dpr = new DepartamentoRepository();
        }

        public ActionResult Details(int id)
        {
            fr.Requsiciones = rr.GetById(id);
            fr.Lineas = rlr.GetByIdRequisicion(id);
            fr.Proveedores = pvr.GetAll();
            fr.Departamentos = dpr.GetAll();

            return View(fr);
        }

        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            int Id = Int32.Parse(form["ReqId"]);

            string Depto = form["Departamento"];
            var Deptos = fr.Departamentos;
            Deptos = dpr.GetByName(Depto);

            string Prvdr = form["Proveedor"];
            var Prvdrs = fr.Proveedores;
            Prvdrs = pvr.GetByName(Prvdr);

            r.Id = Id;
            r.PeriodoId = Int32.Parse(form["PeriodoId"]);
            r.DepartamentoId = Deptos.FirstOrDefault().Id;
            r.ProveedorId = Prvdrs.FirstOrDefault().Id;
            r.MonedaId = Int32.Parse(form["Moneda"]);
            r.EstatusId = Int32.Parse(form["EstatusId"]);
            r.TotalLineas = Int32.Parse(form["TotalLineas"]);
            r.SubTotal = Decimal.Parse(form["SubTotal"]);
            r.Interes = 0;
            r.GranTotal = Decimal.Parse(form["Total"]);
            r.CreadoPor = Int32.Parse(form["ReqCreadoPor"]);
            r.Creado = DateTime.Parse(form["ReqFechaCreacion"]);
            r.ActualizadoPor = Int32.Parse(form["ReqActualizadoPor"]);
            r.Actualizado = DateTime.Parse(form["ReqFechaActualizacion"]);
            r.Descripcion = form["Descripcion"];
            r.FechaRequisicion = DateTime.Parse(form["FechaRequisicion"]);
            r.FechaEntrega = DateTime.Parse(form["FechaEntrega"]);
            r.Comentarios = form["Comentarios"];
            r.PrioridadId = form["PrioridadId"];

            rr.Update(r);

            return RedirectToAction("Details", new { id = Id});
        }
    }
}