﻿using Laba2;

House apartment = new House();
Console.WriteLine("");
apartment.ShowInfo();
House apartment2 = new House(12);
apartment2.ShowInfo();
House apartment3 = new House(8000);
apartment3.ShowInfo();
House apartment4 = new House(27, 800.15, 4);
apartment4.ShowInfo();
House apartment5 = new House(32, 1200.54, 5, 9, "Pushkina dom Kolotushkina", "Apartment", 50, 55);
apartment5.ShowInfo();
House apartment6 = new House(49, 1564, 4, 8, "Shestoy Korpus", "Apartment");
apartment6.ShowInfo();
Console.WriteLine("");

apartment5.IsRenovationRequired();
apartment6.IsRenovationRequired();
Console.WriteLine("");

House.ShowClassInfo();
Console.WriteLine("");

int age = 25;
bool result;
House.IsRenovationRequired(ref age, 20, out result);
Console.WriteLine(result ? "Ремонт не требуется" : "Ремонт требуется");
Console.WriteLine(age);
Console.WriteLine("");

House[] houseArray = { apartment, apartment2, apartment3, apartment4, apartment5, apartment6 };
Console.WriteLine("Дома с 5 комнатами:");
foreach (var house in houseArray)
{
    if (house.GetInfo().Item3 == 5)
    {
        Console.WriteLine(house.ApartmentNumber);
    }
}
Console.WriteLine("Дома с 4 комнатами на этажах с 5 по 10:");
foreach (var house in houseArray)
{
    if (house.GetInfo().Item3 == 4 && house.GetInfo().Item4 <= 10 && house.GetInfo().Item4 >= 5)
    {
        Console.WriteLine(house.ApartmentNumber);
    }
}
Console.WriteLine("");

Console.WriteLine(apartment.GetType());
Console.WriteLine(apartment.ToString());
Console.WriteLine(apartment.GetHashCode());
Console.WriteLine(apartment.Equals(apartment5));
Console.WriteLine(apartment.Equals(apartment));
Console.WriteLine("");

var houseAnonymous = new { ApartmentNumber = 50, Area = 500.25, AmountOfRooms = 5, Floor = 23, Adress = "Sverdlova 14", BuildingType = "Apartment", Lifetime = 25, Age = 15 };
Console.WriteLine(houseAnonymous);