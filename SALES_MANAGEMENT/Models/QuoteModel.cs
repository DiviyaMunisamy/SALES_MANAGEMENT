using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SALES_MANAGEMENT.Models
{
    public class QuoteModel
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = " Name is Required")]
        public string Name { get; set; }

        [Display(Name = "Currency")]
        [Required(ErrorMessage = " Currency is Required")]
        public string Currency { get; set; }

        [Display(Name = "Opportunity")]
        [Required(ErrorMessage = " Opportunity is Required")]
        public string Opportunity { get; set; }

        [Display(Name = "Potential Customer")]
        [Required(ErrorMessage = " PotentialCustomer is Required")]
        public string PotentialCustomer { get; set; }

        [Display(Name = "Price List")]
        [Required(ErrorMessage = " PriceList is Required")]
        public string PriceList { get; set; }

        [Required(ErrorMessage = "Quote Expires On is Required ")]
        [Display(Name = "Quote Expires On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime QuoteExpiresOn { get; set; }

        [Display(Name = "Status Reason")]
        [Required(ErrorMessage = " StatusReason is Required")]
        public string StatusReason { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = " Description is Required")]
        public string Description { get; set; }

        [Display(Name = "Payment Terms")]
        [Required(ErrorMessage = " PaymentTerms is Required")]
        public string PaymentTerms { get; set; }

        [Display(Name = "Frieght Terms")]
        [Required(ErrorMessage = " FrieghtTerms is Required")]
        public string FreightTerms { get; set; }

        [Display(Name = "Bill To Street")]
        [Required(ErrorMessage = " BillToStreet is Required")]
        public string BillToStreet { get; set; }

        [Display(Name = "Bill To State")]
        [Required(ErrorMessage = " BillToState is Required")]
        public string BillToState { get; set; }

        [Display(Name = "Bill To City")]
        [Required(ErrorMessage = "BillToCity is Required")]
        public string BillToCity { get; set; }

        [Display(Name = "Bill To Country")]
        [Required(ErrorMessage = " BillToCountry is Required")]
        public string BillToCountry { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = " PostalCode is Required")]
        public string BillingPostalCode { get; set; }

        [Display(Name = "Ship To")]
        [Required(ErrorMessage = "ShipTo is Required")]
        public string ShipTo { get; set; }

        [Display(Name = "Shipping Method")]
        [Required(ErrorMessage = " ShippingMethod is Required")]
        public string ShippingMethod { get; set; }

        [Display(Name = "Ship To Street")]
        [Required(ErrorMessage = "ShipToStreet is Required")]
        public string ShipToStreet { get; set; }

        [Display(Name = "Ship To State")]
        [Required(ErrorMessage = " ShipToState is Required")]
        public string ShipToState { get; set; }

        [Display(Name = "Ship To City")]
        [Required(ErrorMessage = "ShipToCity is Required")]
        public string ShipToCity { get; set; }

        [Display(Name = "Ship To Country")]
        [Required(ErrorMessage = " ShipToCountry is Required")]
        public string ShipToCountry { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "PostalCode is Required")]
        public long ShipingPostalCodes { get; set; }

        [Display(Name = "Lead Id")]
        public int RefQuoteId { get; set; }

        public List<StatusReason> StatusReasonList { get; set; }
        public List<CurrencyForQuotes> CurrencyList { get; set; }
        public List<ShipTo> ShipToList { get; set; }
        public List<ShippingMethod> ShippingMethodList { get; set; }
        public List<FreightTerms> FreightTermsList { get; set; }
        public List<PaymentTerms> PaymentTermsList { get; set; }
        public int QuoteId { get; set; }
        
    }



    public class StatusReason
    {
        public int StatusReason_Id { get; set; }

        public string StatusReason_NAME { get; set; }

    }

    public class ShipTo
    {
        public int ShipTo_Id { get; set; }

        public string ShipTo_NAME { get; set; }

    }

    public class ShippingMethod
    {
        public int ShippingMethod_Id { get; set; }

        public string ShippingMethod_Name { get; set; }

    }

    public class FreightTerms
    {
        public int Freight_Id { get; set; }

        public string FreightTerm_Name { get; set; }

    }

    public class PaymentTerms
    {
        public int Payment_Id { get; set; }

        public string PaymentTerm_Name { get; set; }

    }

    public class CurrencyForQuotes
    {
        public int Currency_Id { get; set; }

        public string Currency_Name { get; set; }

    }

}
