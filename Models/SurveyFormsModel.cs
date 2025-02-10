using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRS3LOGIN_AUTHENTICATION.Models
{
   
    public class SurveyFormsModel
    {
        
            [Key]
            public int id { get; set; }

            [Required]
            public string SurveyName { get; set; }
            public string Category { get; set; }
            public string SubCategory { get; set; }
            public string FormName { get; set; }
            public string Section { get; set; }
            public string SectionWeightage { get; set; }
            public string SurveyRantingtype { get; set; }

       
    }
}
