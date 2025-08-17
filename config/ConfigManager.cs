using BepInEx.Configuration;
using ShortcutCeo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCeo.config;

public class ConfigManager
{
    internal static void Setup()
    {
        GeneralConfig.SetupConfig();
    }
}
