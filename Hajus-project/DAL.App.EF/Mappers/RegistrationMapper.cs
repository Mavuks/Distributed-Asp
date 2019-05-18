using System;
using BLL.App.Mappers;
using ee.itcollege.mavuks.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class RegistrationMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Registration))
            {
                return MapFromDomain((internalDTO.Registration) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Registration))
            {
                return MapFromDAL((externalDTO.Registration) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Registration MapFromDomain(internalDTO.Registration registration)
        {
            var res = registration == null ? null : new externalDTO.Registration
            {
                Id = registration.Id,
                Title = registration.Title.Translate(),
                Comment = registration.Comment.Translate(),
                DogId = registration.DogId,
                Dog = DAL.App.EF.Mappers.DogMapper.MapFromDomain(registration.Dog),
                ParticipantId = registration.ParticipantId,
                Participant = DAL.App.EF.Mappers.ParticipantMapper.MapFromDomain(registration.Participant),
                CompetitionId = registration.CompetitionId,
                Competition = DAL.App.EF.Mappers.CompetitionMapper.MapFromDomain(registration.Competition),
                ShowId = registration.ShowId,
                Show = ShowMapper.MapFromDomain(registration.Show)
                
                
                
            };

            return res;
        }

        public static internalDTO.Registration MapFromDAL(externalDTO.Registration registration)
        {
            var res = registration == null ? null : new internalDTO.Registration
            {
                Id = registration.Id,
                Title = new internalDTO.MultiLangString(registration.Title),
                Comment = new internalDTO.MultiLangString(registration.Comment),
                DogId = registration.DogId,
                Dog = DAL.App.EF.Mappers.DogMapper.MapFromDAL(registration.Dog),
                ParticipantId = registration.ParticipantId,
                Participant = DAL.App.EF.Mappers.ParticipantMapper.MapFromDAL(registration.Participant),
                CompetitionId = registration.CompetitionId,
                Competition = DAL.App.EF.Mappers.CompetitionMapper.MapFromDAL(registration.Competition),
                ShowId = registration.ShowId,
                Show = ShowMapper.MapFromDAL(registration.Show)
            };
            return res;
        }
    }
}