using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace DisconnectPlayerReplace
{
	public class DisconnectPlayerReplace : Plugin<Configs>
	{
		public static DisconnectPlayerReplace DisconnectPlayerReplaceRef;
		public override string Prefix => "DisconnectPlayerReplace";

		private EventHandler eventHandlers;

		public override void OnEnabled()
		{
			DisconnectPlayerReplaceRef = this;
			eventHandlers = new EventHandler();

            Server.RoundStarted += eventHandlers.OnRoundStarted;
            Server.RoundEnded += eventHandlers.OnRoundEnded;

			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			Server.RoundStarted -= eventHandlers.OnRoundStarted;
			Server.RoundEnded -= eventHandlers.OnRoundEnded;
			eventHandlers = null;
			DisconnectPlayerReplaceRef = null;
			base.OnDisabled();
		}
	}
}
