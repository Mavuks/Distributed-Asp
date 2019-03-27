using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class DogCreateViewModel
    {
        public Dog Dog { get; set; }

        public SelectList AppUserSelectList { get; set; }

        public SelectList AwardSelectList { get; set; }

        public SelectList BreedSelectList { get; set; }
        
        
    }
}