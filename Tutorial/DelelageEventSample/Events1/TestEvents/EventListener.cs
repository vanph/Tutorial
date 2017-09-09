using System;
using Events1.MyCollections;

namespace Events1.TestEvents
{
    public class EventListener
    {
        private ListWithChangedEvent _list;

        public EventListener(ListWithChangedEvent list)
        {
            _list = list;
            // Add "ListChanged" to the Changed event on "List".
            _list.Changed += new ChangedEventHandler(ListChanged);
        }

        // This will be called whenever the list changes.
        private void ListChanged(object sender, EventArgs e)
        {
            Console.WriteLine("This is called when the event fires.");
        }

        public void Detach()
        {
            // Detach the event and delete the list
            _list.Changed -= new ChangedEventHandler(ListChanged);
            _list = null;
        }
    }
}