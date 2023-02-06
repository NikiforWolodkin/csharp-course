using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_9
{
    public class SoftwareCollection<T> : IList<T> where T : Software
    {
        private List<T> _items;

        int ICollection<T>.Count => _items.Count;
        bool ICollection<T>.IsReadOnly => false;

        public SoftwareCollection() => _items = new List<T>();

        public SoftwareCollection(params Software[] software)
        {
            _items = new List<T>();

            foreach (var item in software)
            {
                _items.Add((T)item);
            }
        }

        public void Print()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item.Name);
                if (item.Description != null)
                {
                    Console.WriteLine(item.Description);
                }
                if (item.License != null)
                {
                    Console.WriteLine(item.License);
                }
            }
        }

        void ICollection<T>.Add(T item)
        {
            _items.Add(item);
        }

        void ICollection<T>.Clear() => _items.Clear();

        bool ICollection<T>.Contains(T item) => _items.Contains(item);

        void ICollection<T>.CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

        bool ICollection<T>.Remove(T item) => _items.Remove(item);

        int IList<T>.IndexOf(T item) => _items.IndexOf(item);

        T IList<T>.this[int index]
        {
            get => (T)_items[index];
            set => _items[index] = value;
        }

        void IList<T>.Insert(int index, T item) => _items.Insert(index, item);

        void IList<T>.RemoveAt(int index) => _items.RemoveAt(index);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
    }

    public class Software
    {
        public string Name;
        public string License;
        public string Description;

        public Software(string name, string license = null, string description = null)
        {
            Name = name;
            License = license;
            Description = description;
        }
    }

    public class ObservableCollectionContainer
    {
        public ObservableCollection<Software> Items;

        public ObservableCollectionContainer()
        {
            Items = new ObservableCollection<Software>();
            Items.CollectionChanged += HandleCollectionChange;
        }

        public ObservableCollectionContainer(params Software[] software)
        {
            Items = new ObservableCollection<Software>();

            foreach (var item in software)
            {
                Items.Add(item);
            }

            Items.CollectionChanged += HandleCollectionChange;
        }

        public void Remove(int index) => Items.RemoveAt(index);

        public void Insert(int index, Software item) => Items.Insert(index, item);

        public void HandleCollectionChange(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: 
                    Console.WriteLine("Добавлен элемент");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Удален элемент");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Заменен элемент");
                    break;
            }
        }
    }
}
