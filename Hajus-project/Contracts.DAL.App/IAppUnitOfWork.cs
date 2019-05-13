using Contracts.DAL.App.Repositories;
using ee.itcollege.mavuks.Contracts.DAL.Base;


namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {

    
        IBreedRepository Breed { get; }
        
        IDogRepository Dog { get; }
        
        ICompetitionRepository Competition { get; }
        
        ILocationRepository Location { get; }
        
        IMaterialRepository Material { get; }
        
        IParticipantRepository Participant { get; }
        
        IRegistrationRepository Registration { get; }
        
        ISchoolingRepository Schooling { get; }
        
        IShowRepository Show { get; }
    }

}