using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Domain.Identity;

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

        

        public ICollection<Schooling> Schoolings { get; set; }


        public ICollection<Registration> Registrations { get; set; }

        
          
    }
}