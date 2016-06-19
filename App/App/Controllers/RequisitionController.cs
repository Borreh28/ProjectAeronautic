using App.DAL;
using App.Entities;
using App.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace App.Controllers
{
    public class RequisitionController : Controller
    {
        Requisition requisition;
        RequisitionForm requisitionForm;

        DepartmentRepository departmentRepository;
        PeriodRepository periodRepository;
        PriorityRepository priorityRepository;
        ProductRepository productRepository;
        RequisitionRepository requisitionRepository;
        RequisitionLineRepository requisitionLineRepository;
        RequisitionRuleRepository requisitionRuleRepository;
        StatusRepository statusRepository;
        SupplierRepository supplierRepository; 

        public RequisitionController()
        {
            requisition = new Requisition();
            requisitionForm = new RequisitionForm();

            departmentRepository = new DepartmentRepository();
            periodRepository = new PeriodRepository();
            priorityRepository = new PriorityRepository();
            productRepository = new ProductRepository();
            requisitionRepository = new RequisitionRepository();
            requisitionLineRepository = new RequisitionLineRepository();
            requisitionRuleRepository = new RequisitionRuleRepository();
            statusRepository = new StatusRepository();
            supplierRepository = new SupplierRepository();
        }

        public ActionResult All()
        {
            var model = requisitionRepository.GetAllActive();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            requisitionForm.Requisitions = requisitionRepository.GetById(id);
            requisitionForm.Lines = requisitionLineRepository.GetByRequisitionId(id);
            requisitionForm.Rules = requisitionRuleRepository.GetAllByRequisitionId(id);

            return View(requisitionForm);
        }

        public ActionResult Add()
        {
            requisitionForm.Suppliers = supplierRepository.GetAll();
            requisitionForm.Departments = departmentRepository.GetAll();
            requisitionForm.Status = statusRepository.GetAll();
            requisitionForm.Periods = periodRepository.GetAll();
            requisitionForm.Priorities = priorityRepository.GetAll();

            return View(requisitionForm);
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            requisition.PeriodId = Convert.ToInt32(form["Period"]);
            requisition.DepartmentId = Convert.ToInt32(form["Department"]);
            requisition.SupplierId = Convert.ToInt32(form["Supplier"]);
            requisition.StatusId = 1;
            requisition.PriorityId = Convert.ToInt32(form["Priority"]);
            requisition.Active = true;
            requisition.TotalLines = 0;
            requisition.SubTotal = 0;
            requisition.Interest = 0;
            requisition.Total = 0;
            requisition.RequisitionDate = DateTime.Parse(form["RequisitionDate"]);
            requisition.DeliveryDate = DateTime.Parse(form["DeliveryDate"]);
            requisition.Description = form["Description"];
            requisition.Commentaries = form["Commentaries"];
            requisition.CreatedBy = 0;
            requisition.Created = DateTime.Now;
            requisition.UpdatedBy = 0;
            requisition.Updated = DateTime.Now;

            requisitionRepository.Add(requisition);

            return RedirectToAction("Edit", new { id = requisition.Id });
        }

        public ActionResult Edit(int id)
        {
            var requisition = requisitionRepository.GetById(id);
            int supplierId = requisition.FirstOrDefault().SupplierId;

            requisitionForm.Requisitions = requisitionRepository.GetById(id);
            requisitionForm.Lines = requisitionLineRepository.GetByRequisitionId(id);
            requisitionForm.Suppliers = supplierRepository.GetAll();
            requisitionForm.Departments = departmentRepository.GetAll();
            requisitionForm.Products = productRepository.GetAllBySupplierId(supplierId);

            return View(requisitionForm);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            requisition.Id = Int32.Parse(form["RequisitionId"]);
            requisition.PeriodId = Int32.Parse(form["PeriodId"]);
            requisition.DepartmentId = Int32.Parse(form["DepartmentId"]);
            requisition.SupplierId = Int32.Parse(form["SupplierId"]);
            requisition.StatusId = Int32.Parse(form["StatusId"]);
            requisition.PriorityId = Convert.ToInt32(form["PriorityId"]);
            requisition.Active = Convert.ToBoolean(form["Active"]);
            requisition.TotalLines = Int32.Parse(form["TotalLines"]);
            requisition.SubTotal = Decimal.Parse(form["SubTotal"]);
            requisition.Interest = Decimal.Parse(form["Interest"]);
            requisition.Total = Decimal.Parse(form["Total"]);
            requisition.RequisitionDate = DateTime.Parse(form["RequisitionDate"]);
            requisition.DeliveryDate = DateTime.Parse(form["DeliveryDate"]);
            requisition.Description = form["Description"];
            requisition.Commentaries = form["Commentaries"];
            requisition.CreatedBy = Int32.Parse(form["CreatedBy"]);
            requisition.Created = DateTime.Parse(form["Created"]);
            requisition.UpdatedBy = 0;
            requisition.Updated = DateTime.Now;
            
            requisitionRepository.Update(requisition);

            return RedirectToAction("Details", new { requisition.Id });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            var Check = form["Permanent"];
            bool Permanent = false;

            if (Check != "false")
            {
                Check = "true";
                Permanent = Convert.ToBoolean(Check);
            }

            if (Permanent)
            {
                requisition.Id = Int32.Parse(form["RequisitionId"]);

                requisitionRepository.Delete(requisition.Id);
            }
            else
            {
                requisition.Id = Int32.Parse(form["RequisitionId"]);
                requisition.PeriodId = Int32.Parse(form["PeriodId"]);
                requisition.DepartmentId = Int32.Parse(form["DepartmentId"]);
                requisition.SupplierId = Int32.Parse(form["SupplierId"]);
                requisition.StatusId = Int32.Parse(form["StatusId"]);
                requisition.PriorityId = Convert.ToInt32(form["PriorityId"]);
                requisition.Active = false;
                requisition.TotalLines = Int32.Parse(form["TotalLines"]);
                requisition.SubTotal = Decimal.Parse(form["SubTotal"]);
                requisition.Interest = Decimal.Parse(form["Interest"]);
                requisition.Total = Decimal.Parse(form["Total"]);
                requisition.RequisitionDate = DateTime.Parse(form["RequisitionDate"]);
                requisition.DeliveryDate = DateTime.Parse(form["DeliveryDate"]);
                requisition.Description = form["Description"];
                requisition.Commentaries = form["Commentaries"];
                requisition.CreatedBy = Int32.Parse(form["CreatedBy"]);
                requisition.Created = DateTime.Parse(form["Created"]);
                requisition.UpdatedBy = Int32.Parse(form["UpdatedBy"]);
                requisition.Updated = DateTime.Parse(form["Updated"]);

                requisitionRepository.Update(requisition);
            }

            return RedirectToAction("All");
        }
    }
}