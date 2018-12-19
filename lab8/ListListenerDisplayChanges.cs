using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class ListListenerDisplayChanges
    {
        public void Subscribe(List l)
        {
            l.listChanged += new List.listHandler(displayChanges);
        }

        public void Resign(List l)
        {
            l.listChanged -= new List.listHandler(displayChanges);
        }

        public void displayChanges(object list, ListEventArgs args)
        {
            Console.WriteLine("This is called when the event fires");
            Console.WriteLine("Event fires at: " + args.date.ToString());
            Console.WriteLine("Changed elements are:");

            for(int i=0; i<args.changedList.Count; ++i)
            {
                Console.WriteLine(args.changedList[i]);
            }
            Console.WriteLine("------------------------------");
        }

        void GetTimes(out int h, out int m, out int s, DateTime date)
        {
            h = date.Hour;
            m = date.Minute;
            s = date.Second;
        }
    }
}
