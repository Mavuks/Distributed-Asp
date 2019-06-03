using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class RegistrationsCreateViewModel
    {
        public  BLL.App.DTO.Registration Registration { get; set; }

        public SelectList CompetitionSelectList { get; set; }

        public SelectList DogSelectList { get; set; }

        public SelectList ShowSelectList { get; set; }

        public SelectList ParticipantSelectList { get; set; }

        public SelectList SchoolingSelectList { get; set; }
        
        
    }
}