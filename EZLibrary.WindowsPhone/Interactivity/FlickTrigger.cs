using Microsoft.Phone.Controls;

namespace EZLibrary.WindowsPhone.Interactivity
{
	public class FlickTrigger : GestureTrigger
	{
		protected override void Listen(GestureListener listener)
		{
			listener.Flick += ListenerFlick;
		}

		protected override void EndListen(GestureListener listener)
		{
			listener.Flick -= ListenerFlick;
		}

		private void ListenerFlick(object sender, FlickGestureEventArgs e)
		{
			Invoke(e);
		}
	}
}