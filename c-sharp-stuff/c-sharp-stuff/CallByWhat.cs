using System;

namespace c_sharp_stuff
{
    class CallByWhat
    {
        public static void Call()
        {
            // call by reference
            Console.WriteLine("calling by reference (ref)");
            string testRef = "abcdefg";
            Console.WriteLine(CallByRef(ref testRef));
            Console.ReadKey();

            Console.WriteLine("calling by reference (out)");
            //string testOut;
            Console.WriteLine(CallByOut(out string testOut));
            Console.ReadKey();
        }

        public static string CallByRef(ref string thing)
        {
            string result = $"called by reference (ref): {thing}";
            return result;
        }

        public static string CallByOut(out string thing)
        {
            thing = "1234567";
            return $"called by reference (out): {thing}";
        }
    }
}
