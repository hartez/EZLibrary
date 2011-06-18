using Microsoft.Phone.Controls;

namespace EZLibrary.WindowsPhone.Interactivity
{
	public class HoldTrigger : GestureTrigger
	{
		protected override void Listen(GestureListener listener)
		{
			listener.Hold += ListenerHold;
		}

		protected override void EndListen(GestureListener listener)
		{
			listener.Hold -= ListenerHold;
		}

		private void ListenerHold(object sender, GestureEventArgs e)
		{
			Invoke(e);
		}
	}
}