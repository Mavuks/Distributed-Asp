using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class Schooling
    {
        public int Id { get; set; }
        
        [Required]
        public string SchoolingName { get; set; }
        
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Start { get; set; }
        
        
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime End { get; set; }


        public int? MaterialId { get; set; }

        public Material Material { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }


    }
}