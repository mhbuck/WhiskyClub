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
    public class EventTests
    {
        [Fact]
        public void EventDetailLoad()
        {
            var model = new Event() { EventId = 3 };
            var fixture = new EventViewModel(model);
            var eventItem = default(Event);

            fixture.LoadFullEvent.ExecuteAsync().Subscribe(x => eventItem = x);

            Assert.Equal(model.EventId, fixture.Model.EventId);
            Assert.Equal("Test Event", fixture.Model.Description);
        }
    }
}

