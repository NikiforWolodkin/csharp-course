using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_4.Core
{
    public class Caretaker
    {
        private List<Memento> _undoStack;
        private List<Memento> _redoStack;
        
        public Caretaker()
        {
            _undoStack = new List<Memento>();
            _redoStack = new List<Memento>();
        }

        public void ClearStacks()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }

        public void Backup(Memento memento)
        {
            _undoStack.Add(memento);

            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count <= 1)
            {
                return;
            }

            if (_undoStack.Count > 256)
            {
                _undoStack.RemoveAt(0);
            }

            var currentMemento = _undoStack.Last();

            _redoStack.Add(currentMemento);

            _undoStack.RemoveAt(_undoStack.Count - 1);

            var memento = _undoStack.Last();

            memento.Originator.Restore(memento);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0)
            {
                return;
            }

            if (_redoStack.Count > 256)
            {
                _redoStack.RemoveAt(0);
            }

            var memento = _redoStack.Last();

            memento.Originator.Restore(memento);

            _undoStack.Add(memento);

            _redoStack.RemoveAt(_redoStack.Count - 1);
        }
    }
}
