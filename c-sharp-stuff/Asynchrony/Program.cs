using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asynchrony
{
    class Program
    {
        #region SynchronouslyMakeBreakfast

        //static void Main(string[] args)
        //{
        //    Coffee cup = Breakfast.PourCoffee();
        //    Console.WriteLine("coffee is ready");

        //    Egg eggs = Breakfast.FryEggs(2);
        //    Console.WriteLine("eggs are ready");

        //    Bacon bacon = Breakfast.FryBacon(3);
        //    Console.WriteLine("bacon is ready");

        //    Toast toast = Breakfast.ToastBread(2);
        //    Breakfast.ApplyButter(toast);
        //    Breakfast.ApplyJam(toast);
        //    Console.WriteLine("toast is ready");

        //    Juice oj = Breakfast.PourOJ();
        //    Console.WriteLine("oj is ready");
        //    Console.WriteLine("Breakfast is ready!");
        //}

        #endregion

        #region AsynchronouslyMakeBreakfast

        static async Task Main(string[] args)
        {
            Coffee cup = BreakfastAsync.PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = BreakfastAsync.FryEggsAsync(2);
            Task<Bacon> baconTask = BreakfastAsync.FryBaconAsync(3);

            //Task<Toast> toastTask = BreakfastAsync.ToastBreadAsync(2);
            Task<Toast> toastTask = BreakfastAsync.MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }

                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = BreakfastAsync.PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine("Breakfast is ready!");
        }

        #endregion
    }
}
