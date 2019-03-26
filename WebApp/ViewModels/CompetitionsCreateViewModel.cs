using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class CompetitionsCreateViewModel
    {
        public Competition Competition { get; set; }

        public SelectList DogSelectList { get; set; }

        public SelectList LocationSelectList { get; set; }

        public SelectList ParticipantSelectList { get; set; }
    }
}