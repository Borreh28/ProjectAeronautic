﻿using App.DAL;
using App.Entities;
using App.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace App.Controllers
{
    public class RequisitionLineController : Controller
    {
        Requisition requisition;
        RequisitionLine requisitionLine;
        RequisitionForm requisitionForm;
        
        DepartmentRepository departmentRepository;
        PeriodRepository periodRepository;
        PriorityRepository priorityRepository;
        ProductRepository productRepository;
        RequisitionRepository requisitionRepository;
        RequisitionLineRepository requisitionLineRepository;
        StatusRepository statusRepository;
        SupplierRepository supplierRepository;

        public RequisitionLineController()
        {
            requisition = new Requisition();
            requisitionLine = new RequisitionLine();
            requisitionForm = new RequisitionForm();
            
            departmentRepository = new DepartmentRepository();
            periodRepository = new PeriodRepository();
            priorityRepository = new PriorityRepository();
            productRepository = new ProductRepository();
            requisitionRepository = new RequisitionRepository();
            requisitionLineRepository = new RequisitionLineRepository();
            statusRepository = new StatusRepository();
            supplierRepository = new SupplierRepository();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            var product = productRepository.GetByName(form["Product"]);

            requisitionLine.RequisitionId = Convert.ToInt32(form["RequisitionId"]);
            requisitionLine.Line = Convert.ToInt32(form["Line"]);
            requisitionLine.ProductId = product.FirstOrDefault().Id;
            requisitionLine.Quantity = Convert.ToInt32(form["Quantity"]);
            requisitionLine.SalePrice = Convert.ToDecimal(form["Price"]);
            requisitionLine.Description = form["Description"];
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
            int LineId = Convert.ToInt32(form["LineId"]);
            int RequisitionId = Convert.ToInt32(form["RequisitionId"]);

            requisitionLineRepository.Delete(LineId);

            return RedirectToAction("Edit", "Requisition", new { id = RequisitionId });
        }
    }
}