using System;
using Domain.Identity;
using ee.itcollege.mavuks.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class DogMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Dog))
            {
                return MapFromDomain((internalDTO.Dog) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Dog))
            {
                return MapFromDAL((externalDTO.Dog) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Dog MapFromDomain(internalDTO.Dog dog)
        {
            var res = dog == null ? null : new externalDTO.Dog
            {
                Id = dog.Id,
                DogName = dog.DogName,
                DateOfBirth = dog.DateOfBirth,
                DateOfDeath = dog.DateOfDeath,
                Sex = dog.Sex.Translate(),
                BreedId = dog.BreedId,
                Breed = BreedMapper.MapFromDomain(dog.Breed),
                Owner = dog.Owner,
                AppUserId = dog.AppUserId,

            };

            return res;
        }

        public static internalDTO.Dog MapFromDAL(externalDTO.Dog dog)
        {
            var res = dog == null ? null : new internalDTO.Dog
            {
                Id = dog.Id,
                DogName = dog.DogName,
                DateOfBirth = dog.DateOfBirth,
                DateOfDeath = dog.DateOfDeath,
                Sex = new internalDTO.MultiLangString(dog.Sex),
                BreedId = dog.BreedId,
                Breed = BreedMapper.MapFromDAL(dog.Breed),
                Owner = dog.Owner,
                AppUserId = dog.AppUserId,
            };
            return res;
        }
    }
}