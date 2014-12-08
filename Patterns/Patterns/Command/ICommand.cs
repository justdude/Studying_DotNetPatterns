using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Command
{
    //public interface ICommand
    //{
    //    float Target { get; }

    //    void Execute();
    //    void Undo();
    //}

    //public class MultipleCommand: ICommand
    //{
    //    public MultipleCommand(float target)
    //    {
    //        Target = target;
    //    }


    //    public float Target
    //    {
    //        get
    //        {
    //            throw new NotImplementedException();
    //        }
    //        protected set
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }


    //    public void Execute()
    //    {
    //    }
        

    //    public void Undo()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public float Target
    //    {
    //        get { throw new NotImplementedException(); }
    //    }
    //}

    //public class DevideCommand: ICommand
    //{

    //    public DevideCommand(float target)
    //    {
    //        Target = target;
    //    }

    //    public float Target
    //    {
    //        get
    //        {
    //            throw new NotImplementedException();
    //        }
    //        protected set
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }


    //    public void Execute()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Undo()
    //    {
    //        throw new NotImplementedException();
    //    }


    //}

    //public class Receiver
    //{


    //}


    //public class Invoker
    //{
    //    private Receiver receiver = new Receiver();
    //    private Stack<ICommand> modCommands = new Stack<ICommand>();

    //    public float Value { get; private set; }

    //    public Invoker(float value)
    //    {
    //        Value = value;
    //    }

    //    public void Devide(float target)
    //    {
    //        DevideCommand command = new DevideCommand(target);
    //        modCommands.Push(command);
    //    }

    //    public void Multiple(float target)
    //    {
    //        MultipleCommand command = new MultipleCommand(target);
    //        modCommands.Push(command);
    //        command.Execute();
    //    }

    //    public void Undo(int level)
    //    {
            
    //        for(int i = 0; i < modCommands.Count; i++)
    //        {
    //            var command = modCommands.Pop();
    //            command.Undo();
    //            if (level <= i) return;
    //        }
            
    //    }



    //}

}
