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
            return View();
        }
    }
}