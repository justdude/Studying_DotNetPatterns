using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Command
{

    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }

    public class SimpleCommand : ICommand
    {
        private Action<string> modAction { get; set; }
        private string modRevertState { get; set; }
        public string Target { get; set; }

        private StringHandler modHandler;

        public SimpleCommand(StringHandler handler, CommandType commandType)
        {
            modHandler = handler;
            Target = handler.Target;
            modRevertState = handler.Target;
            modAction = handler.GetCommand(commandType);
        }

        public void Execute()
        {
            modRevertState = modHandler.Target;
            modAction(modHandler.Target);
            System.Console.WriteLine("Execute: " + modHandler.Target);
        }


        public void UnExecute()
        {
            modHandler.Target = modRevertState;

            System.Console.WriteLine("UnExecute: " + modHandler.Target);
        }

    }
        public enum CommandType
        {
            Reverse = 2,
            RemoveSpaces = 4
        }

    //Receiver
    public class StringHandler
    {
        //private CommandType modCommandType;
        public string Target { get; set; }

        private Action<string> OnExecute;

        public StringHandler()
        {
           
        }

        public Action<string> GetCommand(CommandType modCommandType)
        {
            switch (modCommandType)
            {
                case CommandType.RemoveSpaces:
                    OnExecute = RemoveSpaces;
                    break;

                case CommandType.Reverse:
                    OnExecute = Reverse;
                    break;

            }
            return OnExecute;
        }

        private void Reverse(string target)
        {
            //Target = target.Reverse().ToString();

            StringBuilder builder = new StringBuilder();

            for (int i = target.Count() - 1; i >= 0; i--)
            {
                builder.Append(target[i]);
            }
            Target = builder.ToString();
        }


        private void RemoveSpaces(string target)
        {
            Target = target.Trim();
        }



    }

    public class CommandHandler
    {
        private List<ICommand> modCommands { get; set; }
        private StringHandler handler;

        public CommandHandler(string target)
        {
            handler = new StringHandler();
            modCommands = new List<ICommand>();
            handler.Target = target;
        }

        public void Execute(CommandType commandType)
        {
            ICommand command = new SimpleCommand(handler, commandType);

            command.Execute();

            modCommands.Add(command);
        }

        public void Undo()
        {
            var command = modCommands.Last();
            
            if (command == null)
                return;

            command.UnExecute();
            modCommands.Remove(command);
        }

    }

}
