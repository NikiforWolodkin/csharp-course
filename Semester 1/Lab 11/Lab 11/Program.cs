using Lab_11;

Console.WriteLine("Рефлексия Reflector:");

Console.WriteLine(Reflector.GetAssembly("Lab_11.Reflector"));
Console.WriteLine();

Console.WriteLine("Рефлексия Set:");

Console.WriteLine(Reflector.GetAssembly("Lab_11.Set"));
Console.WriteLine();

Console.WriteLine(Reflector.ContainsConstructors("Lab_11.Set"));
Console.WriteLine();

foreach (var method in Reflector.GetMethods("Lab_11.Set"))
{
    Console.WriteLine(method);
}
Console.WriteLine();

foreach (var property in Reflector.GetProperties("Lab_11.Set"))
{
    Console.WriteLine(property);
}
Console.WriteLine();

foreach (var iface in Reflector.GetInterfaces("Lab_11.Set"))
{
    Console.WriteLine(iface);
}
// Console.WriteLine();

foreach (var method in Reflector.GetMethodsWithParameters("Lab_11.Set", "System.Int32"))
{
    Console.WriteLine(method);
}
Console.WriteLine();

Console.WriteLine("Рефлексия House:");

Console.WriteLine(Reflector.GetAssembly("Lab_11.House"));
Console.WriteLine();

Console.WriteLine(Reflector.ContainsConstructors("Lab_11.House"));
Console.WriteLine();

foreach (var method in Reflector.GetMethods("Lab_11.House"))
{
    Console.WriteLine(method);
}
Console.WriteLine();

foreach (var property in Reflector.GetProperties("Lab_11.House"))
{
    Console.WriteLine(property);
}
Console.WriteLine();

foreach (var iface in Reflector.GetInterfaces("Lab_11.House"))
{
    Console.WriteLine(iface);
}
// Console.WriteLine();

foreach (var method in Reflector.GetMethodsWithParameters("Lab_11.House", "System.Int32"))
{
    Console.WriteLine(method);
}
Console.WriteLine();

Reflector.SerializeType("Lab_11.House", @"../house.json");

House house1 = new House();
Console.WriteLine(Reflector.Invoke(house1, "Equals"));
Console.WriteLine();

House house2 = new House(15);
object[] arguments = { house2 };
Reflector.SerializeArguments(arguments, @"../arguments.json");
Console.WriteLine(Reflector.Invoke(house1, "Equals", @"../arguments.json"));
Console.WriteLine();

House house3 = Reflector<House>.Create();
Console.WriteLine(house3);
