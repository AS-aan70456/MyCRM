using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.ViewModel{
    public class RecordViewModel{
        [Required(ErrorMessage = "Отсутствует категория")]
        public string NameCategory { get; set; }

        [Required(ErrorMessage = "Отсутствует описания")]
        [MaxLength(255, ErrorMessage = "Описания не больше 255 символов")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "Отсутствует сумма")]
        public int Sum { get; set; }

        public bool IsIncome { get; set; }
        public bool InIncome { get; set; }
    }
}
