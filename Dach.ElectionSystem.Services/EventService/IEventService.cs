using System.Threading.Tasks;
using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Services.EventService
{
    public interface IEventService
    {
        Task ValidateDateRegisterEvents(EventBase eventBase);
    }
}