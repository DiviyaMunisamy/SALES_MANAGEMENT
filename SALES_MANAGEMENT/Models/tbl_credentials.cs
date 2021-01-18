using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SALES_MANAGEMENT.Models
{
    public partial class tbl_credentials
    {
        public long Id { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<bool> IsPasswordChanged { get; set; }
        public string UserDepartment { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public string Active { get; set; }
    }
}