using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory
    {

        public AppRepositoryFactory()
        {
            // add to dictionary all the repo creation methods we might need!
            
            RepositoryCreationMethods.Add(typeof(IDogRepository), 
                dataContext => new  DogRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IAwardRepository), 
                dataContext => new  AwardRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IBreedRepository), 
                dataContext => new  BreedRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ICompetitionRepository), 
                dataContext => new  CompetitionRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ILocationRepository), 
                dataContext => new  LocationRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IMaterialRepository), 
                dataContext => new  MaterialRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IParticipantRepository), 
                dataContext => new  ParticipantRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IRegistrationRepository), 
                dataContext => new  RegistrationRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISchoolingRepository), 
                dataContext => new  SchoolingRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IShowRepository), 
                dataContext => new  ShowRepository(dataContext));
            
        }
    }
}