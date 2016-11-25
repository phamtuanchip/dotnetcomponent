using System.ComponentModel.DataAnnotations;

namespace MVC02.Tests.Controllers
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female
    }
}
