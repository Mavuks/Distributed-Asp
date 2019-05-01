using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Location
    {
        
        public int Id { get; set; }

        [MaxLength(128,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Locations), ResourceType = typeof(Resources.Domain.Location))]
        public string Locations { get; set; }

        public List<Competition> Competitions { get; set; }

        public List<Show> Shows { get; set; }
        
    }
}