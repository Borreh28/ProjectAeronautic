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
            var model = rr.GetAll();

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

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            return RedirectToAction("Details", new { });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            r.Id = Int32.Parse(form["Id"]);

            rr.Delete(r.Id);

            return RedirectToAction("All");
        }
    }
}