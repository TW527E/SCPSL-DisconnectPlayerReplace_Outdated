using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using Player = Exiled.API.Features.Player;

namespace SCPReplace
{
    public class EventHandler
    {
        public void OnPlayerLeft(LeftEventArgs ev)
        {
            if (ev.Player.Team == Team.SCP)
            {
                int count = Player.Get(Team.RIP).Count();
                if (count >= 0)
                {
                    var savedPos = ev.Player.Position;
                    var savedHealth = ev.Player.Health;
                    int cplayer = UnityEngine.Random.Range(0, count);
                    var spectators = Player.Get(Team.RIP).ToList();
                    var player = spectators[cplayer];
                    player.SetRole(ev.Player.Role, true, false);
                    player.Health = savedHealth;
                    Timing.CallDelayed(0.25f, () => player.Position = savedPos);
                    Map.Broadcast(duration: 15, message: $"{ SCPReplace.SCPReplaceRef.Config.OnScpReplace.Replace("%SCPRole%", ev.Player.Role.ToString()).Replace("Scp", "SCP - ")}");
                }
            }
        }
    }
}
