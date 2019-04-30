using System;
using Contracts.BLL.Base.Mappers;
using Domain;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class ShowMapper : IBaseBLLMapper
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