using System;
using ee.itcollege.mavuks.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class SchoolingMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Schooling))
            {
                return MapFromDomain((internalDTO.Schooling) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Schooling))
            {
                return MapFromDAL((externalDTO.Schooling) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Schooling MapFromDomain(internalDTO.Schooling schooling)
        {
            var res = schooling == null ? null : new externalDTO.Schooling
            {
                Id = schooling.Id,
                SchoolingName = schooling.SchoolingName.Translate(),
                Start = schooling.Start,
                MaterialId = schooling.MaterialId,
                Material = DAL.App.EF.Mappers.MaterialMapper.MapFromDomain(schooling.Material),
                LocationId = schooling.LocationId,
                Location = DAL.App.EF.Mappers.LocationMapper.MapFromDomain(schooling.Location),
                
            };

            return res;
        }

        public static internalDTO.Schooling MapFromDAL(externalDTO.Schooling schooling)
        {
            var res = schooling == null ? null : new internalDTO.Schooling
            {
                Id = schooling.Id,
                SchoolingName = new internalDTO.MultiLangString(schooling.SchoolingName),
                Start = schooling.Start,
                MaterialId = schooling.MaterialId,
                Material = DAL.App.EF.Mappers.MaterialMapper.MapFromDAL(schooling.Material),
                LocationId = schooling.LocationId,
                Location = DAL.App.EF.Mappers.LocationMapper.MapFromDAL(schooling.Location),
                
                
            };
            return res;
        }
    }
}