using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using MEC;
using Player = Exiled.API.Features.Player;
using PlayerEvent = Exiled.Events.Handlers.Player;
using System.Collections.Generic;
using Exiled.API.Features.Items;

namespace DisconnectPlayerReplace
{
    public class EventHandler
    {
        public readonly DisconnectPlayerReplace Plugin;
        public EventHandler(DisconnectPlayerReplace plugin) => this.Plugin = plugin;

        public void OnRoundStarted()
        {
            PlayerEvent.Left += OnPlayerLeft;
        }

        public void OnRoundEnded(RoundEndedEventArgs args)
        {
            PlayerEvent.Left -= OnPlayerLeft;
        }

        public void OnPlayerLeft(LeftEventArgs ev)
        {
            if (ev.Player.Team != Team.RIP)
            {
                if (ev.Player.Team == Team.TUT && DisconnectPlayerReplace.Instance.Config.CanTutorial == false)
                {
                    return;
                }
                else
                {
                    if (DisconnectPlayerReplace.Instance.Config.OnlyScp == false)
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
                var health = ply.Health;
                player.SetRole(ply.Role, SpawnReason.Respawn, false);
                Timing.CallDelayed(1.8f, () =>
                {
                    player.Health = health;
                    player.Position = ply.Position;
                    if (ply.Team != Team.SCP)
                    {
                        InvReplace(player, ply);
                    }
                });
                Map.Broadcast(duration: 15, message: $"{ DisconnectPlayerReplace.Instance.Config.OnPlayerReplace.Replace("%Role%", ply.Role.ToString()).Replace("Scp", "SCP - ")}");
                Cassie.Message(message: $"{ DisconnectPlayerReplace.Instance.Config.OnPlayerReplace.Replace("%Role%", ply.Role.ToString())}", false, DisconnectPlayerReplace.Instance.Config.IsNoisy);
            }
        }
        public List<Item> Items = new List<Item>();
        public void InvReplace(Player player, Player ply)
        {
            player.ClearInventory();
            var TargetItems = ply.Items;
            foreach (Item item in TargetItems)
                Items.Add(item);
            player.AddItem(Items);
        }
    }
}