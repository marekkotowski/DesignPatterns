using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler); // set next chain
        object Handle(object request);
    }


    public abstract class Handler : IHandler
    {
        private IHandler _nextHandler;   

        public IHandler SetNext (IHandler handler)
        {
            this._nextHandler = handler;
            return handler; 
        }

        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request); //call next chain
            }
            else
            {
                return null; 
            }
        }
    }

    public class MessageCreator
    {
        public Guid guid; 


        public Guid FirstPart()
        {
            return guid = Guid.NewGuid();
        }

        public Guid SecondPart()
        {
            if (guid == Guid.Empty)  return guid;
            return guid = Guid.NewGuid();
        }

        public Guid ThirdPart()
        {
            if (guid == Guid.Empty) return guid;
            return guid = Guid.NewGuid();
        }

        public Guid Confirmation()
        {
            if (guid == Guid.Empty) return guid;
            return guid =  new Guid();
        }       
        
    }


    public class DataCompletion : Handler
    {
        public override object Handle(object request)
        {
            Console.WriteLine($"Data completion start....");
            if (request is MessageCreator)
            { 
                var messageCreator = (MessageCreator)request;
                if (messageCreator.FirstPart() != null)                    
                {
                    return base.Handle(request);
                }
            }
            return "DataCompletion Error !!!";
        }
    }

    public class DataChecking : Handler
    {
        public override object Handle(object request)
        {
            Console.WriteLine($"Data checking start....");
            if (request is MessageCreator)
            {
                var messageCreator = (MessageCreator)request;
                if (messageCreator.guid != Guid.Empty)
                {
                    if (messageCreator.SecondPart() != null)
                    {
                        return base.Handle(request);
                    }
                }
            }
            return "Data Checking Error: no data to check";
        }

    }


    public class DataFormatting : Handler
    {
        public override object Handle(object request)
        {
            Console.WriteLine($"Data formatting start....");
            if (request is MessageCreator)
            {
                var messageCreator = (MessageCreator)request;
                if (messageCreator.guid != Guid.Empty)
                {
                    if (messageCreator.ThirdPart() != null)
                    {
                        return "Message posted"; 
                    }
                }
            }
            return "DataFormatting Error: no data to format";
        }
    }


    public class MessageConfirmation : Handler
    {
        public override object Handle(object request)
        {
            Console.WriteLine($"Message confirmation start....");
            if (request is MessageCreator)
            {
                var messageCreator = (MessageCreator)request;
                if (messageCreator.guid != Guid.Empty)
                {
                    if (messageCreator.Confirmation() != null)
                    {
                        return "Message posted";
                    }
                }
            }
            return "MessageConfirmation Error: no data to sent";
        }
    }

    public class MessageSender
    {
        public static void SendMessage(Handler handler, MessageCreator messagecreator)
        {
            var result = handler.Handle(messagecreator);

            Console.WriteLine($"{result}");
        }
    }
    
}
