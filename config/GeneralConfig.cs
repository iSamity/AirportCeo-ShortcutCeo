using BepInEx.Configuration;
using UnityEngine;

namespace ShortcutCeo.Config;

internal static class GeneralConfig
{
    internal static ConfigEntry<KeyCode> CopyKey { get; private set; }

    internal static void SetupConfig()
    {
        CopyKey = ConfigReference.Bind("General", "Keyboard shortcut to copy entity below cursor", KeyCode.C, "Default in game is control + c");
    }

    static ConfigFile ConfigReference => ShortcutCeo.Plugin.ConfigReference;
}
