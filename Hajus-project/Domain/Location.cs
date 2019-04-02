using System.Collections.Generic;

namespace Domain
{
    public class Location : BaseEntity
    {

        public string Locations { get; set; }

        public List<Competition> Competitions { get; set; }

        public List<Show> Shows { get; set; }
        
    }
}