using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.ViewModel{
    public class RegisterViewModel{


        [Required(ErrorMessage = "Укажте имя")]
        [MinLength(3, ErrorMessage = "Имя должен бить меньше 3")]
        [MaxLength(24, ErrorMessage = "Имя должен бить больше 24")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Укажте пароль")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Пароль должен бить меньше 6")]
        [MaxLength(24, ErrorMessage ="Пароль должен бить больше 24")]
        public string password { get; set; }

        [Required(ErrorMessage ="Укажте email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Отречитесь от своей души")]
        public bool IsCheckBox { get; set; }
    }
}
