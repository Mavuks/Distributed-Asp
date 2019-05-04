using System.Collections.Generic;

namespace PublicApi.v1.DTO
{
    public class Participant
    {
        
        public int Id { get; set; }
        
        
//        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Display(Name = nameof(FirstName), ResourceType = typeof(Resources.Domain.Participant))]
        public string FirstName { get; set; }
        
        
//        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Display(Name = nameof(LastName), ResourceType = typeof(Resources.Domain.Participant))]
        public string LastName { get; set; }

        
        public ICollection<Registration> Registrations { get; set; }

        
          
    }
}