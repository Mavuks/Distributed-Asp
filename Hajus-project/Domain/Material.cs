using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain
{
    public class Material : DomainEntity
    
    {
        public MultiLangString MaterialName { get; set; }


        public List<Schooling> Schoolings { get; set; }
        
    }
}