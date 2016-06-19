using App.DAL;
using App.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace App.Controllers
{
    public class RequisitionLineController : Controller
    {
        Requisition requisition;
        RequisitionLine requisitionLine;
        
        ProductRepository productRepository;
        RequisitionRepository requisitionRepository;
        RequisitionLineRepository requisitionLineRepository;

        public RequisitionLineController()
        {
            requisition = new Requisition();
            requisitionLine = new RequisitionLine();
            
            productRepository = new ProductRepository();
            requisitionRepository = new RequisitionRepository();
            requisitionLineRepository = new RequisitionLineRepository();
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
            requisitionLine.Id = Convert.ToInt32(form["LineId"]);
            requisitionLine.RequisitionId = Convert.ToInt32(form["RequisitionId"]);
            requisitionLine.Line = Convert.ToInt32(form["Line"]);
            requisitionLine.ProductId = Convert.ToInt32(form["ProductId"]);
            requisitionLine.Quantity = Convert.ToInt32(form["Quantity"]);
            requisitionLine.SalePrice = Convert.ToDecimal(form["Price"]);
            requisitionLine.Description = form["Description"];
            requisitionLine.CreatedBy = Convert.ToInt32(form["CreatedBy"]);
            requisitionLine.Created = Convert.ToDateTime(form["Created"]);
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