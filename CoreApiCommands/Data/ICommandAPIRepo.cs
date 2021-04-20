﻿using CoreApiCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiCommands.Data
{
    public interface ICommandAPIRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);

        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);

        void DeleteComman(Command cmd);


    }
}
