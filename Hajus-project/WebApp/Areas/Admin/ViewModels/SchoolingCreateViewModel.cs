using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class SchoolingCreateViewModel
    {
        public  BLL.App.DTO.Schooling Schooling { get; set; }

        public SelectList DogSelectList { get; set; }

        public SelectList MaterialSelectList { get; set; }
        
        
    }
}