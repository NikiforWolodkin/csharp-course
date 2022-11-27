using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    public class Supply
    {
        public string Name { get; set; }

        public Supply(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Supplier
    {
        public int ProductionSpeed { get; set; }
        public string SupplyName { get; set; }

        public Supplier(int productionSpeed, string supply, Warehouse warehouse)
        {
            ProductionSpeed = productionSpeed;
            SupplyName = supply;

            StartProduction(warehouse);
        }

        public void StartProduction(Warehouse warehouse)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(ProductionSpeed);

                    warehouse.Add(new Supply(SupplyName));
                }
            });
        }
    }

    public class Consumer
    { 
        public int WaitTime { get; set; }

        public Consumer(int waitTime, Warehouse warehouse)
        {
            WaitTime = waitTime;

            Buy(warehouse);
        }

        private void Buy(Warehouse warehouse)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(WaitTime);

                    if (!warehouse.TakeItem())
                    {
                        Thread.Sleep(WaitTime);

                        if (!warehouse.TakeItem())
                        {
                            Console.WriteLine("Покупатель ушел!");
                            return;
                        }    
                    }
                }
            });
        }
    }

    public class Warehouse
    {
        private BlockingCollection<Supply> _inventory;

        public Warehouse()
        {
            _inventory = new BlockingCollection<Supply>();
        }

        public void Add(Supply supply)
        {
            _inventory.TryAdd(supply);

            Print();
        }

        public bool TakeItem()
        {
            Supply item;
            
            return _inventory.TryTake(out item);
        }

        public void Print()
        {
            Console.WriteLine("Инвентарь:");
            foreach (var item in _inventory)
            {
                Console.WriteLine(item);
            }
        }
    }
}
