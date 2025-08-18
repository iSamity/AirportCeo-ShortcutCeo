using AirportCEOModLoader.Core;
using BepInEx.Configuration;
using ShortcutCeo.Config;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShortcutCeo.config;

public class ConfigManager
{
    private static Dictionary<ConfigEntry<KeyboardShortcut>, Action> shortcutDictionary = new();

    internal static void Setup()
    {
        DefaultConfig.SetupConfig();
    }


    public static void AddShortcut(ConfigEntry<KeyboardShortcut> shortcut, Action action)
    {
        var existingShortcut = GetShortcutConfig(shortcut.Value);
        if (existingShortcut != null)
        {
            DialogUtils.QueueDialog($"Shortcut {existingShortcut.Value} already exists for: {existingShortcut.Definition.Key}");
            return;
        }

        shortcutDictionary.Add(shortcut, action);
        Plugin.Logger.LogInfo($"Shortcut {shortcut.Value} is added.");
    }

    public static void RemoveShortcut(ConfigEntry<KeyboardShortcut> shortcut)
    {
        if (GetShortcutConfig(shortcut.Value) == null)
        {
            Plugin.Logger.LogInfo($"Shortcut {shortcut.Value} does not exist.");
            return;
        }

        shortcutDictionary.Remove(shortcut);
        Plugin.Logger.LogInfo($"Shortcut {shortcut.Value} is removed.");
    }

    private static ConfigEntry<KeyboardShortcut> GetShortcutConfig(KeyboardShortcut shortcut)
    {
        foreach (var kvp in shortcutDictionary)
        {
            if (kvp.Key.Value.Equals(shortcut))
            {
                return kvp.Key;
            }
        }
        return null;
    }

    internal static IEnumerable<KeyValuePair<ConfigEntry<KeyboardShortcut>, Action>> GetShortcuts()
    {
        return shortcutDictionary;
    }
}
