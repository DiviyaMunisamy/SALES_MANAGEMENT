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
    
    public partial class SP_Quotes_SelectAllbyId_Result
    {
        public int QuoteId { get; set; }
        public string Name { get; set; }
        public int Currency { get; set; }
        public string PriceList { get; set; }
        public int ShippingMethod { get; set; }
        public int PaymentTerms { get; set; }
        public int FreightTerms { get; set; }
        public string BillToStreet { get; set; }
        public string BillToCity { get; set; }
        public string BillToState { get; set; }
        public long BillingPostalCode { get; set; }
        public string BillToCountry { get; set; }
        public string ShipToStreet { get; set; }
        public string ShipToState { get; set; }
        public string ShipToCity { get; set; }
        public long ShipingPostalCodes { get; set; }
        public string ShipToCountry { get; set; }
        public string PotentialCustomer { get; set; }
        public string Opportunity { get; set; }
        public string Description { get; set; }
        public Nullable<int> StatusReason { get; set; }
        public Nullable<int> ShipTo { get; set; }
        public Nullable<System.DateTime> QuoteExpiresOn { get; set; }
        public Nullable<int> RefQuoteId { get; set; }
        public bool IsQuoteQualify { get; set; }
    }
}
