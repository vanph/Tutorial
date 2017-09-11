using System;
using Events2.MyCollections;
using Events2.TestEvents;

namespace Events2
{
    public class Program
    {
        public static void Main()
        {
            // Create a new list:
            ListWithChangedEvent list = new ListWithChangedEvent();

            // Create a class that listens to the list's change event:
            EventListener listener = new EventListener(list);

            // Add and remove items from the list:
            list.Add("item 1");
            list.Clear();
            listener.Detach();

            Console.ReadLine();
        }
    }
}

