using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Competition
    {
        
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Comment { get; set; }

      
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public List<Registration> Registrations { get; set; }

    }
}