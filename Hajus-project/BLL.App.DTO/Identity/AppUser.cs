using System.Collections.Generic;

namespace BLL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        

        public string LastName { get; set; }

        public ICollection<Dog> Dogs { get; set; }
        
        public string FirstLastName { get; set; }
       
    }
}