using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
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
            get { return "Login"; }
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

            var api = (IEventApi)new MockEvent();

            // Command to fetch
            LoadEvents = ReactiveCommand.CreateAsyncTask(async _ => {
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
}
