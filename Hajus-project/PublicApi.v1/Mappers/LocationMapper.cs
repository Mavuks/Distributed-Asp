using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class LocationMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Location))
            {
                return MapFromInternal((internalDTO.Location) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Location))
            {
                return MapFromExternal((externalDTO.Location) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Location MapFromInternal(internalDTO.Location location)
        {
            var res = location == null ? null : new externalDTO.Location()
            {
                Id = location.Id,
                Locations = location.Locations
                
            };

            return res;
        }
        
        public static internalDTO.Location MapFromExternal(externalDTO.Location location)
        {
            var res = location == null ? null : new internalDTO.Location()
            {
                Id = location.Id,
                Locations = location.Locations
            };

            return res;
        }

    }
}