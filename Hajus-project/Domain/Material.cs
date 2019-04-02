using System.Collections.Generic;

namespace Domain
{
    public class Material : BaseEntity
    
    {
        public string MaterialName { get; set; }


        public List<Schooling> Schoolings { get; set; }
        
    }
}