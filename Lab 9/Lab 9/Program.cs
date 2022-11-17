using Lab_9;
using System.Collections.Generic;
using System.Collections.ObjectModel;

Software mongo = new Software("Mongo");
Software exress = new Software("Exress");
Software react = new Software("React");
Software node = new Software("NodeJS");

SoftwareCollection<Software> software = new SoftwareCollection<Software>(mongo, exress, node, react);
software.Print();
Console.WriteLine();

((IList<Software>)software).RemoveAt(2);
software.Print();
Console.WriteLine();

((IList<Software>)software).Insert(3, node);
software.Print();
Console.WriteLine();

Console.WriteLine(((ICollection<Software>)software).Contains(node));
Console.WriteLine(((IList<Software>)software)[3].Name);
Console.WriteLine();

SortedList<int, string> list = new SortedList<int, string>();
list.Add(1, "String 1");
list.Add(3, "String 2");
list.Add(5, "String 3");
list.Add(7, "String 4");
list.Add(9, "String 5");

for (int i = 4; i > 2; i--)
{
    list.RemoveAt(i);
}

list.Add(11, "String 6");
list[13] = "String 7";

Dictionary<int, string> dictionary = new Dictionary<int, string>(list);

foreach (var item in dictionary)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}
Console.WriteLine();

Console.WriteLine(dictionary.ContainsValue("String 7"));

ObservableCollectionContainer collection = new ObservableCollectionContainer(mongo, exress, node, react);
collection.Remove(2);
collection.Insert(3, node);

