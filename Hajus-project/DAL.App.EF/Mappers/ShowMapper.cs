using System;
using ee.itcollege.mavuks.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ShowMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Show))
            {
                return MapFromDomain((internalDTO.Show) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Show))
            {
                return MapFromDAL((externalDTO.Show) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Show MapFromDomain(internalDTO.Show show)
        {
            var res = show == null ? null : new externalDTO.Show
            {
                Id = show.Id,
                Title = show.Title.Translate(),
                Comment = show.Comment.Translate(),
                Start = show.Start,
                End = show.End,
                LocationId = show.LocationId,
                Location = DAL.App.EF.Mappers.LocationMapper.MapFromDomain(show.Location)
 
                
            };

            return res;
        }

        public static internalDTO.Show MapFromDAL(externalDTO.Show show)
        {
            var res = show == null ? null : new internalDTO.Show
            {
                Id = show.Id,
                Title = new internalDTO.MultiLangString(show.Title),
                Comment = new internalDTO.MultiLangString(show.Comment),
                Start = show.Start,
                End = show.End,
                LocationId = show.LocationId,
                Location = DAL.App.EF.Mappers.LocationMapper.MapFromDAL(show.Location)

                
                
            };
            return res;
        }
    }
}