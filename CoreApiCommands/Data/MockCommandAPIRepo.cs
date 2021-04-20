using CoreApiCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiCommands.Data
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        List<Command> Commands;
        public MockCommandAPIRepo()
        {
            Commands = new List<Command>  {new Command{
                Id = 0,
                HowTo = "How to generate a migration",
                CommandLine = "dotnet ef migrations add <Name of Migration>",
                Platform = ".Net Core EF"
            },
new Command
{
    Id = 1,
    HowTo = "Run Migrations",
    CommandLine = "dotnet ef database update",
    Platform = ".Net Core EF"
},
new Command
{
    Id = 2,
    HowTo = "List active migrations",
    CommandLine = "dotnet ef migrations list",
    Platform = ".Net Core EF"
}


            };
        }
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteComman(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
         
            return Commands;
        }

        public Command GetCommandById(int id)
        {
            return Commands.Find(i=>i.Id==id);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
