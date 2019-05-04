using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class RegistrationMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Registration))
            {
                return MapFromInternal((internalDTO.Registration) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Registration))
            {
                return MapFromExternal((externalDTO.Registration) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Registration MapFromInternal(internalDTO.Registration registration)
        {
            var res = registration == null ? null : new externalDTO.Registration
            {
                Id = registration.Id,
                Title = registration.Title,
                Comment = registration.Comment,
                DogId = registration.DogId,
                Dog = DogMapper.MapFromInternal(registration.Dog),
                ParticipantId = registration.ParticipantId,
                Participant = ParticipantMapper.MapFromInternal(registration.Participant),
                CompetitionId = registration.CompetitionId,
                Competition = CompetitionMapper.MapFromInternal(registration.Competition),
                ShowId = registration.ShowId,
                Show = ShowMapper.MapFromInternal(registration.Show)
                
                
                
            };

            return res;
        }

        public static internalDTO.Registration MapFromExternal(externalDTO.Registration registration)
        {
            var res = registration == null ? null : new internalDTO.Registration
            {
                Id = registration.Id,
                Title = registration.Title,
                Comment = registration.Comment,
                DogId = registration.DogId,
                Dog = DogMapper.MapFromExternal(registration.Dog),
                ParticipantId = registration.ParticipantId,
                Participant = ParticipantMapper.MapFromExternal(registration.Participant),
                CompetitionId = registration.CompetitionId,
                Competition = CompetitionMapper.MapFromExternal(registration.Competition),
                ShowId = registration.ShowId,
                Show = ShowMapper.MapFromExternal(registration.Show)
            };
            return res;
        }
    }
}