using CoreApiCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiCommands.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext contextDb;

        public SqlCommandAPIRepo(CommandContext contextDb)
        {
            this.contextDb = contextDb;
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
            return contextDb.CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
            return contextDb.CommandItems.FirstOrDefault(c => c.Id == id);
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
