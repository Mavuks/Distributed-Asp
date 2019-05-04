using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ParticipantMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Participant))
            {
                return MapFromInternal((internalDTO.Participant) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Participant))
            {
                return MapFromExternal((externalDTO.Participant) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Participant MapFromInternal(internalDTO.Participant participant)
        {
            var res = participant == null ? null : new externalDTO.Participant()
            {
                Id = participant.Id,
                FirstName = participant.FirstName,
                LastName = participant.LastName
                
            };

            return res;
        }
        
        public static internalDTO.Participant MapFromExternal(externalDTO.Participant participant)
        {
            var res = participant == null ? null : new internalDTO.Participant()
            {
                Id = participant.Id,
                FirstName = participant.FirstName,
                LastName = participant.LastName
            };

            return res;
        }
        
        public static externalDTO.ParticipantNames MapFromInternal(internalDTO.ParticipantNames participantNames)
        {
            var res = participantNames == null ? null : new externalDTO.ParticipantNames()
            {
                Id = participantNames.Id,
                FirstName = participantNames.FirstName,
                LastName = participantNames.LastName
            };
            return res;
        }

    }
}