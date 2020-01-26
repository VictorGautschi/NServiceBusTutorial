using Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    class Program
    {
        static void Main()
        {
            AsyncMain().GetAwaiter().GetResult();
        }


        static async Task AsyncMain()
        {
            /* When running multiple console apps in the same solution, 
             * giving each a name makes them easier to identify. */
            Console.Title = "ClientUI";

            /* The EndpointConfiguration class is where we define all the 
             * settings that determine how our endpoint will operate. The 
             * single string parameter ClientUI is the endpoint name, which 
             * serves as the logical identity for our endpoint, and forms a 
             * naming convention by which other things will derive their names, 
             * such as the input queue where the endpoint will listen for messages 
             * to process. */
            var endpointConfiguration = new EndpointConfiguration("ClientUI");

            /* This setting defines the transport that NServiceBus will use to 
             * send and receive messages. We are using the LearningTransport, 
             * which is bundled in the NServiceBus core library as a starter 
             * transport for learning how to use NServiceBus without any additional 
             * dependencies. All other transports are provided using different 
             * NuGet packages. */
            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            /* start the endpoint, and await input */
            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            await RunLoop(endpointInstance).ConfigureAwait(false);
            await endpointInstance.Stop().ConfigureAwait(false);


            /* Note how after sending a message, the prompt from ClientUI.Program is displayed 
             * before the ClientUI.PlaceOrderHandler acknowledges receipt of the message. This 
             * is because rather than calling the Handle method as a direct method call, the 
             * message is sent asynchronously, and then control immediately returns to the RunLoop 
             * which repeats the prompt. It isn't until a bit later, when the message is received 
             * and processed, that we see the Received PlaceOrder notification. */

        }

        private static ILog log = LogManager.GetLogger<Program>();

        private static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                log.Info("Press 'P' to place an order, or 'Q' to quit.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        // Instantiate the command
                        var command = new PlaceOrder
                        {
                            OrderId = Guid.NewGuid().ToString() // unique value here
                        };

                        // Send the command to the local endpoint
                        log.Info($"Sending PlaceOrder command, OrderId = {command.OrderId}");
                        await endpointInstance.SendLocal(command).ConfigureAwait(false);

                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        log.Info("Unknown input. Please try again.");
                        break;
                }
            }
        }
    }
}
