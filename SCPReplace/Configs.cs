using Exiled.API.Interfaces;

namespace SCPReplace
{
    public sealed class Configs : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [System.ComponentModel.Description("When Scp Replace Message")]
        public string OnScpReplace { get; set; } = "<color=red>{SCPRole}</color> <color=green> is Replaced</color>.";
    }
}
