using SALES_MANAGEMENT.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SALES_MANAGEMENT.Controllers
{
    public class HomeController : Controller
    {
        SaleEntities1 db = new SaleEntities1();
        LoginModel log = new LoginModel();
        public static string connection = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
        SqlConnection Connection = new SqlConnection(connection);

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            string cs = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand com = new SqlCommand("Sp_Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Admin_id", model.Adminid);
            com.Parameters.AddWithValue("@password", model.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            if (res == 1)
            {
                // return RedirectToAction("Create");
                return RedirectToAction("Create");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Login/Password!";
                return View();
            }
        }


        public ActionResult getUserList()
        {
            var tbl_credentials = db.tbl_credentials.ToList();
            return View(tbl_credentials);
        }

        [HttpGet]

        public ActionResult Create()
        {

        
            LoginModel dropdownValues = new LoginModel()
            {
                BloodList = GetBloodList(),

            };


            return View(dropdownValues);

        }

        [HttpPost]

        public ActionResult Create(LoginModel model)
        {
            LoginModel dropdownValues = new LoginModel()
            {
                BloodList = GetBloodList(),
            };
            LoginModel objuser = new LoginModel();
            DataSet ds = new DataSet();
           
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
                string password = Encrypt(model.UserPassword);
                //string pass = Decrypt(model.UserPassword);
                SqlConnection con = new SqlConnection(cs);
                SqlCommand com = new SqlCommand("sp_credntials", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@EmailId", model.EmailId);
                com.Parameters.AddWithValue("@Password", password);
                com.Parameters.AddWithValue("@UserDepartment", model.DepartmentId);
                com.Parameters.AddWithValue("@Active", "Yes");

                con.Open();
                com.ExecuteNonQuery();

                ViewData["message"] = "Login Created successfully";
                SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                string to = model.EmailId;
                string from = section.From;
                int index = to.IndexOf('@');
                string name = to.Substring(0, index);
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Successful Registration";
                message.Body = "Hi " + name + " , you have been registered Successfully!!! The your user name is " + model.EmailId + " and password is " + model.UserPassword;
                SmtpClient smtp = new SmtpClient();
                smtp.Port = section.Network.Port;
                smtp.EnableSsl = section.Network.EnableSsl;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(section.Network.UserName, section.Network.Password);
                smtp.Host = section.Network.Host;
                smtp.Send(message);

                con.Close();
                return View(dropdownValues);
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Create");

            }
        }
       
        public ActionResult DisplayUser(LoginModel model)
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
                userdetailview.IsActive = Convert.ToInt64(Sqlreader["IsActive"]);
                userdetailview.CreatedDate = Convert.ToDateTime(Sqlreader["Created_Date"]);
                userdetail.Add(userdetailview);
            }
            return View(userdetail);
        }
        public List<BloodList> GetBloodList()
        {
            string cs = ConfigurationManager.ConnectionStrings["LeadConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand Command = new SqlCommand("sp_select_department", con);
            con.Open();
            SqlDataReader datareader = Command.ExecuteReader();
            List<BloodList> StudentBlood = new List<BloodList>();
            if (datareader.HasRows)
            {
                while (datareader.Read())
                {
                    StudentBlood.Add(new BloodList
                    {
                        DepartmentId = Convert.ToInt32(datareader["DepartmentId"]),
                        DepartmentName = Convert.ToString(datareader["DepartmentName"]),
                    });
                }
            }
            con.Close();
            return StudentBlood;
        }

        #region Engrypt and Decrypt
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
        #endregion
    }
}