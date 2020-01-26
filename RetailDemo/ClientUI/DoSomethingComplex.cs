using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ClientUI
{
    // Message Class
    /* Messages should be carriers for data only. By keeping 
     * your messages small and giving them clear purpose, your 
     * code will be easy to understand and evolve. */
    public class DoSomethingComplex : ICommand
    {
        public int SomeId { get; set; }
        public ChildClass ChildStuff { get; set; }
        public List<ChildClass> ListOfStuff { get; set; } = new List<ChildClass>();

    }

    public class ChildClass
    {
        public string SomeProperty { get; set; }
    }
}
