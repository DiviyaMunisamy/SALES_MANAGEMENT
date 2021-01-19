using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SALES_MANAGEMENT.Models
{
    public class LoginModel
    {
        internal List<LoginModel> usersinfo;
        [Display(Name = "USER ID")]
        [Required(ErrorMessage = " User ID is Required")]
        public string Adminid { get; set; }

        [Display(Name = "PASSWORD")]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Remote("IsUserNameAvailable", "Home", ErrorMessage = "Username already exists")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailId { get; set; }
        [Display(Name = "User Password")]
        [Required(ErrorMessage = "UserPassword is Required")]
        public string UserPassword { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string BloodGroup { get; set; }
        public List<BloodList> BloodList { get; set; }
        public string UserEmailId { get; set; }
        public string UserDepartment { get; set; }
        public string Active { get; set; }
        public long IsActive { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreatedDate { get; set; }

        public string Email_id { get; set; }
        public string Pass { get; set; }
    }
    public class BloodList
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}