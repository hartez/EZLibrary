using Microsoft.Phone.Controls;

namespace EZLibrary.WindowsPhone.Interactivity
{
	public class DragStartedTrigger : GestureTrigger
	{
		protected override void Listen(GestureListener listener)
		{
			listener.DragStarted += ListenerDragStarted;
		}

		protected override void EndListen(GestureListener listener)
		{
			listener.DragStarted -= ListenerDragStarted;
		}

		private void ListenerDragStarted(object sender, DragStartedGestureEventArgs e)
		{
			Invoke(e);
		}
	}
}