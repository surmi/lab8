using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lab8
{
    class ListListenerSaveToFile
    {
        private FileStream fileStream;
        private StreamWriter streamWriter;
        public ListListenerSaveToFile(string filename)
        {
            fileStream = new FileStream(filename, FileMode.Create);
            streamWriter = new StreamWriter(fileStream);
        }
        public void Resign(List l)
        {
            l.listChanged -= new List.listHandler(writeToFileChanges);
        }
        public void Subscribe(List l)
        {
            l.listChanged += new List.listHandler(writeToFileChanges);
        }

        public void writeToFileChanges(object list, ListEventArgs args)
        {
            streamWriter.WriteLine("This is called when the event fires");
            streamWriter.WriteLine("Event fires at: " + args.date.ToString());
            streamWriter.WriteLine("Changed elements are:");

            for (int i = 0; i < args.changedList.Count; ++i)
            {
                streamWriter.WriteLine(args.changedList[i]);
            }
            streamWriter.WriteLine("------------------------------");
        }
        public void Close()
        {
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
