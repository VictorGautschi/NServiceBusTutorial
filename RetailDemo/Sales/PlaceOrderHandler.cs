using Messages;
using Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Sales
{
    // Processess messages
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>(); // static because its an expensive call

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

            // This is normally where some business logic would occur

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
