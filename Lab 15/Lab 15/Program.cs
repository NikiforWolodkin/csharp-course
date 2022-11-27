using Lab_15;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;

int[] vector = new int[100000];
Random random = new Random();
for (int i = 0; i < vector.Length; i++)
{
    vector[i] = random.Next(1, 1000);
}
int[] vectorCopy = vector.Select(number => number).ToArray();

Lab_15.Timer timer = new Lab_15.Timer();
timer.MeasureTask(vector);
vector = vectorCopy.Select(number => number).ToArray();
timer.MeasureTask(vector);
vector = vectorCopy.Select(number => number).ToArray();
timer.MeasureTask(vector);
vector = vectorCopy.Select(number => number).ToArray();
Console.WriteLine();
timer.MeasureAlgorithm(vector);
vector = vectorCopy.Select(number => number).ToArray();
timer.MeasureAlgorithm(vector);
vector = vectorCopy.Select(number => number).ToArray();
timer.MeasureAlgorithm(vector);
vector = vectorCopy.Select(number => number).ToArray();
Console.WriteLine();

Cancelation.ShowTaskCancelation(vector);
vector = vectorCopy.Select(number => number).ToArray();

Console.WriteLine(QuadraticEquation.SumQuadraticEquationSolutions(2, 16, 4));
Console.WriteLine();

Continuation.ShowContinuationWithContinue(vector);
vector = vectorCopy.Select(number => number).ToArray();
Console.WriteLine();
Continuation.ShowContinuationAwaiter(vector);
vector = vectorCopy.Select(number => number).ToArray();
Console.WriteLine();

Parallelity.ShowParallelFor();
Parallelity.ShowParallelFor();
Parallelity.ShowParallelFor();
Console.WriteLine();
Parallelity.ShowFor();
Parallelity.ShowFor();
Parallelity.ShowFor();
Console.WriteLine();
Parallelity.ShowParallelForeach();
Parallelity.ShowParallelForeach();
Parallelity.ShowParallelForeach();
Console.WriteLine();
Parallelity.ShowForeach();
Parallelity.ShowForeach();
Parallelity.ShowForeach();
Console.WriteLine();

Parallel.Invoke(
    () => {
        Parallelity.ShowParallelFor();
    },
    () => {
        Parallelity.ShowParallelForeach();
    },
    () => {
        Parallelity.ShowFor();
    },
    () => {
        Parallelity.ShowForeach();
    }
);
Console.WriteLine();

AsyncAwait.MultiplyVectorAsync(vector);
for (int i = 0; i < vector.Length; i += 10000)
{
    Console.WriteLine(vector[i]);
}
Console.WriteLine();

Warehouse warehouse = new Warehouse();
Supplier supplier1 = new Supplier(2000, "Стиальная машина", warehouse);
Supplier supplier2 = new Supplier(1000, "Посудомойка", warehouse);
Supplier supplier3 = new Supplier(5000, "Плита", warehouse);
Supplier supplier4 = new Supplier(6000, "Вытяжка", warehouse);
Supplier supplier5 = new Supplier(2000, "Микроволновка", warehouse);
Consumer consumer1 = new Consumer(1500, warehouse);
Consumer consumer2 = new Consumer(1200, warehouse);
Consumer consumer3 = new Consumer(1300, warehouse);
Consumer consumer4 = new Consumer(1600, warehouse);
Consumer consumer5 = new Consumer(1400, warehouse);
Consumer consumer6 = new Consumer(1200, warehouse);
Consumer consumer7 = new Consumer(1100, warehouse);
Consumer consumer8 = new Consumer(2000, warehouse);
Consumer consumer9 = new Consumer(1900, warehouse);
Consumer consumer10 = new Consumer(1400, warehouse);
Thread.Sleep(60000);