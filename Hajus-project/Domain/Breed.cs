using System.Collections.Generic;

namespace Domain
{
    public class Breed : DomainEntity
    
    {
       
        public MultiLangString BreedName { get; set; }

        public List<Dog> Dogs { get; set; }
    }
}