using System.Collections.Generic;

namespace Domain
{
    public class Breed : BaseEntity
    
    {

        public string BreedName { get; set; }

        public ICollection<Dog> Dogs { get; set; }
    }
}