using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Schooling : DomainEntity
    {
        [Required]
        public MultiLangString SchoolingName { get; set; }
        
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


    }
}