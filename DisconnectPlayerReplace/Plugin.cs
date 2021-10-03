using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;

namespace DisconnectPlayerReplace
{
	public class DisconnectPlayerReplace : Plugin<Configs>
	{
		public override string Prefix => "DisconnectPlayerReplace";
		public static DisconnectPlayerReplace Instance;

		private EventHandler eventHandlers;

		public override void OnEnabled()
		{
			Instance = this;
			eventHandlers = new EventHandler(this);

            Server.RoundStarted += eventHandlers.OnRoundStarted;
            Server.RoundEnded += eventHandlers.OnRoundEnded;

			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			Server.RoundStarted -= eventHandlers.OnRoundStarted;
			Server.RoundEnded -= eventHandlers.OnRoundEnded;
			eventHandlers = null;
		}
	}
}
