using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_stuff
{
    public interface IAbstractvirtualinterface
    {
        string I { get; set; }
        string AddItInterface(string x);
    }
    
    public abstract class AbstractVirtualInterface
    {
        private string i;

        public abstract string AddItAbstract(string x);

        public virtual string AddItVirtual(string x)
        {
            return x + "virtual base method";
        }

        public string AddIt(string x)
        {
            return x + "base method";
        }
    }

    public class AbstractVirtualInterfaceObject : AbstractVirtualInterface, IAbstractvirtualinterface
    {
        public string I { get; set; }

        public string AddItInterface(string x)
        {
            return I + "implement interface method";
        }

        public override string AddItAbstract(string x)
        {
            return x + "required override base abstract method";
        }

        public override string AddItVirtual(string x)
        {
            return x + "optional override base virtual method";
        }

        public string AddIt(string x)
        {
            return x + "optional concrete class implementation";
        }

        public void DoSomething()
        {
            I = "Concrete property - ";
            Console.WriteLine(AddItInterface("Concrete class - "));
            Console.WriteLine(AddItAbstract("Concrete class - "));
            Console.WriteLine(AddItVirtual("Concrete class - "));
            Console.WriteLine(base.AddItVirtual("Concrete class - "));
            Console.WriteLine(base.AddIt("Concrete class - "));
            Console.WriteLine(this.AddIt("Concrete class - "));
        }
    }
}
