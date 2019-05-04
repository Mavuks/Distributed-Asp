using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class CompetitionMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Competition))
            {
                return MapFromDomain((internalDTO.Competition) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Competition))
            {
                return MapFromDAL((externalDTO.Competition) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Competition MapFromDomain(internalDTO.Competition competition)
        {
            var res = competition == null ? null : new externalDTO.Competition
            {
                Id = competition.Id,
                Title = competition.Title,
                Comment = competition.Comment,
                Start = competition.Start,
                End = competition.End,
                LocationId = competition.LocationId,
                Location = LocationMapper.MapFromDomain(competition.Location)
                
            };

            return res;
        }

        public static internalDTO.Competition MapFromDAL(externalDTO.Competition competition)
        {
            var res = competition == null ? null : new internalDTO.Competition
            {
                Id = competition.Id,
                Title = competition.Title,
                Comment = competition.Comment,
                Start = competition.Start,
                End = competition.End,
                LocationId = competition.LocationId,
                Location = LocationMapper.MapFromDAL(competition.Location)
                
            };
            return res;
        }
    }
}