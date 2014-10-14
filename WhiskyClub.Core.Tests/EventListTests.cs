using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var test = fixture.Events.Count;
        }
    }
}
