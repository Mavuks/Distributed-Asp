using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;


namespace BLL.App.DTO
{
    public class Dog
    {
        
        public int Id { get; set; }
    
        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(DogName), ResourceType = typeof(Resources.Domain.Dog))]
        public string DogName { get; set; }
        
        

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(DateOfBirth), ResourceType = typeof(Resources.Domain.Dog))]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        
        [Display(Name = nameof(DateOfDeath), ResourceType = typeof(Resources.Domain.Dog))]
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Sex), ResourceType = typeof(Resources.Domain.Dog))]
        public string Sex { get; set; }

        public int BreedId { get; set; }
        
       
        [Display(Name = nameof(Breed), ResourceType = typeof(Resources.Domain.Dog))]
        public Breed Breed { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(Owner), ResourceType = typeof(Resources.Domain.Dog))]
        public string Owner { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
       
        public ICollection<Registration> Registrations  { get; set; }


        
      
    }
}