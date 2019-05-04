using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class BreedMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Breed))
            {
                return MapFromInternal((internalDTO.Breed) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Breed))
            {
                return MapFromExternal((externalDTO.Breed) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Breed MapFromInternal(internalDTO.Breed breed)
        {
            var res = breed == null ? null : new externalDTO.Breed
            {
                Id = breed.Id,
                BreedName = breed.BreedName,

            };

            return res;
        }

        public static internalDTO.Breed MapFromExternal(externalDTO.Breed breed)
        {
            var res = breed == null ? null : new internalDTO.Breed
            {
                Id = breed.Id,
                BreedName = breed.BreedName,

            };
            return res;
        }
        
        public static externalDTO.BreedWithDogCounts MapFromInternal(internalDTO.BreedWithDogCounts breedWithDogCounts)
        {
            var res = breedWithDogCounts == null ? null : new externalDTO.BreedWithDogCounts()
            {
                Id = breedWithDogCounts.Id,
                BreedName = breedWithDogCounts.BreedName,
                BreedCount = breedWithDogCounts.BreedCount
            };
            return res;
        }
    }
}