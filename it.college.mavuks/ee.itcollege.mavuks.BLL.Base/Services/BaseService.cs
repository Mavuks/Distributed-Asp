using System;
using ee.itcollege.mavuks.Contracts.BLL.Base.Services;


namespace ee.itcollege.mavuks.BLL.Base.Services
{
    public class BaseService : IBaseService
    {
        private readonly Guid _instanceId = Guid.NewGuid();
        public Guid InstanceId => _instanceId;
    }
}   