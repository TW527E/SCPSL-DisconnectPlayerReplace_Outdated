using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace DisconnectPlayerReplace
{
	public class DisconnectPlayerReplace : Plugin<Configs>
	{
		public static DisconnectPlayerReplace DisconnectPlayerReplaceRef;
		public override string Prefix => "SCPReplace";

		private EventHandler eventHandlers;

		public override void OnEnabled()
		{
			DisconnectPlayerReplaceRef = this;
			eventHandlers = new EventHandler();

			Player.Left += eventHandlers.OnPlayerLeft;

			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			Player.Left -= eventHandlers.OnPlayerLeft;
			eventHandlers = null;
			DisconnectPlayerReplaceRef = null;
			base.OnDisabled();
		}
	}
}
