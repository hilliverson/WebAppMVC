using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models.ViewModel.Employees
{
    public class VWEmployeeList
    {
        [Display(Name ="員工編號")]
        public int EmployeeId { get; set; }
        [Display(Name = "員工名")]
        public string LastName { get; set; } = null!;
        [Display(Name = "員工姓")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "員工職稱")]
        public string? Title { get; set; }
        [Display(Name = "員工職稱")]
        public string? TitleOfCourtesy { get; set; }
        [Display(Name = "員生日")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "員工到職日")]
        public DateTime? HireDate { get; set; }
        [Display(Name = "員工住址")]
        public string? Address { get; set; }
        [Display(Name = "員工住的城市")]
        public string? City { get; set; }
    }
}
