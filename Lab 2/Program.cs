using System;

namespace Lab_2
{
    public class Program
    {
        public static void Main()
        {
            House apartment = new House();
            apartment.Print();
            House apartment2 = new House(12);
            apartment2.Print();
            House apartment3 = new House(8000);
            apartment3.Print();
            House apartment4 = new House(27, 800.15, 4);
            apartment4.Print();
            House apartment5 = new House(32, 1200.54, 5, 9, "Pushkina dom Kolotushkina", "Apartment", 50, 5);
            apartment5.Print();
            House apartment6 = new House(49, 1564, 4, 8, "Shestoy Korpus", "Apartment");
            apartment6.Print();
            House.Info();
        }
    }

    public class House
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
        public House(int apartmentNumberPar, double areaPar, int amountOfRoomsPar, int floorPar = 1, string adressPar = "Unknown", string buildingTypePar = "Unknow", int lifetimePar = -1, int agePar = 0)
        {
            ApartmentNumber = (apartmentNumberPar < 1000 && apartmentNumberPar > 0) ? apartmentNumberPar : 1;
            Area = areaPar > 0 ? areaPar : 0;
            AmountOfRooms = (amountOfRoomsPar < 100 && amountOfRoomsPar > 0) ? amountOfRoomsPar : 1;
            Floor = (floorPar < 100 && floorPar > 0) ? floorPar : 1;
            Adress = adressPar;
            BuildingType = buildingTypePar;
            Lifetime = (lifetimePar < 100 && lifetimePar > 0) ? lifetimePar : BasicLifetime;
            Age = (agePar < 100 && agePar > 0) ? agePar : 0;
            ID = Convert.ToString(ApartmentNumber) + "Unknown";
            AmountOfInstances++;
        }

        static House()
        {
            Console.WriteLine("Basic liftime?");
            BasicLifetime = Convert.ToInt32(Console.ReadLine());
            AmountOfInstances = 0;
        }

        public static void Info()
        {
            Console.WriteLine($"{AmountOfInstances} object instances exist");
        }

        public void Print()
        {
            Console.WriteLine($"ID:{ID} Number:{ApartmentNumber} Area:{Area} Rooms:{AmountOfRooms}");
            Console.WriteLine($"Floor:{Floor} Adress:{Adress} Type:{BuildingType} Lifetime:{Lifetime} Age:{Age}");
        }
    }
}
