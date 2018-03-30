using System;
using System.IO;

namespace StudentSolution
{
    class CommandManagerExample
    {
        BuildFileExample _buildFileExample = new BuildFileExample();
        public void Execute()
        {
            _buildFileExample.Execute();
            CommandManager commandManager = new CommandManager();
            Console.WriteLine("SearchByName");
            commandManager.Execute(_buildFileExample.FileName, "name=Leia");

            Console.WriteLine("\nSearchByType");
            commandManager.Execute(_buildFileExample.FileName, "type=Kinder");

            Console.WriteLine("\nSearchByTypeAndGender");
            commandManager.Execute(_buildFileExample.FileName, "type=Kinder", "gender=M");
        }
    }
}
