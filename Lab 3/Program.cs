using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("Hello World!".Encrypt());
            Console.WriteLine("Hello World!".Encrypt().Decrypt());
            Console.WriteLine(set3.IsSorted());
            Console.WriteLine("");
        }
    }

    public static class StatisticOperation
    {
        public static int Sum(Set set)
        {
            return set.ToArray().Sum();
        }

        public static int DifferenceBetweenMaxAndMin(Set set)
        {
            return (set.ToArray().Max() - set.ToArray().Min());
        }

        public static int AmountOfItems(Set set)
        {
            return (set.Count);
        }

        public static string Encrypt(this string str)
        {
            char[] encryptedString = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                encryptedString[i]++;
            }
            return String.Join("", encryptedString);
        }

        public static string Decrypt(this string str)
        {
            char[] encryptedString = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                encryptedString[i]--;
            }
            return String.Join("", encryptedString);
        }

        public static bool IsSorted(this Set set)
        {
            int[] array = set.ToArray();
            Array.Sort(array);
            return array.SequenceEqual(set.ToArray());
        }
    }

    public class Set
    {
        private List<int> _items;
        public int Count => _items.Count;

        public Set()
        {
            _items = new List<int>();
        }
        public Set(params int[] items)
        {
            _items = new List<int>(items);
        }

        public override int GetHashCode()
        {
            return string.Join("", _items.ToArray()).GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Set set)
            {
                return string.Join("", _items.ToArray()).GetHashCode() == set.GetHashCode();
            }

            return false;
        }

        public void Add(int item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }

        public void Remove(int item)
        {
            if (!_items.Contains(item))
            {
                throw new KeyNotFoundException($"Элемент {item} не найден в множестве.");
            }

            _items.Remove(item);
        }

        public int GetItem(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Элемент по индексу {index} не найден в множестве.");
            }

            return _items[index];
        }

        public int[] ToArray()
        {
            return _items.ToArray();
        }

        public static Set Union(Set set1, Set set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            Set resultSet = new Set();

            List<int> items = new List<int>();

            if (set1._items != null && set1._items.Count > 0)
            {
                // т.к. список является ссылочным типом, 
                // то необходимо не просто передавать данные, а создавать их дубликаты.
                items.AddRange(new List<int>(set1._items));
            }

            // Если второе входное множество содержит элементы данных, 
            // то добавляем из в результирующее множество.
            if (set2._items != null && set2._items.Count > 0)
            {
                // т.к. список является ссылочным типом, 
                // то необходимо не просто передавать данные, а создавать их дубликаты.
                items.AddRange(new List<int>(set2._items));
            }

            // Удаляем все дубликаты из результирующего множества элементов данных.
            resultSet._items = items.Distinct().ToList();

            return resultSet;
        }

        public static Set Intersection(Set set1, Set set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            Set resultSet = new Set();

            // Выбираем множество содержащее наименьшее количество элементов.
            if (set1.Count < set2.Count)
            {
                // Первое множество меньше.
                // Проверяем все элементы выбранного множества.
                foreach (var item in set1._items)
                {
                    // Если элемент из первого множества содержится во втором множестве,
                    // то добавляем его в результирующее множество.
                    if (set2._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            else
            {
                // Второе множество меньше или множества равны.
                // Проверяем все элементы выбранного множества.
                foreach (var item in set2._items)
                {
                    // Если элемент из второго множества содержится в первом множестве,
                    // то добавляем его в результирующее множество.
                    if (set1._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }

            return resultSet;
        }

        public static Set Difference(Set set1, Set set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            Set resultSet = new Set();

            // Проходим по всем элементам первого множества.
            foreach (var item in set1._items)
            {
                // Если элемент из первого множества не содержится во втором множестве,
                // то добавляем его в результирующее множество.
                if (!set2._items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }

            // Проходим по всем элементам второго множества.
            foreach (var item in set2._items)
            {
                // Если элемент из второго множества не содержится в первом множестве,
                // то добавляем его в результирующее множество.
                if (!set1._items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }

            // Удаляем все дубликаты из результирующего множества элементов данных.
            resultSet._items = resultSet._items.Distinct().ToList();

            return resultSet;
        }

        public static bool Subset(Set set1, Set set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            // Перебираем элементы первого множества.
            // Если все элементы первого множества содержатся во втором,
            // то это подмножество. Возвращаем истину, иначе ложь.
            bool result = set1._items.All(s => set2._items.Contains(s));
            return result;
        }

        public static Set operator ++(Set set)
        {
            Random rnd = new Random();
            int item = rnd.Next();
            while (set._items.Contains(item))
            {
                item = rnd.Next();
            }

            set.Add(item);
            return set;
        }

        public static Set operator +(Set set1, Set set2)
        {
            return Set.Union(set1, set2);
        }

        public static bool operator ==(Set set1, Set set2)
        {
            return set1.Equals(set2);
        }
        public static bool operator !=(Set set1, Set set2)
        {
            return !(set1.Equals(set2));
        }

        public static int operator %(Set set, int index)
        {
            return set.GetItem(index);
        }

        public static implicit operator int(Set set)
        {
            return set.Count;
        }

        public class Production
        {
            public int ID { get; private set; }
            public string CompanyName { get; set; }
            
            public Production()
            {
                CompanyName = "Unknown";
                ID = CompanyName.GetHashCode();
            }
            public Production(string companyName)
            {
                CompanyName = companyName;
                ID = CompanyName.GetHashCode();
            }
        }
        public class Developer
        {
            public int ID { get; private set; }
            public string DeveloperName { get; private set; }
            public string Department { get; private set; }

            public Developer()
            {
                DeveloperName = "Unknown";
                Department = "Unknown";
                ID = DeveloperName.GetHashCode();
            }
            public Developer(string developerName, string department = "Unknown")
            {
                DeveloperName = developerName;
                Department = department;
                ID = DeveloperName.GetHashCode();
            }
        }
    }
}
