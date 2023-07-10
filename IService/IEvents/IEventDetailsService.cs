using JatraApplication.Models.DatabaseModels;

namespace JatraApplication.IService.Events
{
    public interface IEventDetailsService
    {
        Event GetDetails(int eventId);
    }
}
