using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Core
{
    public interface IHistory
    {
        void Save();
        void Restore(Memento memento);
    }
}
