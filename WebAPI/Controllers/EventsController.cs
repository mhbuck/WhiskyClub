﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using WhiskyClub.DataAccess.Repositories;
using WhiskyClub.WebAPI.Models;

namespace WhiskyClub.WebAPI.Controllers
{
    public class EventsController : ApiController
    {
        public IEventRepository EventRepository { get; set; }
        public IHostRepository HostRepository { get; set; }

        public EventsController() : this(new EventRepository(), new HostRepository()) { }

        public EventsController(IEventRepository eventRepository, IHostRepository hostsRepository)
        {
            if (eventRepository == null)
            {
                throw new ArgumentNullException("eventRepository");
            }

            if (hostsRepository == null)
            {
                throw new ArgumentNullException("hostsRepository");
            }            
            
            EventRepository = eventRepository;
            HostRepository = hostsRepository;
        }

        // GET api/<controller>
        public IHttpActionResult GetAll()
        {
            var events = from e in EventRepository.GetAllEvents()
                         //join h in HostRepository.GetAllHosts() on e.HostId equals h.HostId
                         orderby e.HostedDate descending
                         select new Event
                                    {
                                        EventId = e.EventId,
                                        Description = e.Description,
                                        HostedDate = e.HostedDate
                                    };

            return Ok(events);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var eventModel = EventRepository.GetEvent(id);
                var item = new Event
                               {
                                   EventId = eventModel.EventId,
                                   Description = eventModel.Description,
                                   HostedDate = eventModel.HostedDate
                               };

                var hostModel = HostRepository.GetHost(eventModel.HostId);
                item.Host = new Host
                                {
                                    HostId = hostModel.HostId,
                                    Name = hostModel.Name
                                };

                return Ok(item);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        ////// POST api/<controller>
        ////public void Post([FromBody]string value)
        ////{
        ////}

        ////// PUT api/<controller>/5
        ////public void Put(int id, [FromBody]string value)
        ////{
        ////}

        ////// DELETE api/<controller>/5
        ////public void Delete(int id)
        ////{
        ////}
    }
}