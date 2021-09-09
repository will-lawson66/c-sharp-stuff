using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace VariablesAndParameters
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region Reference type

            // firstRef is a reference to the value type StringBuilder
            var firstRef = new StringBuilder();
            firstRef.Append("Hello");
            
            // secondRef is a copy of the reference held in first
            var secondRef = firstRef;
            
            Console.WriteLine(firstRef);
            Console.WriteLine(secondRef);

            #endregion
            
            #region Value Type

            // firstVal contains the actual data assigned to it
            var firstVal = new IntHolder();
            firstVal.i = 5;
            
            // secondVal is a copy of the data assigned to first
            var secondVal = firstVal;
            secondVal.i = 6;
            
            // the two variables are totally independent once the assignment takes place
            Console.WriteLine(firstVal.i);
            Console.WriteLine(secondVal.i);

            #endregion

            #region Value parameter (pass by value)

            void NullRef(StringBuilder x)
            {
                // here, the reference to the data passed in is set to null.
                x = null;
            }

            StringBuilder y = new StringBuilder();
            y.Append("hello");
            
            NullRef(y);
            
            // there is no effect on the data to which y points
            Console.WriteLine(y == null);
            Console.WriteLine(y);

            void UseRef(StringBuilder x)
            {
                x.Append(" world.");
            }
            
            // now, the reference created in UseRef is used to modify the data pointed to
            UseRef(y);
            
            Console.WriteLine(y);

            // value parameter/value type
            void UseVal(IntHolder x)
            {
                x.i = 10;
            }

            
            firstVal.i = 5;
            Console.WriteLine(firstVal.i);
            
            UseVal(firstVal);

            // still the value of i we set.  This is not clear at all.
            Console.WriteLine(firstVal.i);

            #endregion

            #region Reference parameter (pass by reference)

            void RefParameterRefType(ref StringBuilder x)
            {
                x = null;
            }

            y = new StringBuilder();
            y.Append("hello");
            
            // here we are operating on the data itself, not a new reference to the data
            RefParameterRefType(ref y);
            Console.WriteLine(y == null);

            void RefParameterValType(ref IntHolder x)
            {
                x.i = 10;
            }

            IntHolder firstIntHolder = new IntHolder();
            firstIntHolder.i = 5;
            
            // again, the actual stored data is being operated on here
            RefParameterValType(ref firstIntHolder);
            Console.WriteLine(firstIntHolder.i);

            #endregion
        }

        public struct IntHolder
        {
            //IntHolder and its property i are value types
            public int i;
        }
    }
}
