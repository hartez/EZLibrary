using Microsoft.Phone.Controls;

namespace EZLibrary.WindowsPhone.Interactivity
{
	public class PinchStartedTrigger : GestureTrigger
	{
		protected override void Listen(GestureListener listener)
		{
			listener.PinchStarted += ListenerPinchStarted;
		}

		protected override void EndListen(GestureListener listener)
		{
			listener.PinchStarted -= ListenerPinchStarted;
		}

		private void ListenerPinchStarted(object sender, PinchStartedGestureEventArgs e)
		{
			Invoke(e);
		}
	}
}