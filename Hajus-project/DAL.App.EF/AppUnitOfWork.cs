using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

using DAL.App.EF.Repositories;
using ee.itcollege.mavuks.Contracts.DAL.Base.Helpers;
using ee.itcollege.mavuks.DAL.Base.EF;


namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    
    
    {
        
        public AppUnitOfWork(AppDbContext dbContext, IBaseRepositoryProvider repositoryProvider) : base(dbContext, repositoryProvider)
        {
        }

        public IBreedRepository Breed => 
            _repositoryProvider.GetRepository<IBreedRepository>();
        public IDogRepository Dog => 
            _repositoryProvider.GetRepository<IDogRepository>();
        public ICompetitionRepository Competition => 
            _repositoryProvider.GetRepository<ICompetitionRepository>();
        public ILocationRepository Location => 
            _repositoryProvider.GetRepository<ILocationRepository>();
        public IMaterialRepository Material => 
            _repositoryProvider.GetRepository<IMaterialRepository>();

        public IParticipantRepository Participant => 
            _repositoryProvider.GetRepository<IParticipantRepository>();
        public IRegistrationRepository Registration => 
            _repositoryProvider.GetRepository<IRegistrationRepository>();
        public ISchoolingRepository Schooling =>
            _repositoryProvider.GetRepository<ISchoolingRepository>();
        public IShowRepository Show => 
            _repositoryProvider.GetRepository<IShowRepository>();



    }
}