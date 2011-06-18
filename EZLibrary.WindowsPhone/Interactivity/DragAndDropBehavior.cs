using System.Collections.Generic;
using System.Windows.Interactivity;
using EZLibrary.WindowsPhone.Interactivity;

namespace GestureTests.Interactivity
{
	public class DragAndDropBehavior : GestureBehavior
	{
		private readonly List<GestureTrigger> _triggers = new List<GestureTrigger>();

		protected override void OnAttached()
		{
			TriggerCollection triggers = Interaction.GetTriggers(AssociatedObject);
			foreach (GestureTrigger t in _triggers)
				triggers.Add(t);

			base.OnAttached();
		}

		protected override void OnDetaching()
		{
			TriggerCollection triggers = Interaction.GetTriggers(AssociatedObject);

			foreach (GestureTrigger t in _triggers)
				triggers.Remove(t);

			base.OnDetaching();
		}
	}
}