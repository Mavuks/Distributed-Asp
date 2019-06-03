using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        //public ICollection<Person> Persons { get; set; }
        
        public string FirstName { get; set; }
        

        public string LastName { get; set; }

        public ICollection<Dog> Dogs { get; set; }
        
        public string FirstLastName { get; set; }
    }
}