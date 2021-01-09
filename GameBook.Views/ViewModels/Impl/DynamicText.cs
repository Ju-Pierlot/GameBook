using System;
using System.Collections.Generic;
using System.Threading;

namespace GameBook.Views.ViewModels.Impl
{
    public class DynamicText
    {
        public event DynamicTextEventHandler EventText;
        private Dictionary<Thread, ReferenceBool> _threads = new Dictionary<Thread, ReferenceBool>();

        public void Start(string text)
        {
            foreach (var bo in _threads.Values) { bo.Value = true; }
            _threads.Clear();
            ReferenceBool boolValue = new ReferenceBool(false);
            Thread thread = new Thread(() => Execute(text, boolValue));
            thread.Start();
            _threads.Add(thread, boolValue);
        }

        private void Execute(string text, ReferenceBool kill)
        {
            for (int i = 1; i < text.Length + 1; i++)
            {
                if (kill.Value) break;
                string sub = text.Substring(0, i);
                EventText?.Invoke(sub, null);
                Thread.Sleep(15);
            }
        }

    }

    public delegate void DynamicTextEventHandler(string text, EventHandler args);

    class ReferenceBool
    {
        public ReferenceBool(bool bo)
        {
            Value = bo;
        }
        public bool Value { get; set; }
    }
}
