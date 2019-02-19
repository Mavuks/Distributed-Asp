using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Domain
{
    public class Dog : BaseEntity
    {
    
        [MaxLength(100)]
        [MinLength(2)]
        [Required]
        public string DogName { get; set; }

        
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        
        [Display(Name = "Date of Death")]
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }

        public string Sex { get; set; }

        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        public List<Schooling> Schoolings { get; set; }

        public List<Registration> Registrations  { get; set; }

        public List<Show> Shows { get; set; }

        public List<Competition> Competitions { get; set; }

        public int AwardId { get; set; }
        public Award Award { get; set; }
        
       
    }
}