
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRS3LOGIN_AUTHENTICATION.Models
{
    
    public class viewmodel
    {
         public List<int> SurveyId { get; set; }

        public List<SelectListItem> surveyName { get; set; }

        public SurveyFormsModel surveyForm { get; set; }

        public List<int> QuetionsID { get; set; }

        public List<SelectListItem> Quetions { get; set; }

        public List<SurveyManagerModel> surveyManager { get; set; } 

    }
}
