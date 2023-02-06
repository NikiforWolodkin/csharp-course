using System.Diagnostics;
using Lab_14;

Process[] processes = Process.GetProcesses();

foreach (var process in processes)
{
    Console.Write($"{process.Id}, {process.ProcessName}, {process.BasePriority}, {process.Responding}, ");
    try
    {
        Console.Write(process.StartTime + ", ");
    }
    catch
    {
        Console.Write("недоступно, ");
    }
    try
    {
        Console.Write(process.TotalProcessorTime);
    }
    catch
    {
        Console.Write("недоступно");
    }

    Console.WriteLine();
}
Console.WriteLine();



Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
Console.WriteLine(AppDomain.CurrentDomain.SetupInformation);
foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    Console.WriteLine(assembly.FullName);
}
// AppDomain domain = AppDomain.CreateDomain("New");
// domain.Load(AppDomain.CurrentDomain.GetAssemblies()[0].FullName);
// AppDomain.Unload(domain);
Console.WriteLine();

Thread thread = new Thread(() =>
    {
        Console.WriteLine(Thread.CurrentThread.Name);
        Console.WriteLine(Thread.CurrentThread.Priority);
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine(Thread.CurrentThread.ThreadState);

        Counter.Count();

        Console.WriteLine();
    }
);
thread.Name = "New thread";
thread.Start();
thread.Join();
// thread.Suspend();
// thread.Resume();

Thread oddThread1 = new Thread(() =>
    {
        Counter.CountOdd(20, 100);
    }
);
Thread evenThread1 = new Thread(() =>
    {
        Counter.CountEven(20, 100);
    }
);
oddThread1.Start();
oddThread1.Priority = ThreadPriority.Highest;
evenThread1.Start();
evenThread1.Priority = ThreadPriority.Lowest;
oddThread1.Join();
evenThread1.Join();
Console.WriteLine();

Counter counter1 = new Counter();
Thread oddThread2 = new Thread(() =>
{
    Printer printer = new Printer();
    printer.SubscribeOdd(counter1);
}
);
Thread evenThread2 = new Thread(() =>
{
    Printer printer = new Printer();
    printer.SubscribeEven(counter1);
}
);
oddThread2.Start();
evenThread2.Start();
for (int i = 0; i < 20; i++)
{
    Thread.Sleep(50);
    counter1.IncreaseCounter();
}
Console.WriteLine();

Counter counter2 = new Counter();
Thread oddThread3 = new Thread(() =>
{
    Printer printer = new Printer();
    printer.SubscribeOdd(counter2);
}
);
Thread evenThread3 = new Thread(() =>
{
    Printer printer = new Printer();
    printer.SubscribeEven(counter2);
}
);
oddThread3.Start();
evenThread3.Start();
for (int i = 0; i < 20; i = i + 2)
{
    Thread.Sleep(50);
    counter2.SetCounter(i);
}
for (int i = 1; i < 20; i = i + 2)
{
    Thread.Sleep(50);
    counter2.SetCounter(i);
}
Console.WriteLine();

Clock clock = new Clock();
var timer = new Timer(clock.Timer, DateTime.Now.AddSeconds(10), 1000, 1000);
Thread.Sleep(11000);
timer.Dispose();