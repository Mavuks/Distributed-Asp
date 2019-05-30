using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Registration
    {
        
        public int Id { get; set; }
        
        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Title), ResourceType = typeof(Resources.Domain.Registration))]
        public string Title { get; set; }

        
        [Display(Name = nameof(Comment), ResourceType = typeof(Resources.Domain.Registration))]
        public string Comment { get; set; }
       
        public int DogId { get; set; }
        [Display(Name = nameof(Dog), ResourceType = typeof(Resources.Domain.Registration))]
        public Dog Dog { get; set; }

        public int ParticipantId { get; set; }
        
        [Display(Name = nameof(Participant), ResourceType = typeof(Resources.Domain.Registration))]
        public Participant Participant { get; set; }

        public int? CompetitionId { get; set; }
        [Display(Name = nameof(Competition), ResourceType = typeof(Resources.Domain.Registration))]
        public Competition Competition { get; set; }

        public int? ShowId { get; set; }
        [Display(Name = nameof(Show), ResourceType = typeof(Resources.Domain.Registration))]
        public Show Show { get; set; }
    }
}
