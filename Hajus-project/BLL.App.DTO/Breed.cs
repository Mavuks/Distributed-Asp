using System.Collections.Generic;

namespace BLL.App.DTO
{
    public class Breed
    
    {
        
        public int Id { get; set; }

        public string BreedName { get; set; }

        public ICollection<Dog> Dogs { get; set; }
    }
}