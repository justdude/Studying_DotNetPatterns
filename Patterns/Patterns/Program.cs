using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Patterns;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Facade.Facade.ReadData(25, 14);
            //Facade.Facade.PrintResult();

            //Composite();
            //Bridge();
            //Decorator();
            //Prototype();
            //Fabric();
            //FlyWeightFabric();
            //Proxy();
            //ChainOfRespinsibility();
            //Mediator();
            //Memento();
            //StateMachine();
            //Observer();
            //Command();
						//Iterator();
						//Builder();

            System.Console.Read();
        }


			private static void Builder()
			{
				Patterns.Builder.Handler handler = new Patterns.Builder.Handler();
				
				Patterns.Builder.DocxBuilder docxB = new Builder.DocxBuilder();
				Patterns.Builder.ImagesBuilder imagesB = new Builder.ImagesBuilder();
				Patterns.Builder.XLSBuilder xlsB = new Builder.XLSBuilder();

				handler.Build(docxB);
				handler.Build(imagesB);
				handler.Build(xlsB);

				Print("Docx" + docxB.Doc.ToString());
				Print("imagesB" + imagesB.Doc.ToString());
				Print("xlsB" + xlsB.Doc.ToString());

			}

				private static void Iterator()
				{
					Patterns.IterableCollection<string> iterableCollection = new IterableCollection<string>();


					iterableCollection[0] = "Hello";
					iterableCollection[1] = "all";
					iterableCollection[2] = "world";

					var iterator = iterableCollection.CreateIterator();

					Print(iterator.CurrentItem());

					while (!iterator.IsDone())
					{
						Print(iterator.Next());
					}

				}
        private static void Command()
        {
            Command.StringHandler valueProcessor = new Command.StringHandler();
            Patterns.Command.CommandHandler commandHandler = new Command.CommandHandler(" 123 4 6 ");

            commandHandler.Execute(Patterns.Command.CommandType.Reverse);
            commandHandler.Execute(Patterns.Command.CommandType.RemoveSpaces);
            commandHandler.Undo(); commandHandler.Undo();

            Print(valueProcessor.Target);
        }

        private static void Observer()
        {
            var unit1 = new Observer.GameUnit("Unit1");
            var unit2 = new Observer.GameUnit("Unit2");
            var unit3 = new Observer.GameUnit("Unit3");

            Patterns.Observer.EventAgregator.EventAgregatorTarget.Add<Patterns.Observer.GameUnit>(unit1);
            Patterns.Observer.EventAgregator.EventAgregatorTarget.Add<Patterns.Observer.GameUnit>(unit2);
            Patterns.Observer.EventAgregator.EventAgregatorTarget.Add<Patterns.Observer.GameUnit>(unit3);

            unit1.FindAndKillEnemies();
            unit2.FindAndKillEnemies(); 

            //Patterns.Observer.EventAgregator.EventAgregatorTarget.Notify("EventAgregator");
        }

        private static void StateMachine()
        {
            List<Patterns.State.IState> states = new List<State.IState>();
            states.AddRange(
                new List<State.IState> { 
                    new State.StateBase("Wake up", (p)=>
                    { 
                        Print("Wake up");
                        State.ParametersHandler.Instance["wakeUp"] = true;
                        System.Threading.Thread.Sleep(1000); 
                    }),

                    new State.StateBase("Wash teeth", (p)=>
                    {
                        Print("Wash teeth");



                        State.ParametersHandler.Instance.Add("count", 1);

                        State.ParametersHandler.Instance["washTeeth"] = true;
                        System.Threading.Thread.Sleep(1000); 
                    },
                    ()=>
                    {
                        bool result = (bool)State.ParametersHandler.Instance["wakeUp"];
                        result &= (bool)State.ParametersHandler.Instance["washTeeth"];
                        result &= (int)State.ParametersHandler.Instance["count"] > 2;

                        Print("Check is all done " + result);

                        if (result)
                            return true;

                        return false;
                    }),
                    
                    new State.StateBase("Go at work", (p)=>
                    {
                        Print("Go at work");
                    }

                    )
                }
                );


            State.StateManager manager = new State.StateManager(states);
            manager.HanldeStates();
        }


        private static void Memento()
        {
            Patterns.Memento.Vector2 vect = new Memento.Vector2(25, 15);
            Patterns.Memento.MementoVector mementoVector = vect.GetState();
            vect.X = 26;
            vect.SetMemento(mementoVector);
            Print(vect.X.ToString());

        }

        private static void Mediator()
        {
            Patterns.Mediator.Lamp lamp = new Mediator.Lamp();
            Patterns.Mediator.Switch switch_ = new Mediator.Switch();

            switch_.ClickOnSwitch();
            var clickOut = new Mediator.ClickEventState((p) => 
            { 
                Print("From out " + p.ToString()); 
                return "test"; 
            });
           
            Patterns.Mediator.EventAgregator.EventAgregatorTarget.Add<Patterns.Mediator.ClickEventState>(clickOut);
            switch_.ClickOnSwitch();
        }

        private static void ChainOfRespinsibility()
        {

            ChainOfResponsibility.Message message = new ChainOfResponsibility.Message() 
            { 
              Type = ChainOfResponsibility.MessageType.Questuion, 
              Text = "Some message" 
            };

            ChainOfResponsibility.Window window = new ChainOfResponsibility.Window();
            ChainOfResponsibility.Window infWindow = new ChainOfResponsibility.InformationWindow();
            ChainOfResponsibility.Window errorWindow = new ChainOfResponsibility.ErrorWindow();
            window.Handler = infWindow;
            infWindow.Handler = errorWindow;
            window.Handle(message);
        }

        private static void Proxy()
        {
            var collection = new int[] { 4, 1, 2 };
            var comparer = new IntComparer();
            Patterns.Proxy.ProxyArrayCollection<int> proxy = new Proxy.ProxyArrayCollection<int>(collection);
            proxy.comparer = comparer;
            Print("Proxy: " + proxy.Get(0));
            proxy.Sort();
            Print("Proxy: " + proxy.Get(0));
        }

        private class IntComparer : IComparer<int>, System.Collections.IComparer
        {

            public int Compare(int x, int y)
            {
                var res = x <= y? -1: 1;
                return res;
            }

            public int Compare(object x, object y)
            {
                var res = ((int)x) <= ((int)y) ? -1 : 1;
                return res;
            }
        }

        private static void FlyWeightFabric()
        {
            Fabric.Creator[] creators = new Fabric.Creator[]
                    { new Fabric.AppleCreator(), 
                      new Fabric.PineAplleCreator()
                    };

            string[] fruitsTypeNames = new string[] 
            { 
                Patterns.Fabric.Apple.FruitName, 
                Patterns.Fabric.PineAplle.FruitName
            };

            FlyWeight.FlyWeight creator = new FlyWeight.FlyWeight();

            int i = 0;

            foreach (var item in fruitsTypeNames)
            {
                creator.ElementsCeator = creators[i++];
                Patterns.Fabric.Fruit fruit = creator.FactoryMethdod(item);
                fruit.PrintName();
            }
        }

        private static void Fabric()
        {
            Fabric.Creator[] creators = new Fabric.Creator[]
                    { new Fabric.AppleCreator(), 
                      new Fabric.PineAplleCreator()
                    };

            foreach (var creator in creators)
            {
                Fabric.Fruit fruit = creator.FactoryMethdod();
                fruit.PrintName();
            }
        }

        private static void Prototype()
        {
            Prototype.TestClass1 inst1 = new Prototype.TestClass1("inst1");
            Prototype.Prototype prot = inst1.Clone();
            Print(prot.ID);
            prot = new Prototype.TestClass2("inst2");
        }

        private static void Composite()
        {
            Composite.ListItem composite = new Composite.ListItem("n1");
            composite.Add(new Composite.ListItemWithoutChild("d1"));
            composite.Add(new Composite.ListItemWithoutChild("d2"));
            composite.Add(new Composite.ListItem("a1"));
            composite.Display(4);
        }

        private static void Bridge()
        {
            Bridge.System system = new Bridge.Windows7();
            system.InputSystem = new Bridge.JoyStickInput();
            system.GetTouchDown();

            system.InputSystem = new Bridge.MouseInput();
            system.GetTouchDown();

            system = new Bridge.WindowsXP();
            system.InputSystem = new Bridge.MouseInput();
            system.GetTouchDown();
        }

        private static void Decorator()
        {
            Decorator.WidgetSimple widget = new Decorator.WidgetSimple();
            Decorator.Control ctr = new Decorator.Control();
            Decorator.ControlAdditional ctrAdditional = new Decorator.ControlAdditional();
            ////////////
            ctr.Set(widget);
            ctrAdditional.Set(ctr);
            /////
            ctr.Show();
            Print();
            ctrAdditional.Show();
        }

        public static void Print(string str)
        {
            System.Console.WriteLine(str);
        }
        public static void Print()
        {
            System.Console.WriteLine("");
        }


    }
}
