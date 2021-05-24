using System.Net;
using System.Threading.Tasks;
using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.ExceptionGeneric;

namespace Dach.ElectionSystem.Services.EventService
{
    public class EventServiceImpl : IEventService
    {
        public async Task ValidateDateRegisterEvents(EventBase eventBase)
        {
            await Task.Run(() =>
             {
                 if (eventBase.DateRegister > eventBase.DateMaxRegisterCandidate)
                     throw new CustomException(MessageCodesApi.IncorrectData, ResponseType.Error, HttpStatusCode.BadRequest, $"La fecha de Registro de candidatos no puede ser menor a la fecha de registro del evento: {eventBase.DateRegister}");
                 if (eventBase.DateRegister > eventBase.DateMaxRegisterParticipants)
                     throw new CustomException(MessageCodesApi.IncorrectData, ResponseType.Error, HttpStatusCode.BadRequest, $"La fecha de Registro de participantes no puede ser menor a la fecha de registro del evento: {eventBase.DateRegister}");
                 if (eventBase.DateMinVote < eventBase.DateMaxRegisterParticipants)
                     throw new CustomException(MessageCodesApi.IncorrectData, ResponseType.Error, HttpStatusCode.BadRequest, $"La fecha Mínima para votar no puede ser menor a la fecha Máxima para registro de Participantes");
                 if (eventBase.DateMinVote < eventBase.DateMaxRegisterCandidate)
                     throw new CustomException(MessageCodesApi.IncorrectData, ResponseType.Error, HttpStatusCode.BadRequest, $"La fecha Mínima para votar no puede ser menor a la fecha Máxima para registro de Candidatos");
                 if (eventBase.DateRegister > eventBase.DateMaxVote)
                     throw new CustomException(MessageCodesApi.IncorrectData, ResponseType.Error, HttpStatusCode.BadRequest, $"La fecha Máxima para votar no puede ser menor a la fecha de registro del evento: {eventBase.DateRegister}");
                 if (eventBase.DateMinVote > eventBase.DateMaxVote)
                     throw new CustomException(MessageCodesApi.IncorrectData, ResponseType.Error, HttpStatusCode.BadRequest, $"La fecha Máxima para votar no puede ser menor a la fecha Mínima para votar ");
             });
        }
    }
}