namespace CSharp.Concepts;

public class Async_Multithread
{
    public void Execute()
    {
        	Console.WriteLine("Select 1 for Multithreading and 2 for Async");
			int opType = Convert.ToInt16(Console.ReadLine());

			Console.WriteLine("Starting with Id: " + Thread.CurrentThread.ManagedThreadId);

			if (opType == 1)
				SimulateMultiThreading();
			if (opType == 2)
				SimulateAsyncOperation();

			Console.WriteLine("Completed with Id: " + Thread.CurrentThread.ManagedThreadId);
			Console.ReadLine();
    }
    		private static void SimulateMultiThreading()
		{
			Thread t1 = new Thread(new ThreadStart(DownloadImage));
			Thread t2 = new Thread(new ThreadStart(CompressImage));
			Thread t3 = new Thread(new ThreadStart(SaveImage));

			t1.Start();
			t2.Start();

			Console.WriteLine("Some other task with Id: " + Thread.CurrentThread.ManagedThreadId);

			Thread.Sleep(3000);
			t3.Start();
			Thread.Sleep(3000);

			Console.WriteLine("yet another task with Id: " + Thread.CurrentThread.ManagedThreadId);
		}

		private static void SaveImage()
		{
			Console.WriteLine("Saving with Id: " + Thread.CurrentThread.ManagedThreadId);
			Thread.Sleep(1000);
			Console.WriteLine("Saved with Id: " + Thread.CurrentThread.ManagedThreadId);
		}

		private static void CompressImage()
		{
			Console.WriteLine("Compressing with Id: " + Thread.CurrentThread.ManagedThreadId);
			Thread.Sleep(1000);
			Console.WriteLine("Compressed with Id: " + Thread.CurrentThread.ManagedThreadId);
		}

		private static void DownloadImage()
		{
			Console.WriteLine("Downloading with Id: " + Thread.CurrentThread.ManagedThreadId);
			Thread.Sleep(1000);
			Console.WriteLine("Downloaded with Id: " + Thread.CurrentThread.ManagedThreadId);
		}

		static void SimulateAsyncOperation()
		{
			DownloadImageAsync();
			CompressImageAsync();
			Console.WriteLine("Some other task with Id: " + Thread.CurrentThread.ManagedThreadId);
			Thread.Sleep(3000);
			SaveImageAsync();
			Thread.Sleep(3000);
			Console.WriteLine("yet another task with Id: " + Thread.CurrentThread.ManagedThreadId);
		}
		private async static Task SaveImageAsync()
		{
			Console.WriteLine("Saving with Id: " + Thread.CurrentThread.ManagedThreadId);
			await Task.Delay(1000); //Task.Delay(1000) represents a simulated asynchronous operation that waits for one second.
			Console.WriteLine("Saved with Id: " + Thread.CurrentThread.ManagedThreadId);
		}
		private async static Task CompressImageAsync()
		{
			Console.WriteLine("Compressing with Id: " + Thread.CurrentThread.ManagedThreadId);
			await Task.Delay(1000);
			
			/*	
			When the await keyword is encountered, it evaluates the expression that follows it (an asynchronous operation) and returns the result. 
			If the expression is a Task<T> or ValueTask<T>, the method waits for the task to complete, and the result is unwrapped from the Task<T> or ValueTask<T>.
			*/

			Console.WriteLine("Compressed with Id: " + Thread.CurrentThread.ManagedThreadId);
		}
		private async static Task DownloadImageAsync()
		{
			Console.WriteLine("Downloading with Id: " + Thread.CurrentThread.ManagedThreadId);
			await Task.Delay(1000);
			Console.WriteLine("Downloaded with Id: " + Thread.CurrentThread.ManagedThreadId); 
		}
}
