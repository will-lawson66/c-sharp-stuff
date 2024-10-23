using System;

namespace ExceptionHandling
{
    public static class ExceptionHandling
    {
        public static void ThrowBaseException()
        {
            throw new Exception("Base Exception " + nameof(ThrowBaseException));
        }

        public static void ThrowCustomException()
        {

            throw new CustomException("Custom Exception " + nameof(ThrowCustomException));
        }

        public static void ThrowCustomInnerException()
        {
            throw new CustomException("Custom exception with inner exception " + nameof(ThrowCustomInnerException)
                , new CustomException("Custom inner exception" + nameof(ThrowCustomInnerException)));
        }
    }

    public class CustomException : Exception
    {
        public CustomException(string msg) : base(msg)
        {

        }

        public CustomException(string msg, Exception innerException) : base(msg, innerException)
        {

        }
    }

    public class Demo
    {
        public void DoSomething()
        {
            Console.WriteLine("Start first exception trace.");
            try
            {
                try
                {
                    ExceptionHandling.ThrowCustomException();
                    ExceptionHandling.ThrowBaseException(); // code will never get here
                    ExceptionHandling.ThrowCustomException(); 
                }
                catch (CustomException cex)
                {
                    Console.WriteLine($"Caught {cex.GetType()} in CustomException catch block");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Caught {exception.GetType()} in Exception inner catch block");
                    Console.WriteLine("throwing base Exception");
                    throw;
                }

                ExceptionHandling.ThrowCustomException();
                ExceptionHandling.ThrowCustomInnerException(); // code will never get here
            }
            catch (CustomException cex)
            {
                Console.WriteLine($"Caught {cex.GetType()} in CustomException catch block");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Caught {exception.GetType()} in Exception inner catch block");
            }

            Console.WriteLine("End of all catch blocks.");
        }
    }
}

