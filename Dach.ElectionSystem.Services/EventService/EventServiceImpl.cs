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
                  if (eventBase.DateRegister > eventBase.DateMaxRegisterParticipants)
                     throw new CustomException(MessageCodesApi.IncorrectData, ResponseType.Error, HttpStatusCode.BadRequest, $"La fecha máxima de Registro de participantes {eventBase.DateMaxRegisterParticipants} no puede ser menor a la fecha de registro del evento: {eventBase.DateRegister}");
            });
        }
    }
}