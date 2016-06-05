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
    public class RequisitionLineController : Controller
    {
        Requisicion Req;
        RequisicionLinea ReqLin;
        FormularioRequisicion FormReq;

        RequisicionRepository ReqRepo;
        RequisicionLineaRepository ReqLinRepo;
        ProveedorRepository ProvRepo;
        DepartamentoRepository DeptoRepo;
        EstatusRepository EstRepo;
        PeriodoRepository PerRepo;
        PrioridadRepository PrioRepo;

        public RequisitionLineController()
        {
            Req = new Requisicion();
            ReqLin = new RequisicionLinea();
            FormReq = new FormularioRequisicion();

            ReqRepo = new RequisicionRepository();
            ReqLinRepo = new RequisicionLineaRepository();
            ProvRepo = new ProveedorRepository();
            DeptoRepo = new DepartamentoRepository();
            EstRepo = new EstatusRepository();
            PerRepo = new PeriodoRepository();
            PrioRepo = new PrioridadRepository();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            ReqLin.Id = form["LineaId"];
            ReqLin.RequisicionId = Convert.ToInt32(form["ReqId"]);
            ReqLin.Linea = Convert.ToInt32(form["Linea"]);
            ReqLin.ParteId = Convert.ToInt32(form["ParteId"]);
            ReqLin.Cantidad = Convert.ToInt32(form["Cantidad"]);
            ReqLin.PrecioVenta = Convert.ToDecimal(form["Precio"]);
            ReqLin.Descripcion = form["Descripcion"];
            ReqLin.CreadoPor = 0;
            ReqLin.Creado = DateTime.Now;
            ReqLin.ActualizadoPor = 0;
            ReqLin.Actualizado = DateTime.Now;

            ReqLinRepo.Add(ReqLin);

            return RedirectToAction("Edit", "Requisition", new { id = ReqLin.RequisicionId });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            string LineaId = form["LineaId"];
            int ReqId = Convert.ToInt32(form["ReqId"]);

            ReqLinRepo.Delete(LineaId);

            return RedirectToAction("Edit", "Requisition", new { id = ReqId });
        }
    }
}