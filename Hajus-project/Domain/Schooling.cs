using System;
using System.Collections.Generic;
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
        


        public int? MaterialId { get; set; }

        public Material Material { get; set; }
        
        public List<Registration> Registrations { get; set; }


    }
}