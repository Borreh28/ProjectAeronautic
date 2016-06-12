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
        RequisitionLine requisitionLine;
        RequisitionForm requisitionForm;

        RequisitionRepository requisitionRepository;
        RequisitionLineRepository requisitionLineRepository;
        SupplierRepository supplierRepository;
        DepartmentRepository departmentRepository;
        StatusRepository statusRepository;
        PeriodRepository periodRepository;
        PriorityRepository priorityRepository;

        public RequisitionController()
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

        public ActionResult All()
        {
            var model = requisitionRepository.GetAllActive();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            requisitionForm.Requisitions = requisitionRepository.GetById(id);
            requisitionForm.Lines = requisitionLineRepository.GetByRequisitionId(id);

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
            requisitionForm.Requisitions = requisitionRepository.GetById(id);
            requisitionForm.Lines = requisitionLineRepository.GetByRequisitionId(id);
            requisitionForm.Suppliers = supplierRepository.GetAll();
            requisitionForm.Departments = departmentRepository.GetAll();

            return View(requisitionForm);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            string DepartmentName = form["Departamento"];
            var Departments = requisitionForm.Departments;
            Departments = departmentRepository.GetByName(DepartmentName);

            string SupplierName = form["Proveedor"];
            var Suppliers = requisitionForm.Suppliers;
            Suppliers = supplierRepository.GetByName(SupplierName);

            requisition.Id = Int32.Parse(form["ReqId"]);
            requisition.PeriodId = Int32.Parse(form["PeriodoId"]);
            requisition.DepartmentId = Departments.FirstOrDefault().Id;
            requisition.SupplierId = Suppliers.FirstOrDefault().Id;
            requisition.StatusId = Int32.Parse(form["EstatusId"]);
            requisition.TotalLines = Int32.Parse(form["TotalLineas"]);
            requisition.SubTotal = Decimal.Parse(form["SubTotal"]);
            requisition.Interest = 0;
            requisition.Total = Decimal.Parse(form["GranTotal"]);
            requisition.CreatedBy = Int32.Parse(form["CreadoPor"]);
            requisition.Created = DateTime.Parse(form["Creado"]);
            requisition.UpdatedBy = Int32.Parse(form["ActualizadoPor"]);
            requisition.Updated = DateTime.Now;
            requisition.Description = form["Descripcion"];
            requisition.RequisitionDate = DateTime.Parse(form["FechaRequisicion"]);
            requisition.DeliveryDate = DateTime.Parse(form["FechaEntrega"]);
            requisition.Commentaries = form["Comentarios"];
            requisition.PriorityId = Convert.ToInt32(form["PrioridadId"]);
            requisition.Active = Convert.ToBoolean(form["Activo"]);

            requisitionRepository.Update(requisition);

            return RedirectToAction("Details", new { requisition.Id });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            var check = form["Permanente"];
            bool Permanent = false;

            if (check != "false")
            {
                check = "true";
                Permanent = Convert.ToBoolean(check);
            }

            if (Permanent)
            {
                requisition.Id = Int32.Parse(form["Id"]);

                requisitionRepository.Delete(requisition.Id);
            }
            else
            {
                requisition.Id = Int32.Parse(form["Id"]);
                requisition.PeriodId = Int32.Parse(form["PeriodoId"]);
                requisition.DepartmentId = Int32.Parse(form["DepartamentoId"]);
                requisition.SupplierId = Int32.Parse(form["ProveedorId"]);
                requisition.StatusId = Int32.Parse(form["EstatusId"]);
                requisition.TotalLines = Int32.Parse(form["TotalLineas"]);
                requisition.SubTotal = Decimal.Parse(form["SubTotal"]);
                requisition.Interest = Decimal.Parse(form["Interes"]);
                requisition.Total = Decimal.Parse(form["GranTotal"]);
                requisition.CreatedBy = Int32.Parse(form["CreadoPor"]);
                requisition.Created = DateTime.Parse(form["Creado"]);
                requisition.UpdatedBy = Int32.Parse(form["ActualizadoPor"]);
                requisition.Updated = DateTime.Parse(form["Actualizado"]);
                requisition.Description = form["Descripcion"];
                requisition.RequisitionDate = DateTime.Parse(form["FechaRequisicion"]);
                requisition.DeliveryDate = DateTime.Parse(form["FechaEntrega"]);
                requisition.Commentaries = form["Comentarios"];
                requisition.PriorityId = Convert.ToInt32(form["PrioridadId"]);
                requisition.Active = false;

                requisitionRepository.Update(requisition);
            }

            return RedirectToAction("All");
        }
    }
}