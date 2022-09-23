using System;

namespace Lab_2
{
    public class Program
    {
        public static void Main()
        {
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
        }
    }

    public partial class House
    {
        private readonly string ID;
        public int ApartmentNumber { get; private set; }
        private double Area { get; set; }
        private int AmountOfRooms { get; set; }
        private int Floor { get; set; }
        private string Adress { get; set; }
        private string BuildingType { get; set; }
        private int Lifetime { get; set; }
        private static int BasicLifetime { get; set; }
        private int Age { get; set; }
        private static int AmountOfInstances { get; set; }
        private const int Constant = 128;

        public House()
        {
            ApartmentNumber = 1;
            Area = 0;
            AmountOfRooms = 1;
            Floor = 1;
            Adress = "Unknown";
            BuildingType = "Apartment";
            Lifetime = BasicLifetime;
            Age = 0;
            ID = "1Unknown";
            AmountOfInstances++;
        }
        public House(int aptNumber)
        {
            ApartmentNumber = (aptNumber < 1000 && aptNumber > 0) ? aptNumber : 1;
            Area = 0;
            AmountOfRooms = 1;
            Floor = 1;
            Adress = "Unknown";
            BuildingType = "Apartment";
            Lifetime = BasicLifetime;
            Age = 0;
            ID = Convert.ToString(ApartmentNumber) + "Unknown";
            AmountOfInstances++;
        }
        public House(int apartmentNumber, double area, int amountOfRooms, int floor = 1, string adress = "Unknown", string buildingType = "Unknow", int lifetime = -1, int age = 0)
        {
            ApartmentNumber = (apartmentNumber < 1000 && apartmentNumber > 0) ? apartmentNumber : 1;
            Area = area > 0 ? area : 0;
            AmountOfRooms = (amountOfRooms < 100 && amountOfRooms > 0) ? amountOfRooms : 1;
            Floor = (floor < 100 && floor > 0) ? floor : 1;
            Adress = adress;
            BuildingType = buildingType;
            Lifetime = (lifetime < 100 && lifetime > 0) ? lifetime : BasicLifetime;
            Age = (age < 100 && age > 0) ? age : 0;
            ID = Convert.ToString(ApartmentNumber) + Adress.Replace(" ", "_");
            AmountOfInstances++;
        }

        private House(string argument) { }

        static House()
        {
            Console.WriteLine("Срок эксплуатации по умолчанию?");
            BasicLifetime = Convert.ToInt32(Console.ReadLine());
            AmountOfInstances = 0;
        }

        public override bool Equals(Object obj)
        {
            House houseObj = obj as House;
            if (houseObj == null)
                return false;
            else
                return ID.Equals(houseObj.ID);
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        public override string ToString()
        {
            return $"{ID}, {ApartmentNumber}, {Area}, {AmountOfRooms}, {Floor}, {Adress}, {BuildingType}, {Lifetime}, {Age}";
        }

        public static void ShowClassInfo()
        {
            Console.WriteLine($"Объектов класса: {AmountOfInstances}");
            Console.WriteLine($"Содержит поля ID, ApartmentNumber, Area, AmountOfRooms, Floor, Adress, BuildingType, Lifetime, BasicLifteime, Age, AmountOfInstances");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"ID: {ID}, Number: {ApartmentNumber}, Area: {Area}, Rooms: {AmountOfRooms}");
            Console.WriteLine($"Floor: {Floor}, Adress: {Adress}, Type: {BuildingType}, Lifetime: {Lifetime}, Age:{Age}");
        }
        public (int, double, int, int, int) GetInfo()
        {
            return (ApartmentNumber, Area, AmountOfRooms, Floor, Age);
        }
        public void IsRenovationRequired()
        {
            if (Age - Lifetime > 0)
            {
                Console.WriteLine("Ремонт не требуется");
            }
            else
            {
                Console.WriteLine("Ремонт требуется");
            }
        }
    }
}
