using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SALES_MANAGEMENT.Models
{
    public class OpportunityModel
    {
        [Display(Name = "Lead ID")]
        [Required(ErrorMessage = " Lead ID is Required")]
        public long RefOppId { get; set; }

        [Display(Name = "Topic")]
        [Required(ErrorMessage = " Topic is Required")]
        public string Topic { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = " Contact is Required")]
        public long Contact { get; set; }

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
        public long BudgetAmount { get; set; }

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

        public List<PurchaseTimeForm> PurchaseTimeFormList { get; internal set; }
        public List<Currency> CurrencyList { get; internal set; }
        public List<PurchesProcess> PurchesProcessList { get; internal set; }
        public List<ForecastCategory> ForecastCategoryList { get; internal set; }
        public int Id { get; internal set; }
    }
    public class PurchaseTimeForm
    {
        public int PT_Id { get; set; }

        public string PurchaseTimeForm_Name { get; set; }

    }
    public class PurchesProcess
    {
        public int PurchesProcess_Id { get; set; }

        public string PurchesProcess_Name { get; set; }

    }
    public class ForecastCategory
    {
        public int ForecastCategory_Id { get; set; }

        public string ForecastCategory_Name { get; set; }

    }
    public class Currency
    {
        public int Currency_Id { get; set; }

        public string Currency_Name { get; set; }

    }


}