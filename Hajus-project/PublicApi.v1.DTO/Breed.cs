using System.Collections.Generic;
using BLL.App.DTO;

namespace PublicApi.v1.DTO
{
    public class Breed
    
    {
        
        public int Id { get; set; }

//        [MaxLength(128,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Display(Name = nameof(BreedName), ResourceType = typeof(Resources.Domain.Breed))]
        public string BreedName { get; set; }

        public ICollection<Dog> Dogs { get; set; }
    }
}