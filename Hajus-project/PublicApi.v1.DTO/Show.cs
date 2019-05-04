using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO;

namespace PublicApi.v1.DTO
{
    public class Show 
    {
        
        public int Id { get; set; }
        


        public string Title { get; set; }

        
     
        public string Comment { get; set; }
 
       
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        
        
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }


        public List<Registration> Registrations { get; set; }
      
        
    }
}