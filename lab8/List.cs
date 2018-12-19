using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class List : ArrayList
    {
        ArrayList data = new ArrayList();

        //delegate - handler
        public delegate void listHandler(object List, ListEventArgs listArgs);
        //published event
        public event listHandler listChanged;
        //method fireing event
        protected void OnListChange(ListEventArgs lArgs)
        {
            if(listChanged != null)
            {
                listChanged(this, lArgs);
            }
        }


        public override int Add(object o)
        {
            DateTime date = DateTime.Now;
            ArrayList added = new ArrayList(1);
            added.Add(o);
            ListEventArgs lArgs = new ListEventArgs(added, date);
            OnListChange(lArgs);
            data.Add(o);
            return base.Add(o);
        }

        public override void Clear()
        {
            DateTime date = DateTime.Now;
            ListEventArgs lArgs = new ListEventArgs(this.data, date);
            OnListChange(lArgs);
            data.Clear();
            base.Clear();
        }

        public override object this[int index]
        {
            get
            {
                return data[index];
            }

            set
            {
                ArrayList modif = new ArrayList(2);
                modif.Add(data[index]);
                modif.Add(value);
                DateTime date = DateTime.Now;
                ListEventArgs lArgs = new ListEventArgs(modif, date);
                OnListChange(lArgs);
                data[index] = value;
                base[index] = value;
            }

        }


    }
}
