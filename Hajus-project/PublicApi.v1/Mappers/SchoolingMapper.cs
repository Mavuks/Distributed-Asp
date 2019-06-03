using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class SchoolingMapper 
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
                Material = MaterialMapper.MapFromInternal(schooling.Material)
                
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
                Material = MaterialMapper.MapFromExternal(schooling.Material)
                
                
            };
            return res;
        }
    }
}