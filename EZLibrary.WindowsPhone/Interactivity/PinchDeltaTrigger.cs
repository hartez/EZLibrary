using Microsoft.Phone.Controls;

namespace EZLibrary.WindowsPhone.Interactivity
{
	public class PinchDeltaTrigger : GestureTrigger
	{
		protected override void Listen(GestureListener listener)
		{
			listener.PinchDelta += ListenerPinchDelta;
		}

		protected override void EndListen(GestureListener listener)
		{
			listener.PinchDelta -= ListenerPinchDelta;
		}

		private void ListenerPinchDelta(object sender, PinchGestureEventArgs e)
		{
			Invoke(e);
		}
	}
}