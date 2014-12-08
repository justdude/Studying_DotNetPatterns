using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.ChainOfResponsibility
{

    public enum MessageType
    {
        Questuion = 0,
        Information = 2,
        Error = 4
    }


    public class Message
    {
        public MessageType Type { get; set; }
        public string Text { get; set; }
    }

    public abstract class MessageHandler
    {
        public MessageHandler Handler { get; set; }
        public virtual void Handle(Message message)
        {
            if (Handler == null)
                return;

            Handler.Handle(message);
            System.Console.WriteLine(message.Type.ToString() + " " + message.Text);
        }
    }


    public class Window: MessageHandler
    {
        public override void Handle(Message message)
        {
            if (message == null) //|| message.Type == MessageType.Error)
                return;

            base.Handle(message);
        }
    }

    public class InformationWindow : Window
    {
        public override void Handle(Message message)
        {
            if (message == null || message.Type != MessageType.Information)
                return;

            base.Handle(message);
        }
    }

    public class ErrorWindow : Window
    {
        public override void Handle(Message message)
        {
            if (message == null || message.Type != MessageType.Error)
                return;

            base.Handle(message);
        }
    }

}
