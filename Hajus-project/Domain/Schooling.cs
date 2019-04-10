using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Schooling : BaseEntity
    {
        public string SchoolingName { get; set; }
        
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Start { get; set; }
        
        
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime End { get; set; }


        public int MaterialId { get; set; }

        public Material Material { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }


        public int  ParticipantId { get; set; }

        public Participant Participant { get; set; }
    }
}