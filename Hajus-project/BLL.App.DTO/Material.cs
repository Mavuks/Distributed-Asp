using System.Collections.Generic;

namespace BLL.App.DTO
{
    public class Material
    {
        
        public int Id { get; set; }
        
        
        public string MaterialName { get; set; }


        public List<Schooling> Schoolings { get; set; }
        
    }
}