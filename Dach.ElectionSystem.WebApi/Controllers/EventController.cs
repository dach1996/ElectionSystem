﻿using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ApiControllerBase
    {
        private IUsuarioRepository _userRepository;
        public EventController(IUsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: api/<EventController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

          var a =  await _userRepository.CreateAsync(new UserDbSet { password= "",usuario=""});
            return  Success( new string[] { "value1", "value2" });
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
