using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.ViewModel{
    public class CategoryViewModel {

        [Required(ErrorMessage = "Укажте имя категории")]
        [MinLength(3, ErrorMessage = "Имя категории должен бить меньше 3")]
        [MaxLength(24, ErrorMessage = "Имя категории должен бить больше 24")]
        public string EditCategoryName { get; set; }

        [Required(ErrorMessage = "Укажте лимит")]
        public int EditCategoryLimit { get; set; }

        [Required(ErrorMessage = "Укажте имя категории")]
        [MinLength(3, ErrorMessage = "Имя категории должен бить меньше 3")]
        [MaxLength(24, ErrorMessage = "Имя категории должен бить больше 24")]
        public string CreateCategoryName { get; set; }

        [Required(ErrorMessage = "Укажте лимит")]
        public int CreateCategoryLimit { get; set; }
    }
}
