using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_stuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            // calling by reference (ref & out)
            CallByWhat.Call();

            AbstractVirtualInterfaceObject work = new AbstractVirtualInterfaceObject();
            work.DoSomething();
        }
    }
}
