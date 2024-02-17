using Pineapler.Utils;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace OrcSkip;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin {
    // ==========================================================
    // GAME CONFIGURATION
    public const string PluginGuid = "com.pineapler.orcskip";
    public const string PluginName = "OrcSkip";
    public const string PluginVersion = "0.0.1";
    // ==========================================================

    public static new Config Config { get; private set; }
    
    private void Awake() {
        Config = new Config(base.Config);
        
        Log.SetSource(Logger);
        Log.Info($"Plugin {PluginGuid} is starting");
        
        // TODO: Use a Harmony patch to create an EntryPoint gameObject at the correct time.
        // See Patches/EntryPointPatch.cs for an example that creates an entry point after GameManager.Start()

        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
    }
}
