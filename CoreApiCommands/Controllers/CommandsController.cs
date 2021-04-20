using CoreApiCommands.Data;
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
        public CommandsController(ICommandAPIRepo repository)
        {
            Repository = repository;
        }

        public ICommandAPIRepo Repository { get; }

        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "Hello", "How", "are", "You" };
        //}
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = Repository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = Repository.GetCommandById(id);
            if (commandItem==null)
            {
                return NotFound();
            }
            return Ok(commandItem);
        }


    }
}
