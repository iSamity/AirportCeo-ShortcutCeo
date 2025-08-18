using BepInEx.Configuration;
using ShortcutCeo.config;
using UnityEngine;

namespace ShortcutCeo.Config;

internal static class DefaultConfig
{
    internal static void SetupConfig()
    {
       var copyKey = ConfigReference.Bind("General", "Copy entity below cursor", new KeyboardShortcut(KeyCode.C, KeyCode.LeftControl), "Default in game is control + c");

        ConfigManager.AddShortcut(copyKey, () =>
        {
            Singleton<SelectionController>.Instance.CopyHoveredBuilding();
        });
    }

    static ConfigFile ConfigReference => ShortcutCeo.Plugin.ConfigReference;
}
