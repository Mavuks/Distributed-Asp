using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain
{
    public class Material : BaseEntity
    
    {
        public string MaterialName { get; set; }


        public ICollection<Schooling> Schoolings { get; set; }
        
    }
}