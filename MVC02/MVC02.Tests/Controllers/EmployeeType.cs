using System.ComponentModel.DataAnnotations;

namespace MVC02.Tests.Controllers
{
    public enum EmployeeType
    {
        [Display(Name = "Internal")]
        Internal = 1,
        [Display(Name = "External")]
        External = 2,
    }
}
