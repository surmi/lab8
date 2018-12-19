using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class ListEventArgs: EventArgs
    {
        public readonly ArrayList changedList;
        public readonly DateTime date;
        public ListEventArgs(ArrayList changedList, DateTime date)
        {
            this.changedList = changedList;
            this.date = date;
        }
    }
}
