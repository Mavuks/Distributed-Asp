using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Competition : BaseEntity
    {
        
        public string Title { get; set; }

        public string Comment { get; set; }

        public string Award { get; set; }
        
        
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }


        public int DogId { get; set; }
        public Dog Dog { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public List<Registration> Registrations { get; set; }

        public List<Award> Awards { get; set; }
    }
}