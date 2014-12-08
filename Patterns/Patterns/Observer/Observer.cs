using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Observer
{

    public interface IEventState
    {
        EventState EventStateHandler { get; }

        void Notify(object sender, object parametr);
    }

    public class EventState
    {

        public Action<object, object> Command { get; set; }
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

        public EventState(Action<object, object> command)
        {
            //this.Parameter = parameter;
            this.Command = command;
        }

        public void Notify(object sender, object parameter)
        {

            if (Command == null)
                return;

            Command(sender, parameter);
        }

    }



    public class GameUnit : IEventState
    {
        private EventState modEventState { get; set; }
        public int Life { get; private set; }
        public string ID { get; private set; }
        public EventState EventStateHandler
        {
            get { return modEventState; }
        }

        public GameUnit(string id)
        {
            this.ID = id;
            modEventState = new EventState(Notify);
            Life = 100;
        }

        public void Notify(object sender, object param)
        {
            if (sender == this)
                return;

            Life--;

            if (param is string)
                System.Console.WriteLine( sender.ToString() + " : " + ToString());
        }

        public void FindAndKillEnemies()
        {
            EventAgregator.EventAgregatorTarget.Notify(this, "Kill enemies");
        }

        public override string ToString()
        {
            return " " + ID + " " + Life;
        }

    }

    /// <summary>
    /// Description of EventAgregator.
    /// </summary>
    public class EventAgregator
    {

        private List<IEventState> modActions;

        public static EventAgregator EventAgregatorTarget
        {
            get;
            private set;
        }

        static EventAgregator()
        {
            if (EventAgregatorTarget == null)
                EventAgregatorTarget = new EventAgregator();
        }

        private EventAgregator()
        {
            modActions = new List<IEventState>();

        }

        public void Add<T>(T item) where T : IEventState
        {
            modActions.Add(item);
        }

        public List<T> Get<T>() where T : IEventState
        {
            return this.modActions.OfType<T>().ToList();
        }

        public void Notify(object parametr)
        {
            Notify(this, parametr);
        }

        public void Notify(object sender, object parametr)
        {
            foreach(var item in modActions)
            {
                item.Notify(sender, parametr);
            }
        }

    }



		//public class Simulator : IEnumerable
		//{
		//	 public string[] moves = { "5", "3", "1", "6", "7" };

		//	public IEnumerator GetEnumerator()
		//	{
		//		foreach (string element in moves)
		//			yield return element;
		//	}
		//}



		//interface ISubject
		//{
		//	void AddObserver(IObserver observer);
		//	void RemoveObserver(IObserver observer);
		//	void NotifyObservers(string s);
		//}

		//class Subject : ISubject
		//{
		//	public string SubjectState { get; set; }
		//	public List<IObserver> Observers { get; private set; }

		//	private Simulator simulator;

		//	private const int speed = 200;

		//	public Subject()
		//	{
		//		Observers = new List<IObserver>();
		//		simulator = new Simulator();
		//	}

		//	public void AddObserver(IObserver observer)
		//	{
		//		Observers.Add(observer);
		//	}

		//	public void RemoveObserver(IObserver observer)
		//	{
		//		Observers.Remove(observer);
		//	}

		//	public void NotifyObservers(string s)
		//	{
		//		foreach (var observer in Observers)
		//		{
		//			observer.Update(s);
		//		}
		//	}

		//	public void Go()
		//	{
		//		new Thread(new ThreadStart(Run)).Start();
		//	}

		//	void Run()
		//	{
		//		foreach (string s in simulator)
		//		{
		//			Console.WriteLine("Subject: " + s);
		//			SubjectState = s;
		//			NotifyObservers(s);
		//			Thread.Sleep(speed); // milliseconds
		//		}
		//	}
		//}

		//interface IObserver
		//{
		//	void Update(string state);
		//}

		//class Observer : IObserver
		//{
		//	string name;

		//	ISubject subject;

		//	string state;

		//	string gap;

		//	public Observer(ISubject subject, string name, string gap)
		//	{
		//		this.subject = subject;
		//		this.name = name;
		//		this.gap = gap;
		//		subject.AddObserver(this);
		//	}

		//	public void Update(string subjectState)
		//	{
		//		state = subjectState;
		//		Console.WriteLine(gap + name + ": " + state);
		//	}
		//}
}
