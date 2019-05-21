using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Competition
    {
        
        public int Id { get; set; }
        
        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Title), ResourceType = typeof(Resources.Domain.Competition))]
        public string Title { get; set; }

        [Display(Name = nameof(Comment), ResourceType = typeof(Resources.Domain.Competition))]
        public string Comment { get; set; }

        [Display(Name = nameof(Start), ResourceType = typeof(Resources.Domain.Competition))]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        
        
        [Display(Name = nameof(End), ResourceType = typeof(Resources.Domain.Competition))]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        public int LocationId { get; set; }
        
        [Display(Name = nameof(Location), ResourceType = typeof(Resources.Domain.Competition))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        public Location Location { get; set; }

        public List<Registration> Registrations { get; set; }

    }
}