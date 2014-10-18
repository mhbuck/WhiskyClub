using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ReactiveUI;
using Splat;
using WhiskyClub.Core.Models;

namespace WhiskyClub.Core.ViewModels
{
    [DataContract]
    public class EventViewModel
    {
        [IgnoreDataMember]
        public string UrlPathSegment
        {
            get { return "Event "; } // + Model.team; }
        }

        [IgnoreDataMember]
        public IScreen HostScreen { get; protected set; }

        [DataMember]
        public Event Model { get; protected set; }

        [IgnoreDataMember]
        public ReactiveCommand<Event> LoadFullEvent { get; protected set; }

        public EventViewModel(Event model, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Model = model;

            LoadFullEvent = ReactiveCommand.CreateAsyncTask(async _ => {
                var api = (IEventApi)new MockApi();
                var eventDetail = await api.GetWhiskyEvent(Model.EventId);
                return eventDetail;
            });

            LoadFullEvent.Subscribe(x => Model = x);
        }
    }
}
