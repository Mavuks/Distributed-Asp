using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Domain.Identity;

namespace Domain
{
    public class Dog : DomainEntity
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

        public MultiLangString Sex { get; set; }

        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        public string Owner { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
       
        public ICollection<Registration> Registrations  { get; set; }


        
      
    }
}