using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SALES_MANAGEMENT.Models
{
    public class displayuser
    {
        public string UserEmailId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserDepartment { get; set; }
        public long IsActive { get; set; }
    }
}