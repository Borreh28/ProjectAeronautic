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
    public class RequisitionController : Controller
    {
        Requisicion r;
        RequisicionLinea rl;
        FormularioRequisicion fr;

        RequisicionRepository rr;
        RequisicionLineaRepository rlr;
        ProveedorRepository pvr;
        DepartamentoRepository dpr;

        public RequisitionController()
        {
            r = new Requisicion();
            rl = new RequisicionLinea();
            fr = new FormularioRequisicion();

            rr = new RequisicionRepository();
            rlr = new RequisicionLineaRepository();
            pvr = new ProveedorRepository();
            dpr = new DepartamentoRepository();
        }

        public ActionResult All()
        {
            var model = rr.GetAllActive();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            fr.Requsiciones = rr.GetById(id);
            fr.Lineas = rlr.GetByIdRequisicion(id);

            return View(fr);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            return RedirectToAction("Details", new { id = 0 });
        }

        public ActionResult Edit(int id)
        {
            fr.Requsiciones = rr.GetById(id);
            fr.Lineas = rlr.GetByIdRequisicion(id);
            fr.Proveedores = pvr.GetAll();
            fr.Departamentos = dpr.GetAll();

            return View(fr);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            string Depto = form["Departamento"];
            var Deptos = fr.Departamentos;
            Deptos = dpr.GetByName(Depto);

            string Prvdr = form["Proveedor"];
            var Prvdrs = fr.Proveedores;
            Prvdrs = pvr.GetByName(Prvdr);

            r.Id = Int32.Parse(form["ReqId"]);
            r.PeriodoId = Int32.Parse(form["PeriodoId"]);
            r.DepartamentoId = Deptos.FirstOrDefault().Id;
            r.ProveedorId = Prvdrs.FirstOrDefault().Id;
            r.MonedaId = Int32.Parse(form["MonedaId"]);
            r.EstatusId = Int32.Parse(form["EstatusId"]);
            r.TotalLineas = Int32.Parse(form["TotalLineas"]);
            r.SubTotal = Decimal.Parse(form["SubTotal"]);
            r.Interes = 0;
            r.GranTotal = Decimal.Parse(form["GranTotal"]);
            r.CreadoPor = Int32.Parse(form["CreadoPor"]);
            r.Creado = DateTime.Parse(form["Creado"]);
            r.ActualizadoPor = Int32.Parse(form["ActualizadoPor"]);
            r.Actualizado = DateTime.Parse(form["Actualizado"]);
            r.Descripcion = form["Descripcion"];
            r.FechaRequisicion = DateTime.Parse(form["FechaRequisicion"]);
            r.FechaEntrega = DateTime.Parse(form["FechaEntrega"]);
            r.Comentarios = form["Comentarios"];
            r.PrioridadId = form["PrioridadId"];
            r.Activo = Convert.ToBoolean(form["Activo"]);

            rr.Update(r);

            return RedirectToAction("Details", new { r.Id });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            var check = form["Permanente"];
            bool Permanente = false;

            if (check != "false")
            {
                check = "true";
                Permanente = Convert.ToBoolean(check);
            }

            if (Permanente)
            {
                r.Id = Int32.Parse(form["Id"]);

                rr.Delete(r.Id);
            }
            else
            {
                r.Id = Int32.Parse(form["Id"]);
                r.PeriodoId = Int32.Parse(form["PeriodoId"]);
                r.DepartamentoId = Int32.Parse(form["DepartamentoId"]);
                r.ProveedorId = Int32.Parse(form["ProveedorId"]);
                r.MonedaId = Int32.Parse(form["MonedaId"]);
                r.EstatusId = Int32.Parse(form["EstatusId"]);
                r.TotalLineas = Int32.Parse(form["TotalLineas"]);
                r.SubTotal = Decimal.Parse(form["SubTotal"]);
                r.Interes = Decimal.Parse(form["Interes"]);
                r.GranTotal = Decimal.Parse(form["GranTotal"]);
                r.CreadoPor = Int32.Parse(form["CreadoPor"]);
                r.Creado = DateTime.Parse(form["Creado"]);
                r.ActualizadoPor = Int32.Parse(form["ActualizadoPor"]);
                r.Actualizado = DateTime.Parse(form["Actualizado"]);
                r.Descripcion = form["Descripcion"];
                r.FechaRequisicion = DateTime.Parse(form["FechaRequisicion"]);
                r.FechaEntrega = DateTime.Parse(form["FechaEntrega"]);
                r.Comentarios = form["Comentarios"];
                r.PrioridadId = form["PrioridadId"];
                r.Activo = false;

                rr.Update(r);
            }

            return RedirectToAction("All");
        }
    }
}