using System;
using ee.itcollege.mavuks.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ParticipantMapper  : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Participant))
            {
                return MapFromDomain((internalDTO.Participant) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Participant))
            {
                return MapFromDAL((externalDTO.Participant) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Participant MapFromDomain(internalDTO.Participant participant)
        {
            var res = participant == null ? null : new externalDTO.Participant()
            {
                Id = participant.Id,
                FirstName = participant.FirstName,
                LastName = participant.LastName
                
            };

            return res;
        }
        
        public static internalDTO.Participant MapFromDAL(externalDTO.Participant participant)
        {
            var res = participant == null ? null : new internalDTO.Participant()
            {
                Id = participant.Id,
                FirstName = participant.FirstName,
                LastName = participant.LastName
            };

            return res;
        }
        
//        public static BLL.App.DTO.ParticipantNames MapFromInternal(internalDTO.ParticipantNames participantNames)
//        {
//            var res = participantNames == null ? null : new BLL.App.DTO.ParticipantNames()
//            {
//                Id = participantNames.Id,
//                FirstName = participantNames.FirstName,
//                LastName = participantNames.LastName
//            };
//            return res;
//        }

    }
}