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

        RequisicionRepository ReqRepo;
        RequisicionLineaRepository ReqLinRepo;
        ProveedorRepository ProvRepo;
        DepartamentoRepository DeptoRepo;
        EstatusRepository EstRepo;
        PeriodoRepository PerRepo;
        PrioridadRepository PrioRepo;

        public RequisitionController()
        {
            Req = new Requisition();
            ReqLin = new RequisitionLine();
            FormReq = new FormularioRequisicion();

            ReqRepo = new RequisicionRepository();
            ReqLinRepo = new RequisicionLineaRepository();
            ProvRepo = new ProveedorRepository();
            DeptoRepo = new DepartamentoRepository();
            EstRepo = new EstatusRepository();
            PerRepo = new PeriodoRepository();
            PrioRepo = new PrioridadRepository();
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
            
            Req.PeriodoId = Periodos.FirstOrDefault().Id;
            Req.DepartamentoId = Departamentos.FirstOrDefault().Id;
            Req.ProveedorId = Proveedores.FirstOrDefault().Id;
            Req.MonedaId = 0;
            Req.EstatusId = 1;
            Req.TotalLineas = 0;
            Req.SubTotal = 0;
            Req.Interes = 0;
            Req.GranTotal = 0;
            Req.CreadoPor = 0;
            Req.Creado = DateTime.Now;
            Req.ActualizadoPor = 0;
            Req.Actualizado = DateTime.Now;
            Req.Descripcion = form["Descripcion"];
            Req.FechaRequisicion = DateTime.Parse(form["FechaRequisicion"]);
            Req.FechaEntrega = DateTime.Parse(form["FechaEntrega"]);
            Req.Comentarios = form["Comentarios"];
            Req.PrioridadId = form["Prioridad"];
            Req.Activo = true;

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
            Req.PeriodoId = Int32.Parse(form["PeriodoId"]);
            Req.DepartamentoId = Deptos.FirstOrDefault().Id;
            Req.ProveedorId = Prvdrs.FirstOrDefault().Id;
            Req.MonedaId = Int32.Parse(form["MonedaId"]);
            Req.EstatusId = Int32.Parse(form["EstatusId"]);
            Req.TotalLineas = Int32.Parse(form["TotalLineas"]);
            Req.SubTotal = Decimal.Parse(form["SubTotal"]);
            Req.Interes = 0;
            Req.GranTotal = Decimal.Parse(form["GranTotal"]);
            Req.CreadoPor = Int32.Parse(form["CreadoPor"]);
            Req.Creado = DateTime.Parse(form["Creado"]);
            Req.ActualizadoPor = Int32.Parse(form["ActualizadoPor"]);
            Req.Actualizado = DateTime.Now;
            Req.Descripcion = form["Descripcion"];
            Req.FechaRequisicion = DateTime.Parse(form["FechaRequisicion"]);
            Req.FechaEntrega = DateTime.Parse(form["FechaEntrega"]);
            Req.Comentarios = form["Comentarios"];
            Req.PrioridadId = form["PrioridadId"];
            Req.Activo = Convert.ToBoolean(form["Activo"]);

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
                Req.PeriodoId = Int32.Parse(form["PeriodoId"]);
                Req.DepartamentoId = Int32.Parse(form["DepartamentoId"]);
                Req.ProveedorId = Int32.Parse(form["ProveedorId"]);
                Req.MonedaId = Int32.Parse(form["MonedaId"]);
                Req.EstatusId = Int32.Parse(form["EstatusId"]);
                Req.TotalLineas = Int32.Parse(form["TotalLineas"]);
                Req.SubTotal = Decimal.Parse(form["SubTotal"]);
                Req.Interes = Decimal.Parse(form["Interes"]);
                Req.GranTotal = Decimal.Parse(form["GranTotal"]);
                Req.CreadoPor = Int32.Parse(form["CreadoPor"]);
                Req.Creado = DateTime.Parse(form["Creado"]);
                Req.ActualizadoPor = Int32.Parse(form["ActualizadoPor"]);
                Req.Actualizado = DateTime.Parse(form["Actualizado"]);
                Req.Descripcion = form["Descripcion"];
                Req.FechaRequisicion = DateTime.Parse(form["FechaRequisicion"]);
                Req.FechaEntrega = DateTime.Parse(form["FechaEntrega"]);
                Req.Comentarios = form["Comentarios"];
                Req.PrioridadId = form["PrioridadId"];
                Req.Activo = false;

                ReqRepo.Update(Req);
            }

            return RedirectToAction("All");
        }
    }
}