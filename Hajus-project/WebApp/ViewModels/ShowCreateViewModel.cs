using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class ShowCreateViewModel
    {
        public  BLL.App.DTO.Show Show { get; set; }

        public SelectList DogSelectList { get; set; }
        
        public SelectList LocationSelectList { get; set; }
        
        public SelectList ParticipantSelectList { get; set; }
        
    }
}