using System;
using DAL.App.DTO.Identity;
using ee.itcollege.mavuks.Contracts.DAL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;


namespace BLL.App.Mappers
{
    public class AppUserMapper : IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(AppUser))
            {
                return MapFromInternal((internalDTO.Identity.AppUser) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Identity.AppUser))
            {
                return MapFromExternal((externalDTO.Identity.AppUser) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Identity.AppUser MapFromInternal(internalDTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new externalDTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                FirstLastName = appUser.FirstLastName,

                

            };

            return res;
        }

        public static internalDTO.Identity.AppUser MapFromExternal(externalDTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new internalDTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
 

            };
            return res;
        }

    }

}