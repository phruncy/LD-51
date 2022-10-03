
namespace LD51
{
    public abstract class NodeSlotMenuOption : MenuOption
	{
		private NodeSlot _slot;

		public void Setup(NodeSlot slot)
		{
			_slot = slot;
		}

		protected override void DoOnClick()
		{
			if (_slot == null)
				return;
			DoClickAction(_slot);
		}

		protected abstract void DoClickAction(NodeSlot slot);
	}
}
