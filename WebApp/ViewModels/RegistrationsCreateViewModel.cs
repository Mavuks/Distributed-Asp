using System.Reflection.Metadata.Ecma335;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class RegistrationsCreateViewModel
    {
        public Registration Registration { get; set; }

        public SelectList CompetitionSelectList { get; set; }

        public SelectList DogSelectList { get; set; }

        public SelectList ShowSelectList { get; set; }

        public SelectList ParticipantSelectList { get; set; }
        
        
    }
}