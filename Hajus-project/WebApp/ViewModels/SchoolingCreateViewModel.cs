using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class SchoolingCreateViewModel
    {
        public  BLL.App.DTO.Schooling Schooling { get; set; }

        public SelectList DogSelectList { get; set; }

        public SelectList MaterialSelectList { get; set; }
        
        
    }
}