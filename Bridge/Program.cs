namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMessageSender email = new EmailSender();
            IMessageSender queue = new SMSSender();
            IMessageSender web = new WebServiceSender();

            var sysmsg = new SystemMessage
            {
                Subject = "Test主旨",
                Body = "Test信件內容",
                MessageSender = email
            };
            sysmsg.Send();

            sysmsg.MessageSender = queue;
            sysmsg.Send();

            sysmsg.MessageSender = web;
            sysmsg.Send();

            var usermsg = new UserMessage
            {
                Subject = "Test主旨",
                Body = "Test信件內容",
                UserComments = "Test使用者評論",

                MessageSender = email
            };
            usermsg.Send();

            usermsg.MessageSender = queue;
            usermsg.Send();

            usermsg.MessageSender = web;
            usermsg.Send();

            Console.ReadKey();
        }
    }

    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }

    public class EmailSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"Email\n{subject}\n{body}\n");
        }
    }

    public class SMSSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"SMS\n{subject}\n{body}\n");
        }
    }

    public class WebServiceSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"Web Service\n{subject}\n{body}\n");
        }
    }


    public abstract class Message
    {
        public IMessageSender MessageSender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public abstract void Send();
    }

    public class SystemMessage : Message
    {
        public override void Send()
        {
            MessageSender.SendMessage(Subject, Body);
        }
    }

    public class UserMessage : Message
    {
        public string UserComments { get; set; }
        public override void Send()
        {
            string fullBody = string.Format($"{Body}\nUser Comments: {UserComments}");
            MessageSender.SendMessage(Subject, fullBody);
        }
    }
}