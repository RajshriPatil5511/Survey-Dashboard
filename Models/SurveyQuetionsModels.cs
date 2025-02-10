using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRS3LOGIN_AUTHENTICATION.Models
{
   
    public class SurveyQuetionsModels
    {

        [Key]
        public int Quetionsid { get; set; }

        [DisplayName("Enter a Quetions.")]
        [Column(TypeName ="nvarchar(100)")]
        [Required(ErrorMessage ="Please Quetion quetions is required")]
        public string Quetions { get; set; }

        [Required]
      /* [MaxLength(100)]*/
        public int QuetionsWeightage { get; set; }



        [Column(TypeName = "nvarchar(20)")]
        public string Factor { get; set; }
       
    }
}
