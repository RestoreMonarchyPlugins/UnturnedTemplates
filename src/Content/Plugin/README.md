# README
Delete this file after you have read it.

## Table of contents
- [Setting up the Project](#setting-up-the-project)
- [Building the Project](#building-the-project)
- [Testing the Plugin](#testing-the-plugin)

## Setting up the Project
1. Create a `lib` folder in the root directory of your solution.

2. Copy the following Unturned and Unity libraries from `/Unturned_Data/Managed` to the `lib` folder you created:
    - `Assembly-CSharp.dll`
    - `com.rlabrecque.steamworks.net.dll`
    - `Newtonsoft.Json.dll`
    - `SDG.NetTransport.dll`
    - `UnityEngine.dll`
    - `UnityEngine.CoreModule.dll`
    - `UnityEngine.PhysicsModule.dll` (required for physics and raycasting)

3. Copy all `.dll` files from `/Extras/Rocket.Unturned` into the `lib` folder.
    - `Rocket.API.dll`
    - `Rocket.Core.dll`
    - `Rocket.Unturned.dll`

4. Once you add files to the `lib` directory in your solution, they should be referenced by the project automatically.

5. Update `SampleConfiguration.cs` to implement `IRocketPluginConfiguration`.

```cs
using Rocket.API;

namespace Author.Sample
{
    public class SampleConfiguration : IRocketPluginConfiguration
    {
        public void LoadDefaults() 
        {
            // Load configuration default values here
        }
    }
}
```

6. Update `SamplePlugin.cs` to implement `RocketPlugin` with `SampleConfiguration`.

```cs
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
```

## Building the Project
1. Use `Ctrl + Shift + B` to build the project or `Build` -> `Build Solution`.
2. Copy `Sample.dll` from `bin/Debug/net48` to the `Rocket/Plugins` folder in your server directory.

## Testing the Plugin
To test the plugin, start the server and check the console for the plugin loading message.
```
[loading] Sample
[05/16/2024 06:30:26] [Info] Sample >> Sample 1.0.0 has been loaded!
```