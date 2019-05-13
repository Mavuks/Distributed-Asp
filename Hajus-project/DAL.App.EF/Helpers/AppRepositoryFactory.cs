using Contracts.DAL.App.Repositories;

using DAL.App.EF.Repositories;
using ee.itcollege.mavuks.DAL.Base.EF.Helpers;


namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory<AppDbContext>
    {
        public AppRepositoryFactory()
        {
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            AddToCreationMethods<IDogRepository>(dataContext => new DogRepository(dataContext));
            AddToCreationMethods<IBreedRepository>(dataContext => new BreedRepository(dataContext));
            AddToCreationMethods<ICompetitionRepository>(dataContext => new CompetitionRepository(dataContext));
            AddToCreationMethods<ILocationRepository>(dataContext => new LocationRepository(dataContext));
            AddToCreationMethods<IMaterialRepository>(dataContext => new MaterialRepository(dataContext));
            AddToCreationMethods<IParticipantRepository>(dataContext => new ParticipantRepository(dataContext));
            AddToCreationMethods<IRegistrationRepository>(dataContext => new RegistrationRepository(dataContext));
            AddToCreationMethods<ISchoolingRepository>(dataContext => new SchoolingRepository(dataContext));
            AddToCreationMethods<IShowRepository>(dataContext => new ShowRepository(dataContext));
        }
    }
    
    
}