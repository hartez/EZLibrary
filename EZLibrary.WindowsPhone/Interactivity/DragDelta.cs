using Microsoft.Phone.Controls;

namespace EZLibrary.WindowsPhone.Interactivity
{
	public class DragDelta : GestureTrigger
	{
		protected override void Listen(GestureListener listener)
		{
			listener.DragDelta += ListenerDragDelta;
		}

		protected override void EndListen(GestureListener listener)
		{
			listener.DragDelta -= ListenerDragDelta;
		}

		private void ListenerDragDelta(object sender, DragDeltaGestureEventArgs e)
		{
			Invoke(e);
		}
	}
}