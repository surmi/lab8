using System;
using System.Threading;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            List testList = new List();
            ListListenerDisplayChanges display = new ListListenerDisplayChanges();
            ListListenerSaveToFile save = new ListListenerSaveToFile("list.txt");

            display.Subscribe(testList);
            save.Subscribe(testList);

            testList.Add("abc");
            testList.Add(1);
            testList.Add("kjjhadskf");

            Console.WriteLine(testList.Count);

            testList[1] = 10;

            Thread.Sleep(1000);

            testList.Clear();

            display.Resign(testList);
            save.Resign(testList);

            testList.Add("added after resign");

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}
