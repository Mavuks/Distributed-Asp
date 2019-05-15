using System;
using ee.itcollege.mavuks.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class BreedMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Breed))
            {
                return MapFromDomain((internalDTO.Breed) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Breed))
            {
                return MapFromDAL((externalDTO.Breed) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Breed MapFromDomain(internalDTO.Breed breed)
        {
            var res = breed == null ? null : new externalDTO.Breed
            {
                Id = breed.Id,
                BreedNameValue = breed.BreedNameValue.Translate()

            };

            return res;
        }

        public static internalDTO.Breed MapFromDAL(externalDTO.Breed breed)
        {
            var res = breed == null ? null : new internalDTO.Breed
            {
                Id = breed.Id,
                BreedNameValue = new internalDTO.MultiLangString(breed.BreedNameValue)

            };
            return res;
        }
        
//        public static BLL.App.DTO.BreedWithDogCounts MapFromInternal(internalDTO.BreedWithDogCounts breedWithDogCounts)
//        {
//            var res = breedWithDogCounts == null ? null : new BLL.App.DTO.BreedWithDogCounts()
//            {
//                Id = breedWithDogCounts.Id,
//                BreedName = breedWithDogCounts.BreedName,
//                BreedCount = breedWithDogCounts.BreedCount
//            };
//            return res;
//        }
    }
}