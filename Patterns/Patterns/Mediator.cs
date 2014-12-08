using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Mediator
{

    public class EventState
    {

        public Func<object, object> Command { get; set; }
        //public event ExecuteCommand Command
        //{
        //    add 
        //    {
        //        command += value;
        //    } 
        //    remove
        //    {
        //        command -= value;
        //    }
        //}

        public EventState(Func<object, object> command)
        {
            this.Command = command;//new ExecuteCommand(command);
        }


    }


    public class ClickEventState : EventState
    {
        private Func<object, object> executeCommand;

        public ClickEventState(Func<object, object> executeCommand)
            : base(executeCommand)
        {
            // TODO: Complete member initialization
            this.executeCommand = executeCommand;
        }


    }

    /// <summary>
    /// Description of CommandExecutor.
    /// </summary>
    public class EventAgregator
    {

        List<EventState> modActions;

        public static EventAgregator EventAgregatorTarget
        {
            get;
            private set;
        }

        static EventAgregator()
        {
            EventAgregatorTarget = new EventAgregator();
        }

        public EventAgregator()
        {
            modActions = new List<EventState>();
            
        }

        public void Add<T>(T item ) where T: EventState
        {
            modActions.Add(item);
        }

        public List<T> Get<T>() where T: EventState
        {
            return this.modActions.OfType<T>().ToList();
        }

    }

    public class Switch
    {

        public Switch()
        {
            
        }

        public void ClickOnSwitch()
        {
            EventAgregator.EventAgregatorTarget.Get<ClickEventState>().ForEach(p => p.Command("Switch"));
        }


        
    }

    public class Lamp
    {
        public ClickEventState OnClick { get; set; }

        public Lamp()
        {
            OnClick = new ClickEventState((obj) => { Console.WriteLine("OnLampClicked " + obj.ToString()); return null; });

            EventAgregator.EventAgregatorTarget.Add<ClickEventState>(OnClick);
        }


    }
}
