using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Asynchrony;

#region SynchronouslyMakeBreakfast

var timer = Stopwatch.StartNew();

//{
//    Coffee cup = BreakfastSync.PourCoffee();
//    Console.WriteLine("coffee is ready");

//    Egg eggs = BreakfastSync.FryEggs(2);
//    Console.WriteLine("eggs are ready");

//    Bacon bacon = BreakfastSync.FryBacon(3);
//    Console.WriteLine("bacon is ready");

//    Toast toast = BreakfastSync.ToastBread(2);
//    BreakfastSync.ApplyButter(toast);
//    BreakfastSync.ApplyJam(toast);
//    Console.WriteLine("toast is ready");

//    Juice oj = BreakfastSync.PourOJ();
//    Console.WriteLine("oj is ready");
//}

//Console.WriteLine($"synchronous breakfast is ready. Time required: {timer.Elapsed}");

#endregion

#region AsynchronouslyMakeBreakfast

timer.Restart();
{
    var cup = BreakfastAsync.PourCoffee();
    Console.WriteLine("coffee is ready");


    var eggsTask = BreakfastAsync.FryEggsAsync(2);
    var baconTask = BreakfastAsync.FryBaconAsync(3);
    var toastTask = BreakfastAsync.MakeToastWithButterAndJamAsync(2);

    var breakfastTasks = new List<Task> { BreakfastAsync.FryEggsAsync(2), BreakfastAsync.FryBaconAsync(3), BreakfastAsync.MakeToastWithButterAndJamAsync(2) };
    while (breakfastTasks.Count > 0)
    {
        var finishedTask = await Task.WhenAny(breakfastTasks);
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

    var oj = BreakfastAsync.PourOJ();
    Console.WriteLine("oj is ready");

}
Console.WriteLine($"asynchronous breakfast is ready. Time required: {timer.Elapsed}");


#endregion
