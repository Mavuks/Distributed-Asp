using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BLL.App.DTO
{
    public class Dog
    {
        
        public int Id { get; set; }
    
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

        public string Owner { get; set; }
        
       
        public List<Registration> Registrations  { get; set; }


        
      
    }
}