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
        Requisition Req;
        RequisitionLine ReqLin;
        FormularioRequisicion FormReq;

        RequisitionRepository ReqRepo;
        RequisitionLineRepository ReqLinRepo;
        SupplierRepository ProvRepo;
        DepartmentRepository DeptoRepo;
        StatusRepository EstRepo;
        PeriodRepository PerRepo;
        PriorityRepository PrioRepo;

        public RequisitionLineController()
        {
            Req = new Requisition();
            ReqLin = new RequisitionLine();
            FormReq = new FormularioRequisicion();

            ReqRepo = new RequisitionRepository();
            ReqLinRepo = new RequisitionLineRepository();
            ProvRepo = new SupplierRepository();
            DeptoRepo = new DepartmentRepository();
            EstRepo = new StatusRepository();
            PerRepo = new PeriodRepository();
            PrioRepo = new PriorityRepository();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            ReqLin.Id = Convert.ToInt32( form["LineaId"]);
            ReqLin.RequisitionId = Convert.ToInt32(form["ReqId"]);
            ReqLin.Line = Convert.ToInt32(form["Linea"]);
            ReqLin.ProductId = Convert.ToInt32(form["ParteId"]);
            ReqLin.Quantity = Convert.ToInt32(form["Cantidad"]);
            ReqLin.SalePrice = Convert.ToDecimal(form["Precio"]);
            ReqLin.Description = form["Descripcion"];
            ReqLin.CreatedBy = 0;
            ReqLin.Created = DateTime.Now;
            ReqLin.UpdatedBy = 0;
            ReqLin.Updated = DateTime.Now;

            ReqLinRepo.Add(ReqLin);

            return RedirectToAction("Edit", "Requisition", new { id = ReqLin.RequisitionId });
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            ReqLin.Id = Convert.ToInt32(form["LineaId"]);
            ReqLin.RequisitionId = Convert.ToInt32(form["ReqId"]);
            ReqLin.Line = Convert.ToInt32(form["Linea"]);
            ReqLin.ProductId = Convert.ToInt32(form["ParteId"]);
            ReqLin.Quantity = Convert.ToInt32(form["Cantidad"]);
            ReqLin.SalePrice = Convert.ToDecimal(form["Precio"]);
            ReqLin.Description = form["Descripcion"];
            ReqLin.CreatedBy = Convert.ToInt32(form["CreadoPor"]);
            ReqLin.Created = Convert.ToDateTime(form["Creado"]);
            ReqLin.UpdatedBy = 0;
            ReqLin.Updated = DateTime.Now;

            ReqLinRepo.Update(ReqLin);

            return RedirectToAction("Edit", "Requisition", new { id = ReqLin.RequisitionId });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            int LineaId = Convert.ToInt32(form["LineaId"]);
            int ReqId = Convert.ToInt32(form["ReqId"]);

            ReqLinRepo.Delete(LineaId);

            return RedirectToAction("Edit", "Requisition", new { id = ReqId });
        }
    }
}