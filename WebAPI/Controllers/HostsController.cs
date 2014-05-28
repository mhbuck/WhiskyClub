﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhiskyClub.DataAccess.Repositories;
using WhiskyClub.WebAPI.Models;

namespace WhiskyClub.WebAPI.Controllers
{
    public class HostsController : ApiController
    {
        public IHostRepository HostRepository { get; set; }

        public HostsController() : this(new HostRepository()) { }

        public HostsController(IHostRepository hostRepository)
        {
            if (hostRepository == null)
            {
                throw new ArgumentNullException("hostRepository");
            }
            
            HostRepository = hostRepository;
        }

        // GET api/<controller>
        public IHttpActionResult GetAll()
        {
            var hosts = from h in HostRepository.GetAllHosts()
                        select new Host
                        {
                            HostId = h.HostId,
                            Name = h.Name
                        };

            return Ok(hosts);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int hostId)
        {
            try
            {
                var hostModel = HostRepository.GetHost(hostId);
                var item = new Host
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