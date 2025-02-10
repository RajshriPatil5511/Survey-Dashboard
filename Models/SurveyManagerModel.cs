using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRS3LOGIN_AUTHENTICATION.Models
{ 
    public class SurveyManagerModel
    {
        [Key]
        public int ManageID { get; set; }

        public string surveyName { get; set; }

        public string Quetions { get; set; }

        

    }
}
