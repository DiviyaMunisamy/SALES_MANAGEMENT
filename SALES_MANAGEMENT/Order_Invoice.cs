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
    
    public partial class Order_Invoice
    {
        public int Id { get; set; }
        public Nullable<int> RefOrder_InvoiceId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public int Currency { get; set; }
        public string Opportunity { get; set; }
        public string PriceList { get; set; }
        public string PriceLocked { get; set; }
        public System.DateTime RequestedDelivery { get; set; }
        public System.DateTime DateFullfilled { get; set; }
        public int ShippingMethod { get; set; }
        public int PaymentTerms { get; set; }
        public int FreightTerms { get; set; }
        public string BillToStreet { get; set; }
        public string BillToCity { get; set; }
        public string BillToState { get; set; }
        public long BillingPostalCode { get; set; }
        public string BillToCountry { get; set; }
        public string ShipToStreet { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public long ShipingPostalCodes { get; set; }
        public string ShipToCountry { get; set; }
        public string PotentialCustomer { get; set; }
        public string Description { get; set; }
    
        public virtual TBL_Countries TBL_Countries { get; set; }
        public virtual TBL_FreightTerms TBL_FreightTerms { get; set; }
        public virtual TBL_PaymentTerms TBL_PaymentTerms { get; set; }
        public virtual TBL_Leads TBL_Leads { get; set; }
        public virtual TBL_ShippingMethod TBL_ShippingMethod { get; set; }
    }
}
