using System;
using ee.itcollege.mavuks.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class MaterialMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Material))
            {
                return MapFromDomain((internalDTO.Material) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Material))
            {
                return MapFromDAL((externalDTO.Material) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Material MapFromDomain(internalDTO.Material material)
        {
            var res = material == null ? null : new externalDTO.Material
            {
                Id = material.Id,
                MaterialName = material.MaterialName.Translate()
    
                
            };

            return res;
        }

        public static internalDTO.Material MapFromDAL(externalDTO.Material material)
        {
            var res = material == null ? null : new internalDTO.Material
            {
                Id = material.Id,
                MaterialName = new internalDTO.MultiLangString(material.MaterialName)

                
                
            };
            return res;
        }
//        public static BLL.App.DTO.MaterialCounts MapFromInternal(internalDTO.MaterialCounts materialCounts)
//        {
//            var res = materialCounts == null ? null : new BLL.App.DTO.MaterialCounts()
//            {
//                Id = materialCounts.Id,
//                MaterialName = materialCounts.MaterialName,
//                MaterialCount = materialCounts.MaterialCount
//            };
//            return res;
//        }
    }
}