using Microsoft.Phone.Controls;

namespace EZLibrary.WindowsPhone.Interactivity
{
	public class DoubleTapTrigger : GestureTrigger
	{
		protected override void Listen(GestureListener listener)
		{
			listener.DoubleTap += ListenerDoubleTap;
		}

		protected override void EndListen(GestureListener listener)
		{
			listener.DoubleTap -= ListenerDoubleTap;
		}

		private void ListenerDoubleTap(object sender, GestureEventArgs e)
		{
			Invoke(e);
		}
	}
}