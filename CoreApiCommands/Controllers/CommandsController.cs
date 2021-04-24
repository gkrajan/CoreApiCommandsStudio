using AutoMapper;
using CoreApiCommands.Data;
using CoreApiCommands.Dtos;
using CoreApiCommands.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{id}",Name ="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = Repository.GetCommandById(id);
            if (commandItem==null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CommandReadDto>(commandItem));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = mapper.Map<Command>(commandCreateDto);
            Repository.CreateCommand(commandModel);
            Repository.SaveChanges();
            var commandReadDto = mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = Repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            mapper.Map(commandUpdateDto, commandModelFromRepo);
            Repository.UpdateCommand(commandModelFromRepo);
            Repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id,JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = Repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            mapper.Map(commandToPatch, commandModelFromRepo);
            Repository.UpdateCommand(commandModelFromRepo);
            Repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteComman(int id)
        {
            var commandModelFromRepo = Repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            Repository.DeleteComman(commandModelFromRepo);
            Repository.SaveChanges();
            return NoContent();

        }


    }
}
