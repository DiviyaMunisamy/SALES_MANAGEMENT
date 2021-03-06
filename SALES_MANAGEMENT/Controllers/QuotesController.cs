﻿using SALES_MANAGEMENT.Models;
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
    public class QuotesController : Controller
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
            QuoteModel DropdownList = new QuoteModel()
            {
                ShippingMethodList = GetShippingMethodList(),
                ShipToList = GetShipToList(),
                PaymentTermsList = GetPaymentTermsList(),
                StatusReasonList = GetStatusReasonList(),
                FreightTermsList = GetFreightTermsList(),
                CurrencyList = GetCurrencyForQuotesList()
            };
            return View(DropdownList);
        }
        //DROP DOWN FOR ShippingMethod.....
        public List<ShippingMethod> GetShippingMethodList()
        {
            List<ShippingMethod> ShippingMethodList = new List<ShippingMethod>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_Quote_DropDownShippingMethod", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    ShippingMethodList.Add(new ShippingMethod
                    {
                        ShippingMethod_Id = Convert.ToInt32(Sqlreader["ShippingMethod_Id"]),
                        ShippingMethod_Name = Convert.ToString(Sqlreader["ShippingMethod_Name"]),
                    });
                }
                con.Close();
                return ShippingMethodList;
            }
        }
        //DROP DOWN FOR ShipTo.....
        public List<ShipTo> GetShipToList()
        {
            List<ShipTo> ShipToList = new List<ShipTo>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_Quote_DropDownShipTo", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    ShipToList.Add(new ShipTo
                    {
                        ShipTo_Id = Convert.ToInt32(Sqlreader["ShipTo_Id"]),
                        ShipTo_NAME = Convert.ToString(Sqlreader["ShipTo_NAME"]),
                    });
                }
                con.Close();
                return ShipToList;
            }
        }

        //DROP DOWN FOR PaymentTerms.....
        public List<PaymentTerms> GetPaymentTermsList()
        {
            List<PaymentTerms> PaymentTermsList = new List<PaymentTerms>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_Quote_DropDownPaymentTerms", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    PaymentTermsList.Add(new PaymentTerms
                    {
                        Payment_Id = Convert.ToInt32(Sqlreader["Payment_Id"]),
                        PaymentTerm_Name = Convert.ToString(Sqlreader["PaymentTerm_Name"]),
                    });
                }
                con.Close();
                return PaymentTermsList;
            }
        }
        //DROP DOWN FOR StatusReason.....
        public List<StatusReason> GetStatusReasonList()
        {
            List<StatusReason> StatusReasonList = new List<StatusReason>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_Quote_DropDownStatusReason", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    StatusReasonList.Add(new StatusReason
                    {
                        StatusReason_Id = Convert.ToInt32(Sqlreader["StatusReason_Id"]),
                        StatusReason_NAME = Convert.ToString(Sqlreader["StatusReason_NAME"]),
                    });
                }
                con.Close();
                return StatusReasonList;
            }
        }

        //DROP DOWN FOR FreightTerms.....
        public List<FreightTerms> GetFreightTermsList()
        {
            List<FreightTerms> FreightTermsList = new List<FreightTerms>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_Quote_DropDownFreightTerms", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    FreightTermsList.Add(new FreightTerms
                    {
                        Freight_Id = Convert.ToInt32(Sqlreader["Freight_Id"]),
                        FreightTerm_Name = Convert.ToString(Sqlreader["FreightTerm_Name"]),
                    });
                }
                con.Close();
                return FreightTermsList;
            }
        }


        //DROP DOWN FOR CurrencyForQuotes.....
        public List<CurrencyForQuotes> GetCurrencyForQuotesList()
        {
            List<CurrencyForQuotes> CurrencyList = new List<CurrencyForQuotes>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_Quote_DropDownForQuoteCurrency", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    CurrencyList.Add(new CurrencyForQuotes
                    {
                        Currency_Id = Convert.ToInt32(Sqlreader["Currency_Id"]),
                        Currency_Name = Convert.ToString(Sqlreader["Currency_Name"]),
                    });
                }
                con.Close();
                return CurrencyList;
            }
        }
    

        //Create Quorte
        [HttpPost]
        public ActionResult Create(QuoteModel model)
        {
        QuoteModel DropdownList = new QuoteModel()
        {
            ShippingMethodList = GetShippingMethodList(),
            ShipToList = GetShipToList(),
            PaymentTermsList = GetPaymentTermsList(),
            StatusReasonList = GetStatusReasonList(),
            FreightTermsList = GetFreightTermsList(),
            CurrencyList = GetCurrencyForQuotesList()
        };

        {
                CONNECTION();
                SqlCommand Command = new SqlCommand("SP_Quote_Insert", con);
                Command.CommandType = CommandType.StoredProcedure;
                con.Open();
                Command.Parameters.AddWithValue("@RefQuoteId", model.RefQuoteId);
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
                Command.Parameters.AddWithValue("@BillToState", model.BillToState);
                Command.Parameters.AddWithValue("@BillToCity", model.BillToCity);
                Command.Parameters.AddWithValue("@BillToCountry", model.BillToCountry);
                Command.Parameters.AddWithValue("@BillingPostalCode", model.BillingPostalCode);
                Command.Parameters.AddWithValue("@ShipTo", model.ShipTo);
                Command.Parameters.AddWithValue("@ShippingMethod", model.ShippingMethod);
                Command.Parameters.AddWithValue("@ShipToStreet", model.ShipToStreet);
                Command.Parameters.AddWithValue("@ShipToState", model.ShipToState);
                Command.Parameters.AddWithValue("@ShipToCity", model.ShipToCity);
                Command.Parameters.AddWithValue("@ShipToCountry", model.ShipToCountry);
                Command.Parameters.AddWithValue("@ShipingPostalCodes", model.ShipingPostalCodes);
                Command.ExecuteNonQuery();
                con.Close();
                ViewBag.Message = "QUOTE CREATE SUCCESSFULLY :)"; 
                return View(DropdownList);
            }
        }

        //LIST INDEX
        public ActionResult QuotesIndex()
        {
            List<QuoteModel> QuoteList = new List<QuoteModel>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_Quote_SelectAll", con);
                Com.CommandType = CommandType.StoredProcedure;

                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    var customer = new QuoteModel();
                    customer.RefQuoteId = Convert.ToInt32(Sqlreader["RefQuoteId"]);
                    customer.Name = Sqlreader["Name"].ToString();
                    customer.Currency = Sqlreader["Currency"].ToString();
                    customer.Opportunity = Sqlreader["Opportunity"].ToString();
                    customer.PotentialCustomer = Sqlreader["PotentialCustomer"].ToString();
                    customer.PriceList = Sqlreader["PriceList"].ToString();
                    customer.QuoteExpiresOn = Convert.ToDateTime(Sqlreader["QuoteExpiresOn"]);
                    customer.StatusReason = Sqlreader["StatusReason"].ToString();
                    customer.Description = Sqlreader["Description"].ToString();
                    customer.PaymentTerms = Sqlreader["PaymentTerms"].ToString();
                    customer.FreightTerms = Sqlreader["FreightTerms"].ToString();
                    customer.BillToStreet = Sqlreader["BillToStreet"].ToString();
                    customer.BillToCountry = Sqlreader["BillToCountry"].ToString();
                    customer.BillingPostalCode = Sqlreader["BillingPostalCode"].ToString();
                    customer.ShipTo = Sqlreader["ShipTo"].ToString();
                    customer.ShippingMethod = Sqlreader["ShippingMethod"].ToString();
                    customer.ShipToStreet = Sqlreader["ShipToStreet"].ToString();
                    customer.ShipToCity = Sqlreader["ShipToCity"].ToString();
                    customer.ShipToState = Sqlreader["ShipToState"].ToString();
                    customer.ShipToCountry = Sqlreader["ShipToCountry"].ToString();
                    customer.ShipingPostalCodes = Convert.ToInt32(Sqlreader["ShipingPostalCodes"]);
                    QuoteList.Add(customer);
                }
                return View(QuoteList);
            }
        }


        //Qualified opportunity List
        public ActionResult IndexOppQuote()
        {
            List<OpportunityModel> OpportunityList = new List<OpportunityModel>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_SelectAll_OpportunityQualify", con);
                Com.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    var customer = new OpportunityModel();
                    //customer.LeadId = Convert.ToInt32(Sqlreader["LeadId"]);
                    customer.RefOppId = Convert.ToInt32(Sqlreader["RefOppId"]);
                    customer.Topic = Sqlreader["Topic"].ToString();
                    customer.Contact = Convert.ToInt64(Sqlreader["Contact"]);
                    customer.Account = Sqlreader["Account"].ToString();
                    customer.PurchaseTimeForm = Sqlreader["PurchaseTimeForm"].ToString();
                    customer.Currency = Sqlreader["Currency"].ToString();
                    customer.BudgetAmount = Convert.ToInt64(Sqlreader["BudgetAmount"]);
                    customer.PurchesProcess = Sqlreader["PurchesProcess"].ToString();
                    customer.ForecastCategory = Sqlreader["ForecastCategory"].ToString();
                    customer.Description = Sqlreader["Description"].ToString();
                    customer.CurrentSuitation = Sqlreader["CurrentSuitation"].ToString();
                    customer.CustommerNeed = Sqlreader["CustommerNeed"].ToString();
                    customer.ProposedSolution = Sqlreader["ProposedSolution"].ToString();
                    OpportunityList.Add(customer);
                }
                return View(OpportunityList);
            }
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int? RefQuoteId)
        {
            List<QuoteModel> QuoteList = new List<QuoteModel>();
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))
            {
                con.Open();
                SqlCommand Com = new SqlCommand("SP_Quotes_SelectAllbyId", con);
                Com.CommandType = CommandType.StoredProcedure;
                Com.Parameters.AddWithValue("@RefQuoteId", RefQuoteId);

                SqlDataReader Sqlreader = Com.ExecuteReader();
                while (Sqlreader.Read())
                {
                    var customer = new QuoteModel();
                    //customer.QuoteId = Convert.ToInt32(Sqlreader["QuoteId"]);
                    customer.Name = Sqlreader["Name"].ToString();
                    customer.Currency = Sqlreader["Currency"].ToString();
                    customer.Opportunity = Sqlreader["Opportunity"].ToString();
                    customer.PotentialCustomer = Sqlreader["PotentialCustomer"].ToString();
                    customer.PriceList = Sqlreader["PriceList"].ToString();
                    customer.QuoteExpiresOn = Convert.ToDateTime(Sqlreader["QuoteExpiresOn"]);
                    customer.StatusReason = Sqlreader["StatusReason"].ToString();
                    customer.Description = Sqlreader["Description"].ToString();
                    customer.PaymentTerms = Sqlreader["PaymentTerms"].ToString();
                    customer.FreightTerms = Sqlreader["FrieghtTerms"].ToString();
                    customer.BillToStreet = Sqlreader["BillToStreet"].ToString();
                    customer.BillToState = Sqlreader["Country"].ToString();
                    customer.BillToCountry = Sqlreader["BillToCountry"].ToString();
                    customer.BillingPostalCode = Sqlreader["BillingPostalCode"].ToString();
                    customer.ShipTo = Sqlreader["ShipTo"].ToString();
                    customer.ShippingMethod = Sqlreader["ShippingMethod"].ToString();
                    customer.ShipToStreet = Sqlreader["ShipToStreet"].ToString();
                    customer.ShipToCity = Sqlreader["ShipToCity"].ToString();
                    customer.ShipToState = Sqlreader["ShipToState"].ToString();
                    customer.ShipToCountry = Sqlreader["ShipToCountry"].ToString();
                    customer.ShipingPostalCodes = Convert.ToInt32(Sqlreader["ShipingPostalCode"]);
                    QuoteList.Add(customer);
                }
                return View(QuoteList);
            }
        }

        [HttpPost]
        public ActionResult Edit(QuoteModel model)
        {

            {
                CONNECTION();
                SqlCommand Command = new SqlCommand("SP_Quortes_Update", con);
                Command.CommandType = CommandType.StoredProcedure;
                con.Open();
                Command.Parameters.AddWithValue("@RefQuoteId", model.RefQuoteId);
                Command.Parameters.AddWithValue("@Name", model.Name);
                Command.Parameters.AddWithValue("@Currency", model.Currency);
                Command.Parameters.AddWithValue("@Opportunity", model.Opportunity);
                Command.Parameters.AddWithValue("@PotentialCustomer", model.PotentialCustomer);
                Command.Parameters.AddWithValue("@PriceList", model.PriceList);
                Command.Parameters.AddWithValue("@QuoteExpiresOn", model.QuoteExpiresOn);
                Command.Parameters.AddWithValue("@StatusReason", model.StatusReason);
                Command.Parameters.AddWithValue("@Description", model.Description);
                Command.Parameters.AddWithValue("@PaymentTerms", model.PaymentTerms);
                Command.Parameters.AddWithValue("@FrieghtTerms", model.FreightTerms);
                Command.Parameters.AddWithValue("@BillToStreet", model.BillToStreet);
                Command.Parameters.AddWithValue("@BillToState", model.BillToState);
                Command.Parameters.AddWithValue("@BillToCity", model.BillToCity);
                Command.Parameters.AddWithValue("@BillToCountry", model.BillToCountry);
                Command.Parameters.AddWithValue("@BillingPostalCode", model.BillingPostalCode);
                Command.Parameters.AddWithValue("@ShipTo", model.ShipTo);
                Command.Parameters.AddWithValue("@ShippingMethod", model.ShippingMethod);
                Command.Parameters.AddWithValue("@ShipToStreet", model.ShipToStreet);
                Command.Parameters.AddWithValue("@ShipToState", model.ShipToState);
                Command.Parameters.AddWithValue("@ShipToCity", model.ShipToCity);
                Command.Parameters.AddWithValue("@ShipToCountry", model.ShipToCountry);
                Command.Parameters.AddWithValue("@ShipingPostalCode", model.ShipingPostalCodes);
                Command.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("QuotesIndex");
            }
        }


        //delete
        public ActionResult Delete(int? RefQuoteId)
        {
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))

            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_Quortes_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RefQuoteId", RefQuoteId);
                cmd.ExecuteNonQuery();
                con.Close();

                return RedirectToAction("QuotesIndex");
            }

        }

        //qualify
        public ActionResult Qualify(int? RefQuoteId)
        {
            string Dbconnection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Dbconnection))

            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_QuortesQialify_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RefQuoteId", RefQuoteId);
                cmd.ExecuteNonQuery();
                con.Close();

                return RedirectToAction("QuotesIndex");
            }
        }
    }
}