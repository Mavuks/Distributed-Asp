using System.Collections.Generic;

namespace BLL.App.DTO
{
    public class Location
    {
        
        public int Id { get; set; }

        public string Locations { get; set; }

        public List<Competition> Competitions { get; set; }

        public List<Show> Shows { get; set; }
        
    }
}