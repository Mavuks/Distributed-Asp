using System;
using Contracts.BLL.App.Services;
using ee.itcollege.mavuks.Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IBreedService Breed { get; }
        ICompetitionService Competition { get; }
        IDogService Dog { get; }
        ILocationService Location { get; }
        IMaterialService Material { get; }
        IParticipantService Participant { get; }
        IRegistrationService Registration { get; }
        ISchoolingService Schooling { get; }

        IShowService Show { get; }
        // TODO: Public facing services
        // IContactBookService ContactBook
    }
}
