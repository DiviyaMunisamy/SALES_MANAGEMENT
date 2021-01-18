//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SALES_MANAGEMENT
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Leads
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Leads()
        {
            this.Order_Invoice = new HashSet<Order_Invoice>();
            this.TBL_Opportunity = new HashSet<TBL_Opportunity>();
            this.TBL_Quote = new HashSet<TBL_Quote>();
        }
    
        public int LeadId { get; set; }
        public string Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public long MobileNumber { get; set; }
        public string EmailId { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string Title { get; set; }
        public Nullable<int> LeadSource { get; set; }
        public Nullable<System.DateTime> MeetingDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string JobTitle { get; set; }
        public bool IsQualify { get; set; }
        public string CompanyWebsite { get; set; }
        public Nullable<int> Type { get; set; }
        public string CompanyName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Invoice> Order_Invoice { get; set; }
        public virtual TBL_LeadSource TBL_LeadSource { get; set; }
        public virtual Type Type1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Opportunity> TBL_Opportunity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Quote> TBL_Quote { get; set; }
    }
}
