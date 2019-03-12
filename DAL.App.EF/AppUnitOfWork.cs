using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using Contracts.DAL.Base.Repositories;

using DAL.App.EF.Repositories;
using DAL.Base.EF.Repositories;


namespace DAL.App.EF
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        
        private readonly AppDbContext _appDbContext;

        private readonly IRepositoryProvider _repositoryProvider;

        public IAwardRepository Award =>  
            _repositoryProvider.GetRepository<IAwardRepository>();
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

        public IBaseRepositoryAsync<TEntity> BaseRepository<TEntity>() where TEntity : class, IBaseEntity, new() =>
            _repositoryProvider.GetRepositoryForEntity<TEntity>();


        public AppUnitOfWork(IDataContext dataContext, IRepositoryProvider repositoryProvider)
        {
            _appDbContext = (dataContext as AppDbContext) ?? throw new ArgumentNullException(nameof(dataContext));
            _repositoryProvider = repositoryProvider;
        }




        public virtual int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }


    }
}