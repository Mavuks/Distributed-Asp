using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class CompetitionMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Competition))
            {
                return MapFromInternal((internalDTO.Competition) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Competition))
            {
                return MapFromExternal((externalDTO.Competition) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Competition MapFromInternal(internalDTO.Competition competition)
        {
            var res = competition == null ? null : new externalDTO.Competition
            {
                Id = competition.Id,
                Title = competition.Title,
                Comment = competition.Comment,
                Start = competition.Start,
                End = competition.End,
                LocationId = competition.LocationId,
                Location = LocationMapper.MapFromInternal(competition.Location)
                
            };

            return res;
        }

        public static internalDTO.Competition MapFromExternal(externalDTO.Competition competition)
        {
            var res = competition == null ? null : new internalDTO.Competition
            {
                Id = competition.Id,
                Title = competition.Title,
                Comment = competition.Comment,
                Start = competition.Start,
                End = competition.End,
                LocationId = competition.LocationId,
                Location = LocationMapper.MapFromExternal(competition.Location)
                
            };
            return res;
        }
    }
}