using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class MaterialMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Material))
            {
                return MapFromInternal((internalDTO.Material) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Material))
            {
                return MapFromExternal((externalDTO.Material) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Material MapFromInternal(internalDTO.Material material)
        {
            var res = material == null ? null : new externalDTO.Material
            {
                Id = material.Id,
                MaterialName = material.MaterialName,
    
                
            };

            return res;
        }

        public static internalDTO.Material MapFromExternal(externalDTO.Material material)
        {
            var res = material == null ? null : new internalDTO.Material
            {
                Id = material.Id,
                MaterialName = material.MaterialName,

                
                
            };
            return res;
        }
        public static externalDTO.MaterialCounts MapFromInternal(internalDTO.MaterialCounts materialCounts)
        {
            var res = materialCounts == null ? null : new externalDTO.MaterialCounts()
            {
                Id = materialCounts.Id,
                MaterialName = materialCounts.MaterialName,
                MaterialCount = materialCounts.MaterialCount
            };
            return res;
        }
    }
}