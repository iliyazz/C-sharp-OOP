namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Common;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();
            string commandName = tokens[0];
            string[] commangArg = tokens.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"{commandName}Command");
            if (type == null)
            {
                throw new InvalidOperationException(string.Format(ErrorMessages.InvalidCommandType, $"{commandName} Command"));
            }
            object commandInstance = Activator.CreateInstance(type);
            MethodInfo executeMethod = type.GetMethods().FirstOrDefault(x => x.Name == "Execute");


            string result = (string)executeMethod.Invoke(commandInstance, new object[] {commangArg});
            return result;
        }
    }
}
