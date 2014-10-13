using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyClub.Core.Models
{
    public class Event
    {
        public DateTime EventDate { get; set; }
    }

    public interface IEventApi
    {
        Task<List<Event>> GetWhiskyEvents();
    }

    public class MockEvent : IEventApi
    {
        public Task<List<Event>> GetWhiskyEvents()
        {
            return Task.FromResult(new List<Event>() 
            {
                new Event() { EventDate = DateTime.Now },
                new Event() { EventDate = DateTime.Now.AddDays(1) },
                new Event() { EventDate = DateTime.Now.AddDays(-1) },
            });
        }
    }
}
