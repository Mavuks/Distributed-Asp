using System.Collections.Generic;

namespace Domain
{
    public class Award : BaseEntity
    {
        public string Place { get; set; }

        public string Comment { get; set; }


        public int? CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public int? ShowId { get; set; }
        public Show Show { get; set; }

        public List<Dog> Dogs { get; set; }
        
        
    }
}