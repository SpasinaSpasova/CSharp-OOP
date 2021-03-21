using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter CommandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            CommandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();
                var result = this.CommandInterpreter.Read(line);
                if (result == null)
                {
                    break;
                }
                Console.WriteLine(result);
            }
        }
    }
}
