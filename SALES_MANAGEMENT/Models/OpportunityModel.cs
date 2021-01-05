using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SALES_MANAGEMENT.Models
{
    public class OpportunityModel
    {
        [Display(Name = "Topic")]
        [Required(ErrorMessage = " Topic is Required")]
        public string Topic { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = " Contact is Required")]
        public string Contact { get; set; }

        [Display(Name = "Account")]
        [Required(ErrorMessage = " LAccount is Required")]
        public string Account { get; set; }

        [Display(Name = "PurchaseTimeForm")]
        [Required(ErrorMessage = " PurchaseTimeForm is Required")]
        public string PurchaseTimeForm { get; set; }

        [Display(Name = "Currency")]
        [Required(ErrorMessage = " Currency is Required")]
        public string Currency { get; set; }

        [Display(Name = "BudgetAmount")]
        [Required(ErrorMessage = " BudgetAmount is Required")]
        public string BudgetAmount { get; set; }

        [Display(Name = "PurchesProcess")]
        [Required(ErrorMessage = " PurchesProcess is Required")]
        public string PurchesProcess { get; set; }

        [Display(Name = "ForecastCategory")]
        [Required(ErrorMessage = " ForecastCategory is Required")]
        public string ForecastCategory { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = " Description is Required")]
        public string Description { get; set; }

        [Display(Name = "CurrentSuitation")]
        [Required(ErrorMessage = " CurrentSuitation is Required")]
        public string CurrentSuitation { get; set; }

        [Display(Name = "CustommerNeed")]
        [Required(ErrorMessage = "CustommerNeed is Required")]
        public string CustommerNeed { get; set; }

        [Display(Name = "ProposedSolution")]
        [Required(ErrorMessage = " ProposedSolution is Required")]
        public string ProposedSolution { get; set; }
    }
}