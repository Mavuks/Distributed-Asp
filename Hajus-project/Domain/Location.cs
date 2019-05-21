using System.Collections.Generic;

namespace Domain
{
    public class Location : DomainEntity
    {

        public MultiLangString Locations { get; set; }

        public ICollection<Competition> Competitions { get; set; }

        public ICollection<Show> Shows { get; set; }
        
    }
}