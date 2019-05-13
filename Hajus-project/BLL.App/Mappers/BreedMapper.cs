using System;
using ee.itcollege.mavuks.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class BreedMapper : IBaseBLLMapper
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
        
        public static BLL.App.DTO.BreedWithDogCounts MapFromInternal(internalDTO.BreedWithDogCounts breedWithDogCounts)
        {
            var res = breedWithDogCounts == null ? null : new BLL.App.DTO.BreedWithDogCounts()
            {
                Id = breedWithDogCounts.Id,
                BreedName = breedWithDogCounts.BreedName,
                BreedCount = breedWithDogCounts.BreedCount
            };
            return res;
        }
    }
}