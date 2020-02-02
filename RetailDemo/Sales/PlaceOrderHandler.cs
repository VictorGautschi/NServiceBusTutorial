using Messages;
using Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace Sales
{
    // Processess messages
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>(); // static because its an expensive call
        
        static Random random = new Random();
        
        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

            // This is normally where some business logic would occur

            if (random.Next(0, 5) == 0)
            {
                throw new Exception("Oops");
            }

            // Create event
            var orderPlaced = new OrderPlaced
            {
                OrderId = message.OrderId
            };
            return context.Publish(orderPlaced);
            // return Task.CompletedTask;
        }
    }
}
