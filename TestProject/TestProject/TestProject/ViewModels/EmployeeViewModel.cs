using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
       

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Display(Name = "Full Address")]
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
