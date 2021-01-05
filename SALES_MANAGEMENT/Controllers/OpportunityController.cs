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
    public class OpportunityController : Controller
    {
        //String Con.....
        public SqlConnection con;
        public void CONNECTION()
        {
            string constring = ConfigurationManager.ConnectionStrings["LeadConnection"].ToString();
            con = new SqlConnection(constring);
        }
        //CREATE......
        [HttpGet]
        public ActionResult Create()
        {
            OpportunityModel DropdownList = new OpportunityModel()
            {
                PurchaseTimeFormList = GetPurchaseTimeFormList(),
                CurrencyList = GetCurrencyList(),
                PurchesProcessList = GetPurchesProcessList(),
                ForecastCategoryList = GetForecastCategoryList()
            };
            return View(DropdownList);
        }
        //DROP DOWN FOR PurchaseTimeForm.....
        public List<PurchaseTimeForm> GetPurchaseTimeFormList()
            {
                List<PurchaseTimeForm> PurchaseTimeFormList = new List<PurchaseTimeForm>();
                string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(Dbconnection))
                {
                    con.Open();
                    SqlCommand Com = new SqlCommand("SP_PurchaseTimeForm", con);
                    Com.CommandType = CommandType.StoredProcedure;
                    SqlDataReader Sqlreader = Com.ExecuteReader();
                    while (Sqlreader.Read())
                    {
                    PurchaseTimeFormList.Add(new PurchaseTimeForm
                        {
                        PT_Id = Convert.ToInt32(Sqlreader["PT_Id"]),
                        PurchaseTimeForm_Name = Convert.ToString(Sqlreader["PurchaseTimeForm_Name"]),
                        });
                    }
                    con.Close();
                    return PurchaseTimeFormList;
                }
            }
        //DROP DOWN FOR Currency.....
        public List<Currency> GetCurrencyList()
        {
            List<Currency> GetCurrencyList = new List<Currency>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_Currency", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    GetCurrencyList.Add(new Currency
                    {
                        Currency_Id = Convert.ToInt32(Sqlreader["Currency_Id"]),
                        Currency_Name = Convert.ToString(Sqlreader["Currency_Name"]),
                    });
                }
                con.Close();
                return GetCurrencyList;
            }
        }
        //DROP DOWN FOR PurchesProcess.....
        public List<PurchesProcess> GetPurchesProcessList()
        {
            List<PurchesProcess> PurchaseTimeFormList = new List<PurchesProcess>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_PurchesProcess", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    PurchaseTimeFormList.Add(new PurchesProcess
                    {
                        PurchesProcess_Id = Convert.ToInt32(Sqlreader["PurchesProcess_Id"]),
                        PurchesProcess_Name = Convert.ToString(Sqlreader["PurchesProcess_Name"]),
                    });
                }
                con.Close();
                return PurchaseTimeFormList;
            }
        }
        //DROP DOWN FOR ForecastCategory....
        public List<ForecastCategory> GetForecastCategoryList()
        {
            List<ForecastCategory> GetForecastCategoryList = new List<ForecastCategory>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_ForecastCategory", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    GetForecastCategoryList.Add(new ForecastCategory
                    {
                        ForecastCategory_Id = Convert.ToInt32(Sqlreader["ForecastCategory_Id"]),
                        ForecastCategory_Name = Convert.ToString(Sqlreader["ForecastCategory_Name"]),
                    });
                }
                con.Close();
                return GetForecastCategoryList;
            }
        }

        //CREATE: Opportunity...
        // GET: Opportunity.......
        [HttpPost]
        public ActionResult Create(OpportunityModel model)
        {
            OpportunityModel DropdownList = new OpportunityModel()
            {
                PurchaseTimeFormList = GetPurchaseTimeFormList(),
                CurrencyList = GetCurrencyList(),
                PurchesProcessList = GetPurchesProcessList(),
                ForecastCategoryList = GetForecastCategoryList()
            };
            {
                CONNECTION();
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