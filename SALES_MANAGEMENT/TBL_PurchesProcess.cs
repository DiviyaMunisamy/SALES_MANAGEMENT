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
    
    public partial class TBL_PurchesProcess
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PurchesProcess()
        {
            this.TBL_Opportunity = new HashSet<TBL_Opportunity>();
        }
    
        public int PurchesProcess_Id { get; set; }
        public string PurchesProcess_Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Opportunity> TBL_Opportunity { get; set; }
    }
}
