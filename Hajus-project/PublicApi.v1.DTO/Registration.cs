using BLL.App.DTO;

namespace PublicApi.v1.DTO
{
    public class Registration
    {
        
        public int Id { get; set; }
        
//        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
//        [Display(Name = nameof(Title), ResourceType = typeof(Resources.Domain.Registration))]
        public string Title { get; set; }

        
//        [Display(Name = nameof(Title), ResourceType = typeof(Resources.Domain.Registration))]
        public string Comment { get; set; }
       
        public int DogId { get; set; }
        public Dog Dog { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int? CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public int? ShowId { get; set; }
        public Show Show { get; set; }
    }
}
