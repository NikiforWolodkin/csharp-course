using Lab_10;
using System.Linq;

string[] months = {
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December"
};

var selectedMonths = from month in months
                     where month.Length == 5
                     select month;
foreach (var month in selectedMonths)
{
    Console.WriteLine(month);
}
Console.WriteLine();

selectedMonths = from month in months.Skip(11).Union(months.Take(2)).Union(months.Skip(5).Take(3))
                 select month;
foreach (var month in selectedMonths)
{
    Console.WriteLine(month);
}
Console.WriteLine();

selectedMonths = from month in months
                 orderby month
                 select month;
foreach (var month in selectedMonths)
{
    Console.WriteLine(month);
}
Console.WriteLine();

selectedMonths = from month in months
                 where month.Contains("u") && month.Length >= 4
                 select month;
foreach (var month in selectedMonths)
{
    Console.WriteLine(month);
}
Console.WriteLine();

House apartment1 = new House(32, 1200.54, 5, 9, "Pushkina 32a", "Apartment");
House apartment2 = new House(27, 9000, 15, 1, "Pushkina 18", "Apartment");
House apartment3 = new House(11, 1567, 6, 12, "Pushkina 32a", "Apartment");
House apartment4 = new House(14, 546, 2, 8, "Pushkina 117b", "Apartment");
House apartment5 = new House(15, 1110, 5, 10, "Pushkina 14", "Apartment");
House apartment6 = new House(33, 1210, 4, 2, "Sverdlova 32a", "Apartment");
House apartment7 = new House(28, 900, 3, 4, "Sverdlova 18", "Apartment");
House apartment8 = new House(12, 1235, 5, 19, "Sverdlova 46", "Apartment");
House apartment9 = new House(17, 1546, 7, 3, "Sverdlova 117b", "Apartment");
House apartment10 = new House(19, 111, 1, 44, "Sverdlova 46", "Apartment");

List<House> houses = new List<House>();
houses.Add(apartment1);
houses.Add(apartment2);
houses.Add(apartment3);
houses.Add(apartment4);
houses.Add(apartment5);
houses.Add(apartment6);
houses.Add(apartment7);
houses.Add(apartment8);
houses.Add(apartment9);
houses.Add(apartment10);

var selectedHouses = from house in houses
                     where house.GetInfo().Item3 == 5
                     select house;
foreach (var house in selectedHouses)
{
    Console.WriteLine(house);
}
Console.WriteLine();

selectedHouses = from house in houses
                 where house.GetAdress() == "Sverdlova 46"
                 select house;
foreach (var house in selectedHouses.Take(5))
{
    Console.WriteLine(house);
}
Console.WriteLine();

selectedHouses = from house in houses
                 where house.GetAdress().Contains("Sverdlova")
                 select house;
Console.WriteLine(selectedHouses.Count());
Console.WriteLine();

selectedHouses = from house in houses
                 where house.GetInfo().Item3 == 5
                 && house.GetInfo().Item4 < 20
                 && house.GetInfo().Item4 > 5
                 select house;
foreach (var house in selectedHouses.Take(5))
{
    Console.WriteLine(house);
}
Console.WriteLine();

selectedHouses = from house in houses.ToArray().Skip(2).Take(5)
                 where house.GetAdress().Contains("Sverdlova")
                 orderby house.GetInfo().Item2
                 select house;
foreach (var house in selectedHouses)
{
    Console.WriteLine(house);
}
Console.WriteLine();

Street[] streets = {
    new Street("Sverdlova", 34),
    new Street("Pushkina", 48),
};

var selectedHousesAndStreets = from house in houses
                               join street in streets
                               on house.GetAdress().Substring(0, house.GetAdress().IndexOf(" "))
                               equals street.Name
                               select new {
                                   Apartment = house.ApartmentNumber,
                                   Street = street.Name,
                                   Amount = street.AmountOfHouses
                               };
foreach (var house in selectedHousesAndStreets)
{
    Console.WriteLine($"{house.Apartment} - {house.Street}, {house.Amount}");
}