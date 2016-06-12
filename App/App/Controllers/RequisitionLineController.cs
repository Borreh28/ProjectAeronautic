using App.DAL;
using App.Entities;
using App.ViewModels;
using System;
using System.Web.Mvc;

namespace App.Controllers
{
    public class RequisitionLineController : Controller
    {
        Requisition requisition;
        RequisitionLine requisitionLine;
        RequisitionForm requisitionForm;

        RequisitionRepository requisitionRepository;
        RequisitionLineRepository requisitionLineRepository;
        SupplierRepository supplierRepository;
        DepartmentRepository departmentRepository;
        StatusRepository statusRepository;
        PeriodRepository periodRepository;
        PriorityRepository priorityRepository;

        public RequisitionLineController()
        {
            requisition = new Requisition();
            requisitionLine = new RequisitionLine();
            requisitionForm = new RequisitionForm();

            requisitionRepository = new RequisitionRepository();
            requisitionLineRepository = new RequisitionLineRepository();
            supplierRepository = new SupplierRepository();
            departmentRepository = new DepartmentRepository();
            statusRepository = new StatusRepository();
            periodRepository = new PeriodRepository();
            priorityRepository = new PriorityRepository();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            requisitionLine.Id = Convert.ToInt32( form["LineaId"]);
            requisitionLine.RequisitionId = Convert.ToInt32(form["ReqId"]);
            requisitionLine.Line = Convert.ToInt32(form["Linea"]);
            requisitionLine.ProductId = Convert.ToInt32(form["ParteId"]);
            requisitionLine.Quantity = Convert.ToInt32(form["Cantidad"]);
            requisitionLine.SalePrice = Convert.ToDecimal(form["Precio"]);
            requisitionLine.Description = form["Descripcion"];
            requisitionLine.CreatedBy = 0;
            requisitionLine.Created = DateTime.Now;
            requisitionLine.UpdatedBy = 0;
            requisitionLine.Updated = DateTime.Now;

            requisitionLineRepository.Add(requisitionLine);

            return RedirectToAction("Edit", "Requisition", new { id = requisitionLine.RequisitionId });
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            requisitionLine.Id = Convert.ToInt32(form["LineaId"]);
            requisitionLine.RequisitionId = Convert.ToInt32(form["ReqId"]);
            requisitionLine.Line = Convert.ToInt32(form["Linea"]);
            requisitionLine.ProductId = Convert.ToInt32(form["ParteId"]);
            requisitionLine.Quantity = Convert.ToInt32(form["Cantidad"]);
            requisitionLine.SalePrice = Convert.ToDecimal(form["Precio"]);
            requisitionLine.Description = form["Descripcion"];
            requisitionLine.CreatedBy = Convert.ToInt32(form["CreadoPor"]);
            requisitionLine.Created = Convert.ToDateTime(form["Creado"]);
            requisitionLine.UpdatedBy = 0;
            requisitionLine.Updated = DateTime.Now;

            requisitionLineRepository.Update(requisitionLine);

            return RedirectToAction("Edit", "Requisition", new { id = requisitionLine.RequisitionId });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            int LineId = Convert.ToInt32(form["LineaId"]);
            int RequisitionId = Convert.ToInt32(form["ReqId"]);

            requisitionLineRepository.Delete(LineId);

            return RedirectToAction("Edit", "Requisition", new { id = RequisitionId });
        }
    }
}