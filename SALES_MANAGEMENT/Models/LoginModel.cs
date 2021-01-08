using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SALES_MANAGEMENT.Models
{
    public class LoginModel
    {
        public List<LoginModel> usersinfo;

        public string Adminid { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string UserPassword { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string BloodGroup { get; set; }
        public List<BloodList> BloodList { get; set; }
        public string UserEmailId { get; set; }
        public string UserDepartment { get; set; }
        public long IsActive { get; set; }
        public DateTime CreatedDate { get; set; }


    }
    public class BloodList
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}