using Medallion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab_7
{
    public interface IShuffle<T>
    {
        T[] Shuffle();
    }

    public class Set<T> : IShuffle<T> where T : struct
    {
        private List<T> _items;
        public int Count => _items.Count;

        public Set()
        {
            _items = new List<T>();
        }
        public Set(params T[] items)
        {
            _items = new List<T>(items);
        }

        public override int GetHashCode()
        {
            return string.Join("", _items.ToArray()).GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Set<T> set)
            {
                return string.Join("", _items.ToArray()).GetHashCode() == set.GetHashCode();
            }

            return false;
        }

        public void Add(T item)
        {
            try
            {
                if (_items.Contains(item))
                {
                    throw new Exception($"Элемент {item} уже существует в множестве.");
                }
                _items.Add(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Print();
            }
        }

        public void Remove(T item)
        {
            try
            {
                if (!_items.Contains(item))
                {
                    throw new KeyNotFoundException($"Элемент {item} не найден в множестве.");
                }
                _items.Remove(item);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Print();
            }
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Элемент по индексу {index} не найден в множестве.");
            }

            return _items[index];
        }

        public T[] ToArray()
        {
            return _items.ToArray();
        }

        public T[] Shuffle()
        {
            var items = this.ToArray();
            items.Shuffle();
            return items;
        }

        public void Print()
        {
            if (_items == null)
            {
                Console.WriteLine("Пустое множество");
                return;
            }
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }

        public static void SerializeJSON(Set<T> set, string path)
        {
            string json = JsonSerializer.Serialize(set._items);
            File.WriteAllText(path, json);
        }

        public static Set<T> ReadFromJSON(string path)
        {
            string json = File.ReadAllText(path);
            T[] items = JsonSerializer.Deserialize<T[]>(json);
            Set<T> set = new Set<T>(items);
            return set;
        }

        public static Set<T> Union(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            Set<T> resultSet = new Set<T>();

            List<T> items = new List<T>();

            if (set1._items != null && set1._items.Count > 0)
            {
                // т.к. список является ссылочным типом, 
                // то необходимо не просто передавать данные, а создавать их дубликаты.
                items.AddRange(new List<T>(set1._items));
            }

            // Если второе входное множество содержит элементы данных, 
            // то добавляем из в результирующее множество.
            if (set2._items != null && set2._items.Count > 0)
            {
                // т.к. список является ссылочным типом, 
                // то необходимо не просто передавать данные, а создавать их дубликаты.
                items.AddRange(new List<T>(set2._items));
            }

            // Удаляем все дубликаты из результирующего множества элементов данных.
            resultSet._items = items.Distinct().ToList();

            return resultSet;
        }

        public static Set<T> Intersection(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            Set<T> resultSet = new Set<T>();

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

        public static Set<T> Difference(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            Set<T> resultSet = new Set<T>();

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

        public static bool Subset(Set<T> set1, Set<T> set2)
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

        public static Set<T> operator +(Set<T> set1, Set<T> set2)
        {
            return Set<T>.Union(set1, set2);
        }

        public static bool operator ==(Set<T> set1, Set<T> set2)
        {
            return set1.Equals(set2);
        }
        public static bool operator !=(Set<T> set1, Set<T> set2)
        {
            return !(set1.Equals(set2));
        }

        public static T operator %(Set<T> set, int index)
        {
            return set.GetItem(index);
        }

        public static implicit operator int(Set<T> set)
        {
            return set.Count;
        }
    }
}
