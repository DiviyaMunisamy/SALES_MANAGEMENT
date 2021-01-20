using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SALES_MANAGEMENT.Models;
namespace SALES_MANAGEMENT.Controllers
{
    public class LoginController : Controller
    {
        SaleEntities1 db = new SaleEntities1();
        public SqlConnection con;
        public void CONNECTION()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            con = new SqlConnection(constr);
        }
        // GET: Login
        public ActionResult Indexer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Indexer(LoginModel model)
        {

        
            


            if (ModelState.IsValid)
            {
                string Passw = Encrypt(model.Pass);
                var user = db.tbl_credentials.SingleOrDefault(x => x.Emailid == model.Email_id && x.Password == Passw);
                if (user != null)
                {
                    if (user.UserDepartment == 1.ToString())
                    {
                        return View("SalesManager");
                    }
                    else if (user.UserDepartment == 3.ToString())
                    {
                        return RedirectToAction("Create","Home");

                    }
                    else if (user.UserDepartment == 2.ToString())
                    {
                        return View("SeniorManager");

                    }
                }
                else
                {
                    ViewBag.Message = "Invalid Login";
                    return View();

                }


            }
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Welcome(LoginModel model)
        {
            string password = Decrypt(model.Pass);
            CONNECTION();
            SqlCommand cmd = new SqlCommand("UserLogin", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dataSet = new DataSet();
            cmd.Parameters.AddWithValue("@EmailId", model.Email_id);

            cmd.Parameters.AddWithValue("@Password", model.Pass);


            return View();

        }

        public string Decrypt(string sData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                string message = "error in decrypt: " + ex.Message + " Value: " + sData;
                return message;
            }
        }

        public string Encrypt(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                string message = "Error in encrypt" + ex.Message + " Value: " + sData;
                return message;
            }
        }

        
    }
}
