using Laba3;

Set set1 = new Set();
Set set2 = new Set(2);
Set set3 = new Set(2, 5, 8);

Console.WriteLine(set2.GetItem(0));
set1.Add(70);
Console.WriteLine(set1.GetItem(0));
set3.Remove(5);
Console.WriteLine(set3.GetItem(1));
Console.WriteLine("");

set2++;
Console.WriteLine(string.Join(", ", set2.ToArray()));
Console.WriteLine("");

Console.WriteLine(string.Join(", ", (set1 + set3).ToArray()));
Console.WriteLine("");

Console.WriteLine(set1 == set1);
Console.WriteLine(set1 == set2);
Set set1Copy = new Set(70);
Console.WriteLine(set1 == set1Copy);
Console.WriteLine("");

Console.WriteLine(set3 % 1);
Console.WriteLine("");

int power = set3;
Console.WriteLine(power);
Console.WriteLine("");

Set.Production production1 = new Set.Production();
Set.Production production2 = new Set.Production("Metal Pumpkin");
Console.WriteLine($"{production1.ID}, {production1.CompanyName}");
Console.WriteLine($"{production2.ID}, {production2.CompanyName}");
Console.WriteLine("");

Set.Developer developer1 = new Set.Developer();
Set.Developer developer2 = new Set.Developer("Nick Wolodkin", "ФИТ 7-1");
Console.WriteLine($"{developer1.ID}, {developer1.DeveloperName}, {developer1.Department}");
Console.WriteLine($"{developer2.ID}, {developer2.DeveloperName}, {developer2.Department}");
Console.WriteLine("");

Console.WriteLine(StatisticOperation.Sum(set3));
Console.WriteLine(StatisticOperation.DifferenceBetweenMaxAndMin(set3));
Console.WriteLine(StatisticOperation.AmountOfItems(set3));
Console.WriteLine("");

Console.WriteLine("Hello World!".Encrypt());
Console.WriteLine("Hello World!".Encrypt().Decrypt());
Console.WriteLine(set3.IsSorted());