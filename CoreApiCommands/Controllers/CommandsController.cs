using AutoMapper;
using CoreApiCommands.Data;
using CoreApiCommands.Dtos;
using CoreApiCommands.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiCommands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IMapper mapper;

        public CommandsController(ICommandAPIRepo repository,IMapper mapper)
        {
            Repository = repository;
            this.mapper = mapper;
        }

        public ICommandAPIRepo Repository { get; }

        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "Hello", "How", "are", "You" };
        //}
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = Repository.GetAllCommands();
            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = Repository.GetCommandById(id);
            if (commandItem==null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CommandReadDto>(commandItem));
        }


    }
}
