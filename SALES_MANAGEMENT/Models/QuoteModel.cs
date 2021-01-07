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

        [Display(Name = "PotentialCustomer")]
        [Required(ErrorMessage = " PotentialCustomer is Required")]
        public string PotentialCustomer { get; set; }

        [Display(Name = "PriceList")]
        [Required(ErrorMessage = " PriceList is Required")]
        public string PriceList { get; set; }

        [Required(ErrorMessage = "Quote Expires On is Required ")]
        [Display(Name = "Quote Expires On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime QuoteExpiresOn { get; set; }

        [Display(Name = "StatusReason")]
        [Required(ErrorMessage = " StatusReason is Required")]
        public string StatusReason { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = " Description is Required")]
        public string Description { get; set; }

        [Display(Name = "PaymentTerms")]
        [Required(ErrorMessage = " PaymentTerms is Required")]
        public string PaymentTerms { get; set; }

        [Display(Name = "FreightTerms")]
        [Required(ErrorMessage = " FreightTerms is Required")]
        public long FreightTerms { get; set; }

        [Display(Name = "BillToStreet")]
        [Required(ErrorMessage = " BillToStreet is Required")]
        public string BillToStreet { get; set; }

        [Display(Name = "[BillToCity]")]
        [Required(ErrorMessage = " [BillToCity] is Required")]
        public string BillToCity { get; set; }

        [Display(Name = "BillToCountry")]
        [Required(ErrorMessage = " BillToCountry is Required")]
        public string BillToCountry { get; set; }

        [Display(Name = "PostalCode")]
        [Required(ErrorMessage = " PostalCode is Required")]
        public string BillingPostalCode { get; set; }

        [Display(Name = "ShipTo")]
        [Required(ErrorMessage = "ShipTo is Required")]
        public string ShipTo { get; set; }

        [Display(Name = "ShippingMethod")]
        [Required(ErrorMessage = " ShippingMethod is Required")]
        public string ShippingMethod { get; set; }

        [Display(Name = "ShipToStreet")]
        [Required(ErrorMessage = "ShipToStreet is Required")]
        public string ShipToStreet { get; set; }

        [Display(Name = "ShipToState")]
        [Required(ErrorMessage = " ShipToState is Required")]
        public string ShipToState { get; set; }

        [Display(Name = "ShipToCity")]
        [Required(ErrorMessage = "ShipToCity is Required")]
        public string ShipToCity { get; set; }

        [Display(Name = "ShipToCountry")]
        [Required(ErrorMessage = " ShipToCountry is Required")]
        public string ShipToCountry { get; set; }

        [Display(Name = "PostalCode")]
        [Required(ErrorMessage = "PostalCode is Required")]
        public string ShipingPostalCode { get; set; }


        public List<StatusReason> StatusReasonList { get; internal set; }
        public List<CurrencyForQuotes> CurrencyList { get; internal set; }
        public List<ShipTo> ShipToList { get; internal set; }
        public List<ShippingMethod> ShippingMethodList { get; internal set; }
        public List<FreightTerms> FreightTermsList { get; internal set; }
        public List<PaymentTerms> PaymentTermsList { get; internal set; }
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
