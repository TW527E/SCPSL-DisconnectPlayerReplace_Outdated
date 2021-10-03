using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DisconnectPlayerReplace
{
    public sealed class Configs : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool OnlyScp { get; set; } = false;
        public bool CanTutorial { get; set; } = false;
        [Description("Only those who are replaced perform broadcasting")]
        public bool Onlyreplacedbroadcast { get; set; } = false;
        [Description("Cassie")]
        public bool IsNoisy { get; set; } = true;
        [Description("You can find all words at here : https://steamcommunity.com/sharedfiles/filedetails/?id=1577299753")]
        public string CassieMessage { get; set; } = "Some 1 is leave";
        [Description("When Player Replace Message")]
        public string OnPlayerReplace { get; set; } = "<color=red>%Role%</color> <color=green> is been Replaced</color>.";
    }
}
