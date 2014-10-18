using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyClub.Core.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public int MemberId { get; set; }

        public string Description { get; set; }

        public DateTime HostedDate { get; set; }

        public Member Member { get; set; }

        public List<Whisky> Whiskies { get; set; }
    }

    public interface IEventApi
    {
        Task<List<Event>> GetWhiskyEvents();

        Task<Event> GetWhiskyEvent(int eventId);
    }

    public class MockApi : IEventApi
    {
        public Task<List<Event>> GetWhiskyEvents()
        {
            return Task.FromResult(new List<Event>() 
            {
                new Event() { HostedDate = DateTime.Now },
                new Event() { HostedDate = DateTime.Now.AddDays(1) },
                new Event() { HostedDate = DateTime.Now.AddDays(-1) },
            });
        }

        public Task<Event> GetWhiskyEvent(int eventId)
        {
            return Task.FromResult(new Event()
            {
                Description = "Test Event",
                EventId = eventId,
                HostedDate = DateTime.Now.AddDays(-1),
                Member = new Member()
                {
                    MemberId = 2,
                    Name = "Member 2"
                },
                MemberId = 2,
                Whiskies = new List<Whisky>()
                {
                    new Whisky()
                    {
                        Brand = "Brand",
                        WhiskyId = 2,
                    }
                },
            });
        }
    }
}
