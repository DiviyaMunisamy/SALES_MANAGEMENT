using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SALES_MANAGEMENT.Models; 

namespace SALES_MANAGEMENT.Controllers
{
    public class OpportunityController : Controller
    {
        private SqlConnection con;
        //To Switch Connection String................................//
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["LeadConnection"].ToString();
            con = new SqlConnection(constring);
        }
        // GET: Opportunity
        public ActionResult Create(OpportunityModel model, HttpPostedFileBase file)
        {
            
            {
                Connection();
                SqlCommand Command = new SqlCommand("SP_Opportunity_Insert", con);
                Command.CommandType = CommandType.StoredProcedure;
                con.Open();
                Command.Parameters.AddWithValue("@Topic", model.Topic);
                Command.Parameters.AddWithValue("@Contact", model.Contact);
                Command.Parameters.AddWithValue("@Account", model.Account);
                Command.Parameters.AddWithValue("@PurchaseTimeForm", model.PurchaseTimeForm);
                Command.Parameters.AddWithValue("@Currency", model.Currency);
                Command.Parameters.AddWithValue("@BudgetAmount", model.BudgetAmount);
                Command.Parameters.AddWithValue("@PurchesProcess", model.PurchesProcess);
                Command.Parameters.AddWithValue("@ForecastCategory", model.ForecastCategory);
                Command.Parameters.AddWithValue("@Description", model.Description);
                Command.Parameters.AddWithValue("@CurrentSuitation", model.CurrentSuitation);
                Command.Parameters.AddWithValue("@CustommerNeed", model.CustommerNeed);
                Command.Parameters.AddWithValue("@ProposedSolution", model.ProposedSolution);          
                Command.ExecuteNonQuery();
                con.Close();
                ViewBag.Message = "SAVED SUCCESSFULLY :)";
                return View();
            }

        }
    }
}