using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_stuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            // calling by reference (ref & out)
            //CallByWhat.Call();

            // fizzbuzz iterative
            FB.DoIterative(100);

            // fizzbuzz recursive
            FB.DoRecursive(1, 100);
        }
    }
}
