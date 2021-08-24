using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using MEC;
using Player = Exiled.API.Features.Player;
using PlayerEvent = Exiled.Events.Handlers.Player;

namespace DisconnectPlayerReplace
{
    public class EventHandler
    {
        private EventHandler eventHandlers;

        public void OnRoundStarted()
        {
            eventHandlers = new EventHandler();
            PlayerEvent.Left += eventHandlers.OnPlayerLeft;
        }

        public void OnRoundEnded(RoundEndedEventArgs args)
        {
            var meow = args;
            PlayerEvent.Left -= eventHandlers.OnPlayerLeft;
        }

        public void OnPlayerLeft(LeftEventArgs ev)
        {
            if (ev.Player.Team != Team.RIP)
            {
                if (ev.Player.Team == Team.TUT && DisconnectPlayerReplace.DisconnectPlayerReplaceRef.Config.CanTutorial == false)
                {
                    return;
                }
                else
                {
                    if (DisconnectPlayerReplace.DisconnectPlayerReplaceRef.Config.OnlyScp == false)
                    {
                        ChangePlayer(ev.Player);
                    }
                    else
                    {
                        if (ev.Player.Team == Team.SCP)
                        {
                            ChangePlayer(ev.Player);
                        }
                    }
                }
            }
        }

        public void ChangePlayer(Player ply)
        {
            var RIPPlayer = Player.Get(Team.RIP);
            int count = RIPPlayer.Count();
            if (count >= 1)
            {
                int cplayer = UnityEngine.Random.Range(0, count);
                var spectators = RIPPlayer.ToList();
                var player = spectators[cplayer];
                player.SetRole(ply.Role, SpawnReason.Respawn, false);
                player.Health = ply.Health;
                Timing.CallDelayed(1f, () => player.Position = ply.Position);
                Map.Broadcast(duration: 15, message: $"{ DisconnectPlayerReplace.DisconnectPlayerReplaceRef.Config.OnPlayerReplace.Replace("%Role%", ply.Role.ToString()).Replace("Scp", "SCP - ")}");
                Cassie.Message(message: $"{ DisconnectPlayerReplace.DisconnectPlayerReplaceRef.Config.OnPlayerReplace.Replace("%Role%", ply.Role.ToString())}", false, DisconnectPlayerReplace.DisconnectPlayerReplaceRef.Config.IsNoisy);
            }
        }
    }
}
