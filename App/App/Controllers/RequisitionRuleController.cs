using App.DAL;
using App.Entities;
using System;
using System.Web.Mvc;

namespace App.Controllers
{
    public class RequisitionRuleController : Controller
    {
        RequisitionRule requisitionRule;
        
        RequisitionRuleRepository requisitionRuleRepository;

        public RequisitionRuleController()
        {
            requisitionRule = new RequisitionRule();
            
            requisitionRuleRepository = new RequisitionRuleRepository();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            string authorization = "";
            decimal total = Convert.ToDecimal(form["Total"]);

            if (total < 5000)
            {
                authorization = "Manager";
            }
            else if (total >= 5000 && total < 10000)
            {
                authorization = "Supervisor";
            }
            else if(total >= 10000)
            {
                authorization = "Executive";
            }

            requisitionRule.RequisitionId = Convert.ToInt32(form["RequisitionId"]);
            requisitionRule.AuthorizationState = authorization;
            requisitionRule.CreatedBy = 0;
            requisitionRule.Created = DateTime.Now;
            requisitionRule.UpdatedBy = 0;
            requisitionRule.Updated = DateTime.Now;

            return RedirectToAction("Details", "Requisition", new { id = requisitionRule.RequisitionId });
        }
    }
}