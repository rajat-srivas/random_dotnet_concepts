using System;
using System.Collections.Generic;

namespace Multithreading_vs_Asynchronous;

public class SemaphoneExecution
{
    public async void ControlledExecution()
    {
        List<Func<Task>> tasks = new List<Func<Task>>();
        tasks.Add(Function1);
         tasks.Add(Function2);
          tasks.Add(Function3);
           tasks.Add(Function4);
            tasks.Add(Function5);

        int maxConcurrentExecution = 3;
        var sem = new SemaphoreSlim(maxConcurrentExecution);

        var runningTasks = new List<Task>();

        foreach(var func in tasks)
        {


            //This allows execution of max 3 method at once. 
            await sem.WaitAsync();


            Console.WriteLine("Starting new Execution");
            runningTasks.Add(Task.Run(async () => {

                try{
                    
                    await func();
                }
                finally
                {
                    sem.Release();
                }

            }));
        }

        await Task.WhenAll(runningTasks);
    }

    public async Task Function1()
    {
       await Task.Delay(5);
        Console.WriteLine("Function1 Completed");
    }

    public async Task Function2()
    {
      await  Task.Delay(2);
        Console.WriteLine("Function2 Completed");
    }

    public async Task Function3()
    {
      await  Task.Delay(8);
        Console.WriteLine("Function3 Completed");
    }

    public async Task Function4()
    {
      await  Task.Delay(1);
        Console.WriteLine("Function4 Completed");
    }

    public async Task Function5()
    {
       await Task.Delay(10);
        Console.WriteLine("Function5 Completed");
    }
}
