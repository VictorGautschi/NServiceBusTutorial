using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;


namespace ClientUI
{
    /* he name of the command class is also important. 
     * A command is an order to do something, so it should 
     * be named in the imperative tense. PlaceOrder and 
     * ChargeCreditCard are good names for commands, because 
     * they are phrased as a command and are very specific. 
     * PlaceOrder will place an order and ChargeCreditCard 
     * will charge money on a credit card. CustomerMessage, 
     * on the other hand, is not a good example. It is not in 
     * the imperative, and it's vague. Another developer should 
     * know exactly what a command's purpose is just by reading 
     * the name. */
    public class DoSomething : ICommand
    {
        public string SomeProperty { get; set; }

    }
}
