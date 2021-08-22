using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using MEC;
using Player = Exiled.API.Features.Player;

namespace DisconnectPlayerReplace
{
    public class EventHandler
    {
        public void OnPlayerLeft(LeftEventArgs ev)
        {
            var savedPos = ev.Player.Position;
            var savedHealth = ev.Player.Health;
            if (DisconnectPlayerReplace.DisconnectPlayerReplaceRef.Config.OnlyScp == false)
            {
                ChangePlayer(ev.Player, savedHealth, savedPos);
            }
            else
            {
                if (ev.Player.Team == Team.SCP)
                {
                    ChangePlayer(ev.Player, savedHealth, savedPos);
                }
            }
        }

        public void ChangePlayer(Player pLayer, float savedHealth, UnityEngine.Vector3 savedPos)
        {
            var RIPPlayer = Player.Get(Team.RIP);
            int count = RIPPlayer.Count();
            if (count >= 1)
            {
                int cplayer = UnityEngine.Random.Range(0, count);
                var spectators = RIPPlayer.ToList();
                var player = spectators[cplayer];
                player.SetRole(pLayer.Role, SpawnReason.Respawn, false);
                player.Health = savedHealth;
                Timing.CallDelayed(0.25f, () => player.Position = savedPos);
                Map.Broadcast(duration: 15, message: $"{ DisconnectPlayerReplace.DisconnectPlayerReplaceRef.Config.OnPlayerReplace.Replace("%Role%", pLayer.Role.ToString()).Replace("Scp", "SCP - ")}");
                Cassie.Message(message: $"{ DisconnectPlayerReplace.DisconnectPlayerReplaceRef.Config.OnPlayerReplace.Replace("%Role%", pLayer.Role.ToString())}", false, DisconnectPlayerReplace.DisconnectPlayerReplaceRef.Config.IsNoisy);
            }
        }

    }
}
