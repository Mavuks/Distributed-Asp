using System.Collections.Generic;

namespace Domain
{
    public class Breed : DomainEntity
    
    {
        public int BreedValueId { get; set; }
        
        
        public MultiLangString BreedNameValue { get; set; }

        public ICollection<Dog> Dogs { get; set; }
    }
}