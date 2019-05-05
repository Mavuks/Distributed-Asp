using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class MaterialCounts
    {

        public int Id { get; set; }

        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(MaterialName), ResourceType = typeof(Resources.Domain.Material))]
        public string MaterialName { get; set; }

        [Display(Name = nameof(MaterialCount), ResourceType = typeof(Resources.Domain.Material))]
        public int MaterialCount { get; set; }
    }
}