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
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            contextDb.CommandItems.Add(cmd);
        }

        public void DeleteComman(Command cmd)
        {
            if (cmd==null)
            {
                throw new NotImplementedException();
            }
            contextDb.CommandItems.Remove(cmd);           
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
            return (contextDb.SaveChanges()>=0);
        }

        public void UpdateCommand(Command cmd)
        {
          
        }
    }
}
