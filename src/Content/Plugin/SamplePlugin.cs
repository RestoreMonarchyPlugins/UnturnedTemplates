using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace Author.Sample
{
    public class SamplePlugin : RocketPlugin<SampleConfiguration>
    {
        protected override void Load()
        {
            Logger.Log($"{Name} {Assembly.GetName().Version.ToString(3)} has been loaded!");
        }

        protected override void Unload()
        {
            Logger.Log($"{Name} has been unloaded!");
        }
    }
}