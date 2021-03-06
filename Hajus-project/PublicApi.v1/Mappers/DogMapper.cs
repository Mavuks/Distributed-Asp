using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class DogMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Dog))
            {
                return MapFromInternal((internalDTO.Dog) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Dog))
            {
                return MapFromExternal((externalDTO.Dog) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Dog MapFromInternal(internalDTO.Dog dog)
        {
            var res = dog == null ? null : new externalDTO.Dog
            {
                Id = dog.Id,
                DogName = dog.DogName,
                DateOfBirth = dog.DateOfBirth,
                DateOfDeath = dog.DateOfDeath,
                Sex = dog.Sex,
                BreedId = dog.BreedId,
                Breed = BreedMapper.MapFromInternal(dog.Breed),
                Owner = dog.Owner,
                AppUserId = dog.AppUserId
            };

            return res;
        }

        public static internalDTO.Dog MapFromExternal(externalDTO.Dog dog)
        {
            var res = dog == null ? null : new internalDTO.Dog
            {
                Id = dog.Id,
                DogName = dog.DogName,
                DateOfBirth = dog.DateOfBirth,
                DateOfDeath = dog.DateOfDeath,
                Sex = dog.Sex,
                BreedId = dog.BreedId,
                Breed = BreedMapper.MapFromExternal(dog.Breed),
                Owner = dog.Owner,
                AppUserId = dog.AppUserId
            };
            return res;
        }
    }
}