using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using ShortcutCeo.config;
using ShortcutCeo.Config;
using UnityEngine;

namespace ShortcutCeo;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class ShortcutCeoPlugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    internal static ConfigFile ConfigReference { get; private set; }

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;

        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loading!");

        ConfigReference = Config;

        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is setting up config.");

        ConfigManager.Setup();

        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} finished setting up config.");

        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is done!");
    }

    void Update()
    {
        if (SaveLoadGameDataController.loadComplete && Input.GetKeyDown(GeneralConfig.CopyKey.Value))
        {
            Singleton<SelectionController>.Instance.CopyHoveredBuilding();
        }
    }
}
