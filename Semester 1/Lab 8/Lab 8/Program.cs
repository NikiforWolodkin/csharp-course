using Lab_8;

var publisher = new Boss();
var subscriber1 = new Technic("subscriber1", 0.5);
var subscriber2 = new Technic("subscriber2", 1);

publisher.TurnOn();

subscriber1.Subscribe(publisher);

publisher.TurnOn();
publisher.Upgrade(15);

subscriber2.Subscribe(publisher);

publisher.TurnOn();
publisher.Upgrade(15);

publisher.Upgrade(100);
publisher.Upgrade(100);
publisher.Upgrade(100);
Console.WriteLine();

string str = "Hello, World";
Console.WriteLine(str.ApplyFunctions(StringFunctions.ToLowerCase, StringFunctions.RemoveCommas));
Console.WriteLine(str.ApplyFunctions(StringFunctions.ToUpperCase, StringFunctions.RemoveCommas, StringFunctions.ReplaceSpaces, StringFunctions.AddDot));