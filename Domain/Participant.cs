using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Participant : BaseEntity
    {
        [MaxLength(100)]
        [MinLength(2)]
        [Required]
        public string FirstName { get; set; }
        
        
        [MaxLength(100)]
        [MinLength(2)]
        [Required]
        public string LastName { get; set; }


        public List<Schooling> Schoolings { get; set; }

        public List<Show> Shows { get; set; }


        public List<Registration> Registrations { get; set; }

        public List<Competition> Competitions { get; set; }
          
    }
}