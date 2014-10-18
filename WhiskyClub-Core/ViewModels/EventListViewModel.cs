using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using ReactiveUI;
using Splat;
using WhiskyClub.Core.Models;

namespace WhiskyClub.Core.ViewModels
{
    [DataContract]
    public class EventListViewModel : ReactiveObject, IRoutableViewModel
    {
        // To Be Reviewed.
        [IgnoreDataMember]
        public string UrlPathSegment
        {
            get { return "Event Listing"; }
        }

        [IgnoreDataMember]
        public IScreen HostScreen { get; protected set; }

        [DataMember]
        public ReactiveList<Event> Events { get; protected set; }

        [IgnoreDataMember]
        public ReactiveCommand<List<Event>> LoadEvents { get; protected set; }

        public EventListViewModel(IScreen screen = null)
        {
            //HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Events = new ReactiveList<Event>();


            // Command to fetch
            LoadEvents = ReactiveCommand.CreateAsyncTask(async _ => {
                var api = (IEventApi)new MockApi();

                var results = await api.GetWhiskyEvents();
                return results;
            });

            // Clear the VM
            LoadEvents.Subscribe(i => {
                Events.Clear();
                Events.AddRange(i);
            });
        }
    }

    [DataContract]
    public class EventTileViewModel : ReactiveObject
    { 
        [DataMember]
        public Event Model { get; protected set; }

        public ReactiveCommand<Object> ViewThisEvent { get; protected set; }

        public EventTileViewModel(Event model, IScreen hostScreen = null)
        {
            hostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();

            this.Model = model;
            this.ViewThisEvent = ReactiveCommand.CreateAsyncObservable(_ =>
                hostScreen.Router.Navigate.ExecuteAsync(new EventViewModel(model, hostScreen)));
        }
    }
}
