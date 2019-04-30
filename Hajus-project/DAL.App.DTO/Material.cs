using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class Material
    {
        
        public int Id { get; set; }
        
        
        public string MaterialName { get; set; }


        public List<Schooling> Schoolings { get; set; }
        
    }
}