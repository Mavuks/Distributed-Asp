using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class CompetitionsCreateViewModel
    {
        public  BLL.App.DTO.Competition Competition { get; set; }

        public SelectList DogSelectList { get; set; }

        public SelectList LocationSelectList { get; set; }

        public SelectList ParticipantSelectList { get; set; }
    }
}