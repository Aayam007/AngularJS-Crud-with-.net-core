using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.ViewModels
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
