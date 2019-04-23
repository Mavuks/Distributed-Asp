using System;
using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Helpers;
using Contracts.DAL.App;
using Contracts.DAL.Base;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected readonly IAppUnitOfWork AppUnitOfWork;
        
        public AppBLL(IAppUnitOfWork appUnitOfWork, IBaseServiceProvider serviceProvider) : base(appUnitOfWork, serviceProvider)
        {
            AppUnitOfWork = appUnitOfWork;
        }

        public IDogService Dog => ServiceProvider.GetService<IDogService>();
        public IBreedService Breed => ServiceProvider.GetService<IBreedService>();
        public ICompetitionService Competition => ServiceProvider.GetService<ICompetitionService>();
        public ILocationService Location => ServiceProvider.GetService<ILocationService>();
        public IMaterialService Material => ServiceProvider.GetService<IMaterialService>();
        public IParticipantService Participant => ServiceProvider.GetService<IParticipantService>();
        public IRegistrationService Registration => ServiceProvider.GetService<IRegistrationService>();
        public ISchoolingService Schooling => ServiceProvider.GetService<ISchoolingService>();
        public IShowService Show => ServiceProvider.GetService<IShowService>();
        
    }
}