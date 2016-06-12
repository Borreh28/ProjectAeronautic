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

        public RequisitionController()
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

        public ActionResult All()
        {
            var model = ReqRepo.GetAllActive();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            FormReq.Requsiciones = ReqRepo.GetById(id);
            FormReq.Lineas = ReqLinRepo.GetByIdRequisicion(id);

            return View(FormReq);
        }

        public ActionResult Add()
        {
            FormReq.Proveedores = ProvRepo.GetAll();
            FormReq.Departamentos = DeptoRepo.GetAll();
            FormReq.Estatus = EstRepo.GetAll();
            FormReq.Periodos = PerRepo.GetAll();
            FormReq.Prioridades = PrioRepo.GetAll();

            return View(FormReq);
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            string Departamento = form["Departamento"];
            var Departamentos = FormReq.Departamentos;
            Departamentos = DeptoRepo.GetByName(Departamento);

            string Proveedor = form["Proveedor"];
            var Proveedores = FormReq.Proveedores;
            Proveedores = ProvRepo.GetByName(Proveedor);

            string Periodo = form["Periodo"];
            var Periodos = FormReq.Periodos;
            Periodos = PerRepo.GetByName(Periodo);
            
            Req.PeriodId = Periodos.FirstOrDefault().Id;
            Req.DepartmentId = Departamentos.FirstOrDefault().Id;
            Req.SupplierId = Proveedores.FirstOrDefault().Id;
            Req.MonedaId = 0;
            Req.StatusId = 1;
            Req.TotalLines = 0;
            Req.SubTotal = 0;
            Req.Interest = 0;
            Req.Total = 0;
            Req.CreatedBy = 0;
            Req.Created = DateTime.Now;
            Req.UpdatedBy = 0;
            Req.Updated = DateTime.Now;
            Req.Description = form["Descripcion"];
            Req.RequisitionDate = DateTime.Parse(form["FechaRequisicion"]);
            Req.DeliveryDate = DateTime.Parse(form["FechaEntrega"]);
            Req.Commentaries = form["Comentarios"];
            Req.PriorityId = form["Prioridad"];
            Req.Active = true;

            ReqRepo.Add(Req);

            return RedirectToAction("Edit", new { id = Req.Id });
        }

        public ActionResult Edit(int id)
        {
            FormReq.Requsiciones = ReqRepo.GetById(id);
            FormReq.Lineas = ReqLinRepo.GetByIdRequisicion(id);
            FormReq.Proveedores = ProvRepo.GetAll();
            FormReq.Departamentos = DeptoRepo.GetAll();

            return View(FormReq);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            string Depto = form["Departamento"];
            var Deptos = FormReq.Departamentos;
            Deptos = DeptoRepo.GetByName(Depto);

            string Prvdr = form["Proveedor"];
            var Prvdrs = FormReq.Proveedores;
            Prvdrs = ProvRepo.GetByName(Prvdr);

            Req.Id = Int32.Parse(form["ReqId"]);
            Req.PeriodId = Int32.Parse(form["PeriodoId"]);
            Req.DepartmentId = Deptos.FirstOrDefault().Id;
            Req.SupplierId = Prvdrs.FirstOrDefault().Id;
            Req.MonedaId = Int32.Parse(form["MonedaId"]);
            Req.StatusId = Int32.Parse(form["EstatusId"]);
            Req.TotalLines = Int32.Parse(form["TotalLineas"]);
            Req.SubTotal = Decimal.Parse(form["SubTotal"]);
            Req.Interest = 0;
            Req.Total = Decimal.Parse(form["GranTotal"]);
            Req.CreatedBy = Int32.Parse(form["CreadoPor"]);
            Req.Created = DateTime.Parse(form["Creado"]);
            Req.UpdatedBy = Int32.Parse(form["ActualizadoPor"]);
            Req.Updated = DateTime.Now;
            Req.Description = form["Descripcion"];
            Req.RequisitionDate = DateTime.Parse(form["FechaRequisicion"]);
            Req.DeliveryDate = DateTime.Parse(form["FechaEntrega"]);
            Req.Commentaries = form["Comentarios"];
            Req.PriorityId = form["PrioridadId"];
            Req.Active = Convert.ToBoolean(form["Activo"]);

            ReqRepo.Update(Req);

            return RedirectToAction("Details", new { Req.Id });
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
                Req.Id = Int32.Parse(form["Id"]);

                ReqRepo.Delete(Req.Id);
            }
            else
            {
                Req.Id = Int32.Parse(form["Id"]);
                Req.PeriodId = Int32.Parse(form["PeriodoId"]);
                Req.DepartmentId = Int32.Parse(form["DepartamentoId"]);
                Req.SupplierId = Int32.Parse(form["ProveedorId"]);
                Req.MonedaId = Int32.Parse(form["MonedaId"]);
                Req.StatusId = Int32.Parse(form["EstatusId"]);
                Req.TotalLines = Int32.Parse(form["TotalLineas"]);
                Req.SubTotal = Decimal.Parse(form["SubTotal"]);
                Req.Interest = Decimal.Parse(form["Interes"]);
                Req.Total = Decimal.Parse(form["GranTotal"]);
                Req.CreatedBy = Int32.Parse(form["CreadoPor"]);
                Req.Created = DateTime.Parse(form["Creado"]);
                Req.UpdatedBy = Int32.Parse(form["ActualizadoPor"]);
                Req.Updated = DateTime.Parse(form["Actualizado"]);
                Req.Description = form["Descripcion"];
                Req.RequisitionDate = DateTime.Parse(form["FechaRequisicion"]);
                Req.DeliveryDate = DateTime.Parse(form["FechaEntrega"]);
                Req.Commentaries = form["Comentarios"];
                Req.PriorityId = form["PrioridadId"];
                Req.Active = false;

                ReqRepo.Update(Req);
            }

            return RedirectToAction("All");
        }
    }
}