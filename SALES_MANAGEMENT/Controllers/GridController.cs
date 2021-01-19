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
    public class GridController : Controller
    {
        // GET: Grid
            public ActionResult DisplayUsers(LoginModel model)
            {
                List<LoginModel> userdetail = new List<LoginModel>();
                string cs = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("sp_selectcredentials", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader Sqlreader = cmd.ExecuteReader();
                while (Sqlreader.Read())
                {
                    var userdetailview = new LoginModel();


                    userdetailview.UserEmailId = Sqlreader["EmailId"].ToString();
                    userdetailview.UserDepartment = Sqlreader["UserDepartment"].ToString();
                    userdetailview.Active =Sqlreader["Active"].ToString();
                    userdetailview.CreatedDate = Convert.ToDateTime(Sqlreader["CreatedDate"]);
                    userdetail.Add(userdetailview);
                }
                return View(userdetail);
            }
        
    }
}