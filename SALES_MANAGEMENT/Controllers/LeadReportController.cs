using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SALES_MANAGEMENT.Controllers
{
    public class LeadReportController : Controller
    {
        // GET: LeadReport
        public ActionResult Index()
        {
            SaleEntities entities = new SaleEntities();
            var list = from TBL_Leads in entities.TBL_Leads.Take(50)
                       select TBL_Leads;
            return View(list);
        }
    }
}