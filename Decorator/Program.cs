namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "This is a notification!";

            INotifier notifier = new EmailNotifier();
            notifier = new LineDecorator(notifier);
            notifier = new WeChatDecorator(notifier);
            notifier = new QQDecorator(notifier);
            notifier.Send(message);
        }
    }

    interface INotifier
    {
        void Send(string message);
    }

    class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Send Email：" + message);
        }
    }

    abstract class NotifierDecorator : INotifier
    {
        protected INotifier _notifier;
        public NotifierDecorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public virtual void Send(string message)
        {
            _notifier.Send(message);
        }
    }

    class LineDecorator : NotifierDecorator
    {
        public LineDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("Send Line Message：" + message);
        }
    }

    class WeChatDecorator : NotifierDecorator
    {
        public WeChatDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("Send WeChat Message：" + message);
        }
    }

    class QQDecorator : NotifierDecorator
    {
        public QQDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("Send QQ Message：" + message);
        }
    }
}