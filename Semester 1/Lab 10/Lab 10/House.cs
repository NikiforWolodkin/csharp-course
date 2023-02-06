using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
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
            Console.WriteLine($"ID: {ID}, Номер квартиры: {ApartmentNumber}, Площадь: {Area}, Комнат: {AmountOfRooms}");
            Console.WriteLine($"Этаж: {Floor}, Адрес: {Adress}, Тип здания: {BuildingType}, Срок эксплутации: {Lifetime}, Возраст:{Age}");
        }
        public (int, double, int, int, int) GetInfo()
        {
            return (ApartmentNumber, Area, AmountOfRooms, Floor, Age);
        }

        public string GetAdress()
        {
            return Adress;
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
