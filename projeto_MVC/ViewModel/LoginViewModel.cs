using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto_MVC.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public String Login { get; set; }

        [Required]
        public String Senha { get; set; }
    }
}