using CSharp.Concepts;

namespace Multithreading_vs_Asynchronous
{
	public class Program
	{
		static void Main(string[] args)
		{
			Async_Multithread asy = new Async_Multithread();
			//asy.Execute();

			SemaphoneExecution sem  = new SemaphoneExecution();
			sem.ControlledExecution();

			Console.ReadLine();

		}
	}
}
