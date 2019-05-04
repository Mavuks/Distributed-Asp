using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ShowMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Show))
            {
                return MapFromInternal((internalDTO.Show) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Show))
            {
                return MapFromExternal((externalDTO.Show) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Show MapFromInternal(internalDTO.Show show)
        {
            var res = show == null ? null : new externalDTO.Show
            {
                Id = show.Id,
                Title = show.Title,
                Comment = show.Comment,
                Start = show.Start,
                End = show.End,
                LocationId = show.LocationId,
                Location = LocationMapper.MapFromInternal(show.Location)
 
                
            };

            return res;
        }

        public static internalDTO.Show MapFromExternal(externalDTO.Show show)
        {
            var res = show == null ? null : new internalDTO.Show
            {
                Id = show.Id,
                Title = show.Title,
                Comment = show.Comment,
                Start = show.Start,
                End = show.End,
                LocationId = show.LocationId,
                Location = LocationMapper.MapFromExternal(show.Location)

                
                
            };
            return res;
        }
    }
}