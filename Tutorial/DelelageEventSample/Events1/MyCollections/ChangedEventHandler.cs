using System;

namespace Events1.MyCollections
{
    // A delegate type for hooking up change notifications.
    public delegate void ChangedEventHandler(object sender, EventArgs e);
}