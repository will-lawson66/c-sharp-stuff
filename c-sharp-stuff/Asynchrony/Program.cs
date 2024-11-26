using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Asynchrony;

        #region SynchronouslyMakeBreakfast

        var timer = Stopwatch.StartNew();

        {
            Coffee cup = BreakfastSync.PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = BreakfastSync.FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = BreakfastSync.FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = BreakfastSync.ToastBread(2);
            BreakfastSync.ApplyButter(toast);
            BreakfastSync.ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = BreakfastSync.PourOJ();
            Console.WriteLine("oj is ready");
        }

        Console.WriteLine($"synchronous breakfast is ready. Time required: {timer.Elapsed}");

        #endregion

        #region AsynchronouslyMakeBreakfast

        timer.Restart();
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

        }
        Console.WriteLine($"asynchronous breakfast is ready. Time required: {timer.Elapsed}");


#endregion
