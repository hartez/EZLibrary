using System;

namespace EZLibrary.WindowsPhone.Interactivity
{
    public class DragCompletedTrigger : GestureTrigger
    {
        protected override void Listen(Microsoft.Phone.Controls.GestureListener listener)
        {
            listener.DragCompleted += ListenerDragCompleted;
        }

        protected override void EndListen(Microsoft.Phone.Controls.GestureListener listener)
        {
            listener.DragCompleted -= ListenerDragCompleted;
        }

        void ListenerDragCompleted(object sender, Microsoft.Phone.Controls.DragCompletedGestureEventArgs e)
        {
            Invoke(e);
        }
    }
}
