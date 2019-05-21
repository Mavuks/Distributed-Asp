using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Show : DomainEntity
    {

        public MultiLangString Title { get; set; }

        public MultiLangString Comment { get; set; }
 
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }


        public ICollection<Registration> Registrations { get; set; }
      
        
    }
}