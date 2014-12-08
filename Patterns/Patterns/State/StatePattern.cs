using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Patterns.State
{

    public class ParametersHandler
    {
        private static Dictionary<string, object> modParameters = new Dictionary<string, object>();
        private static object modCachedValue = null;

        private static ParametersHandler instance = null;
        public static ParametersHandler Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new ParametersHandler();
                return instance;
            }
        }

        private ParametersHandler()
        {
        }



        public object this[string key]
        {
            get
            {
                if (!modParameters.ContainsKey(key))
                    return null;

                return modParameters[key];
            }
            set
            {
                SetValue(key, value);
            }
        }

        private static void SetValue(string key, object value)
        {
            if (modParameters.ContainsKey(key))
            {
                modParameters[key] = value;
            }
            else
            {
                modParameters.Add(key, value);
            }
        }

        public void Add(string key, int value)
        {
            if (modParameters.ContainsKey(key))
            {
                modParameters[key] = value + (int)modParameters[key];
            }
            else
            {
                modParameters.Add(key, value);
            }
        }

        //public static object operator+(object t1, object t2)
        //{
        //    if (t1 is int && t2 is int)
        //        return (int)t1 + (int)t2;
        //    return t1;
        //}

    }

    public interface IState
    {
        string ID{get; set;}
        object Parameter { get; set; }
        bool Stop { get; set; }


        Func<bool> CheckPostCondition { get; set; }
        Action<object> DoAction { get; set; }

        void Handle();
    }


    public class StateBase : IState
    {

        public string ID { get; set; }
        public object Parameter { get; set; }
        public bool Stop { get; set; }

        public Func<bool> CheckPostCondition { get; set; }
        public Action<object> DoAction { get; set; }
    

        private ManualResetEventSlim manualResetEvent = new ManualResetEventSlim(false);

        public StateBase(string id)
        {
            ID = id;
        }

        public StateBase(string id, Action<object> doAction): 
            this(id)
        {
            DoAction = doAction;
        }

        public StateBase(string id, Action<object> doAction, Func<bool> checkPostCondition) :
            this(id, doAction)
        {
            CheckPostCondition = checkPostCondition;
        }

        private void ExecuteAction(Action<object> doAction)
        {
           // manualResetEvent.Reset();
           // manualResetEvent.Wait();
            if (DoAction != null)
            {
                DoAction(Parameter);
            }
            //manualResetEvent.Set();
        }
        public void Handle()
        {
            do
            {
                ExecuteAction(DoAction);
            }
            while (CheckPostCondition!= null && CheckPostCondition() != true);
        }


    }


    public class StateManager
    {
        private int CurrentStatePos = 0;

        public List<IState> SourcesChains { get; private set; }
        public IState CurrentState { get; private set; }
        public IState LasttState { get; private set; }


        public StateManager(List<IState> sourcesChains)
        {
            SourcesChains = sourcesChains;
        }

        public void HanldeStates()
        {
            foreach(var item in SourcesChains)
            {
                item.Handle();
                MoveState();
            }
        }
        private void MoveState()
        {
            
            LasttState = SourcesChains[CurrentStatePos];
            CurrentStatePos++;
            CurrentStatePos = CurrentStatePos % SourcesChains.Count;
            CurrentState = SourcesChains[CurrentStatePos];

        }


    }

}
