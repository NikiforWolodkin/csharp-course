using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Lab_8
{
    public class UpgradeEventArgs : EventArgs
    {
        public UpgradeEventArgs(int amount) => Amount = amount;

        public int Amount { get; set; }
    }

    class Boss
    {
        public event EventHandler<EventArgs> RaiseTurnOnEvent;
        public event EventHandler<UpgradeEventArgs> RaiseUpgradeEvent;

        public void TurnOn() => OnRaiseTurnOnEvent(new EventArgs());
        public void Upgrade(int amount) => OnRaiseUpgradeEvent(new UpgradeEventArgs(amount));

        protected virtual void OnRaiseTurnOnEvent(EventArgs e)
        {
            EventHandler<EventArgs> raiseEvent = RaiseTurnOnEvent;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }

        protected virtual void OnRaiseUpgradeEvent(UpgradeEventArgs e)
        {
            EventHandler<UpgradeEventArgs> raiseEvent = RaiseUpgradeEvent;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
    }

    class Technic
    {
        public string Name;
        public int Revenue;
        private bool _status;
        private int _stress;
        private readonly double _stressResistance;

        public Technic(string name, double stressResistance)
        {
            _status = false;
            _stress = 0;
            Name = name;
            _stressResistance = stressResistance;
        }

        public void Subscribe(Boss publisher)
        {
            publisher.RaiseTurnOnEvent += HandleTurnOnEvent;
            publisher.RaiseUpgradeEvent += HandleUpgradeEvent;
        }

        void HandleTurnOnEvent(object sender, EventArgs e)
        {
            if (_status == true)
            {
                return;
            }

            _status = true;
            Console.WriteLine($"{Name}: получено событие TurnOn");
        }

        void HandleUpgradeEvent(object sender, UpgradeEventArgs e)
        {
            if (_status != true)
            {
                return;
            }

            if (_stress < 100)
            {
                _stress += (int)((double)e.Amount * _stressResistance);
                Revenue += e.Amount;
                Console.WriteLine($"{Name}: получено событие Upgrade: {e.Amount}; стресс: {_stress}%, прибыль: {Revenue}");
                return;
            }

            Console.WriteLine($"{Name}: получено событие Upgrade: {e.Amount}; стресс: более 100%! прибыль: {Revenue}");
        }
    }

    static class StringFunctions
    {
        public static Func<string, string> ToUpperCase = str => str.ToUpper();
        public static Func<string, string> ToLowerCase = str => str.ToLower();
        public static Func<string, string> ReplaceSpaces = str => str.Replace(' ', '_');
        public static Func<string, string> RemoveCommas = str => str.Replace(",", "");
        public static Func<string, string> AddDot = str => str + ".";

        public static string ApplyFunctions(this string str, Func<string, string> function1, Func<string, string>  function2)
        {
            string strUpdated = function1(str);
            return function2(strUpdated);
        }

        public static string ApplyFunctions(this string str, Func<string, string> function1, Func<string, string> function2, Func<string, string> function3)
        {
            string strUpdated = function1(str);
            strUpdated = function2(strUpdated);
            return function3(strUpdated);
        }

        public static string ApplyFunctions(
            this string str,
            Func<string, string> function1,
            Func<string, string> function2,
            Func<string, string> function3,
            Func<string, string> function4
        )
        {
            string strUpdated = function1(str);
            strUpdated = function2(strUpdated);
            strUpdated = function3(strUpdated);
            return function4(strUpdated);
        }

        public static string ApplyFunctions(
            this string str,
            Func<string, string> function1,
            Func<string, string> function2,
            Func<string, string> function3,
            Func<string, string> function4,
            Func<string, string> function5
        )
        {
            string strUpdated = function1(str);
            strUpdated = function2(strUpdated);
            strUpdated = function3(strUpdated);
            strUpdated = function4(strUpdated);
            return function5(strUpdated);
        }
    }
}
