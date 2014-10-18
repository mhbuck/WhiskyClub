using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyClub.Core.Models;
using WhiskyClub.Core.ViewModels;
using Xunit;

namespace WhiskyClub.Core.Tests
{
    public class EventListTests
    {
        [Fact]
        public void EventsLoad()
        {
            var fixture = new EventListViewModel();
            var events = new List<Event>();

            fixture.LoadEvents.ExecuteAsync().Subscribe(x => events = x);

            var count = fixture.Events.Count;

            Assert.Equal(3, count);
        }
    }
}
