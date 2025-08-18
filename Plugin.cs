using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using ShortcutCeo.config;
using System;
using System.Collections.Generic;

namespace ShortcutCeo;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    internal static ConfigFile ConfigReference { get; private set; }

    private Dictionary<ConfigEntry<KeyboardShortcut>, Action> shortcutDictionary = new Dictionary<ConfigEntry<KeyboardShortcut>, Action>();

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
        if (!SaveLoadGameDataController.loadComplete) 
        { 
            return;   
        }

        foreach (var kvp in ConfigManager.GetShortcuts())
        {
            if (kvp.Key.Value.IsPressed())
            {
                kvp.Value.Invoke();
            }
        }


    }
}
