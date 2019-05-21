using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class Location
    {
        
        public int Id { get; set; }

        public string Locations { get; set; }

        public ICollection<Competition> Competitions { get; set; }

        public ICollection<Show> Shows { get; set; }
        
    }
}