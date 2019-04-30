using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Participant
    {
        
        public int Id { get; set; }
        
        
        [MaxLength(100)]
        [MinLength(2)]
        [Required]
        public string FirstName { get; set; }
        
        
        [MaxLength(100)]
        [MinLength(2)]
        [Required]
        public string LastName { get; set; }

        
        public ICollection<Registration> Registrations { get; set; }

        
          
    }
}