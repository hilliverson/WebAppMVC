using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVC.Models.ViewModel.Employees
{
    public class RegisterEmployee
    {
        [Required]
        [Display(Name ="電子郵件")]
        [DataType(DataType.EmailAddress)]
        public string eMail { get; set; }

        [Required]
        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "確認密碼")]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="密碼不符合")]
        public string confirmPassword { get; set; }

    }
}
