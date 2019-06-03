using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Schooling
    {
        public int Id { get; set; }
        
        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(SchoolingName), ResourceType = typeof(Resources.Domain.Schooling))]
        public string SchoolingName { get; set; }
        
        [Display(Name = nameof(Start), ResourceType = typeof(Resources.Domain.Schooling))]
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        public DateTime Start { get; set; }


        public int? MaterialId { get; set; }

        public Material Material { get; set; }


    }
}