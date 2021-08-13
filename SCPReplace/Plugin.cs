using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace SCPReplace
{
	public class SCPReplace : Plugin<Configs>
	{
		public static SCPReplace SCPReplaceRef;
		public override string Prefix => "SCPReplace";

		private EventHandler eventHandlers;

		public override void OnEnabled()
		{
			SCPReplaceRef = this;
			eventHandlers = new EventHandler();

			Player.Left += eventHandlers.OnPlayerLeft;

			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			Player.Left -= eventHandlers.OnPlayerLeft;
			eventHandlers = null;
			SCPReplaceRef = null;
			base.OnDisabled();
		}
	}
}
