using System;

namespace ee.itcollege.mavuks.Contracts.Base
{
    public interface ITrackableInstance
    {
        Guid InstanceId { get; }
    }
}