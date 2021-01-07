using SALES_MANAGEMENT.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SALES_MANAGEMENT.Controllers
{
    public class QuorteController : Controller
    {
        //String Con.....
        public SqlConnection con;
        public void CONNECTION()
        {
            string constring = ConfigurationManager.ConnectionStrings["LeadConnection"].ToString();
            con = new SqlConnection(constring);
        }
        // GET: Quorte
        public ActionResult Create()
        {
            return View();
        }

        //Create Quorte
        [HttpPost]
        public ActionResult Create(QuoteModel model)
        {
            QuoteModel DropdownList = new QuoteModel()
            {
                
            };

            {
                CONNECTION();
                SqlCommand Command = new SqlCommand("SP_Quote_Insert", con);
                Command.CommandType = CommandType.StoredProcedure;
                con.Open();
                Command.Parameters.AddWithValue("@Name", model.Name);
                Command.Parameters.AddWithValue("@Currency", model.Currency);
                Command.Parameters.AddWithValue("@Opportunity", model.Opportunity);
                Command.Parameters.AddWithValue("@PotentialCustomer", model.PotentialCustomer);
                Command.Parameters.AddWithValue("@PriceList", model.PriceList);
                Command.Parameters.AddWithValue("@QuoteExpiresOn", model.QuoteExpiresOn);
                Command.Parameters.AddWithValue("@StatusReason", model.StatusReason);
                Command.Parameters.AddWithValue("@Description", model.Description);
                Command.Parameters.AddWithValue("@PaymentTerms", model.PaymentTerms);
                Command.Parameters.AddWithValue("@FreightTerms", model.FreightTerms); 
                Command.Parameters.AddWithValue("@BillToStreet", model.BillToStreet);
                Command.Parameters.AddWithValue("@BillToCity", model.BillToCity);
                Command.Parameters.AddWithValue("@BillToCountry", model.BillToCountry);
                Command.Parameters.AddWithValue("@BillingPostalCode", model.BillingPostalCode);
                Command.Parameters.AddWithValue("@ShipTo", model.ShipTo);
                Command.Parameters.AddWithValue("@ShippingMethod", model.ShippingMethod);
                Command.Parameters.AddWithValue("@ShipToStreet", model.ShipToStreet);
                Command.Parameters.AddWithValue("@ShipToState", model.ShipToState);
                Command.Parameters.AddWithValue("@ShipToCity", model.ShipToCity);
                Command.Parameters.AddWithValue("@ShipToCountry", model.ShipToCountry);
                Command.Parameters.AddWithValue("@ShipingPostalCode", model.ShipingPostalCode);
                Command.ExecuteNonQuery();
                con.Close();
                ViewBag.Message = "QUOTE CREATE SUCCESSFULLY :)";
                return View(DropdownList);
            }
        }
    }
}