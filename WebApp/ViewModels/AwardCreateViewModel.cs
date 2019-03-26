using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class AwardCreateViewModel
    {
        public Award Award { get; set; }

        public SelectList ShowSelectList { get; set; }

        public SelectList CompetitionSelectList { get; set; }
    }
}