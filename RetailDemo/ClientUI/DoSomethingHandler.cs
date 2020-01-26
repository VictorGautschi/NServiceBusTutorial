using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    // Handle method will be invoked when DoSomething message comes in
    public class DoSomethingHandler : IHandleMessages<DoSomething>, IHandleMessages<DoSomethingComplex>
    {
        /* The Handle method receives the message and an IMessageHandlerContext 
         * that contains contextual API for working with messages. */
        public Task Handle(DoSomething message, IMessageHandlerContext context)
        {
            // Do something with the message here
            return Task.CompletedTask;
        }

        public Task Handle(DoSomethingComplex message, IMessageHandlerContext context)
        {
            Console.WriteLine("Received DoSomethingComplex");
            return Task.CompletedTask;
        }
    }
}

