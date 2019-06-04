using System;
using Domain;
using ee.itcollege.mavuks.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class SchoolingMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Schooling))
            {
                return MapFromInternal((internalDTO.Schooling) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Schooling))
            {
                return MapFromExternal((externalDTO.Schooling) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Schooling MapFromInternal(internalDTO.Schooling schooling)
        {
            var res = schooling == null ? null : new externalDTO.Schooling
            {
                Id = schooling.Id,
                SchoolingName = schooling.SchoolingName,
                Start = schooling.Start,
                MaterialId = schooling.MaterialId,
                Material = MaterialMapper.MapFromInternal(schooling.Material),
                LocationId = schooling.LocationId,
                Location = LocationMapper.MapFromInternal(schooling.Location)
                
                
            };

            return res;
        }

        public static internalDTO.Schooling MapFromExternal(externalDTO.Schooling schooling)
        {
            var res = schooling == null ? null : new internalDTO.Schooling
            {
                Id = schooling.Id,
                SchoolingName = schooling.SchoolingName,
                Start = schooling.Start,
                MaterialId = schooling.MaterialId,
                Material = MaterialMapper.MapFromExternal(schooling.Material),
                LocationId = schooling.LocationId,
                Location = LocationMapper.MapFromExternal(schooling.Location)
                
                
            };
            return res;
        }
    }
}