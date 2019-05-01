using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class BreedWithDogCounts
    {

        public int Id { get; set; }

        [MaxLength(128,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(BreedName), ResourceType = typeof(Resources.Domain.Breed))]
        public string BreedName { get; set; }

        public int BreedCount { get; set; }
    }
}