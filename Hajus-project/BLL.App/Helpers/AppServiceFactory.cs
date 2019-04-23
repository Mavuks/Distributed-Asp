using BLL.App.Services;
using BLL.Base.Helpers;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Helpers;
using Contracts.DAL.App;

namespace BLL.App.Helpers
{
    public class AppServiceFactory : BaseServiceFactory<IAppUnitOfWork>
    {
        public AppServiceFactory()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            // Register all your custom services here!
            AddToCreationMethods<IDogService>(uow => new DogService(uow));
            AddToCreationMethods<IBreedService>(uow => new BreedService(uow));
            AddToCreationMethods<ICompetitionService>(uow => new CompetitionService(uow));
            AddToCreationMethods<ILocationService>(uow => new LocationService(uow));
            AddToCreationMethods<IMaterialService>(uow => new MaterialService(uow));
            AddToCreationMethods<IParticipantService>(uow => new ParticipantService(uow));
            AddToCreationMethods<IRegistrationService>(uow => new RegistrationService(uow));
            AddToCreationMethods<ISchoolingService>(uow => new SchoolingService(uow));
            AddToCreationMethods<IShowService>(uow => new ShowService(uow));
            
        }

    }
    
}