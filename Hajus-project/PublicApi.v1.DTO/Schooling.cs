using System;
using BLL.App.DTO;

namespace PublicApi.v1.DTO
{
    public class Schooling
    {
        public int Id { get; set; }
        
//        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Display(Name = nameof(SchoolingName), ResourceType = typeof(Resources.Domain.Schooling))]
        public string SchoolingName { get; set; }
        

        public DateTime Start { get; set; }
        

        public DateTime End { get; set; }


        public int? MaterialId { get; set; }

        public Material Material { get; set; }


    }
}