using System;

namespace EZLibrary.WindowsPhone.Interactivity
{
    public class PinchCompletedTrigger : GestureTrigger
    {
        protected override void Listen(Microsoft.Phone.Controls.GestureListener listener)
        {
            listener.PinchCompleted += ListenerPinchCompleted;
        }

        protected override void EndListen(Microsoft.Phone.Controls.GestureListener listener)
        {
            listener.PinchCompleted -= ListenerPinchCompleted;
        }

        void ListenerPinchCompleted(object sender, Microsoft.Phone.Controls.PinchGestureEventArgs e)
        {
            Invoke(e);
        }
    }
}
