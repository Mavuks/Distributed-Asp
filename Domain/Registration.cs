using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Registration : BaseEntity
    {
        public string Title { get; set; }

        public string Comment { get; set; }
        
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }


        public int DogId { get; set; }
        public Dog Dog { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public int ShowId { get; set; }
        public Show Show { get; set; }
    }
}
