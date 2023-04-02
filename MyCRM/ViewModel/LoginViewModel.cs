using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.ViewModel{
    public class LoginViewModel {

        [Required(ErrorMessage = "Укажте имя")]
        [MinLength(6, ErrorMessage = "Имя должен бить больше 3")]
        [MaxLength(24, ErrorMessage = "Имя должен бить больше 24")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Укажте пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен бить больше 6")]
        [MaxLength(24, ErrorMessage = "Пароль должен бить больше 24")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        
        public string ReturnUrl { get; set; }
    }
}
