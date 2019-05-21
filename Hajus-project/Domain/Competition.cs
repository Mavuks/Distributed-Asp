using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain
{
    public class Competition : DomainEntity
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