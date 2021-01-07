using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SALES_MANAGEMENT.Models
{
    public class Credentials
    {
        public LoginModel LoginModel { get; set; }
        public IEnumerable<tbl_credentials> CredentialList { get; set; }
    }
}