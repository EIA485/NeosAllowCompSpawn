using BepInEx;
using BepInEx.NET.Common;
using BepInExResoniteShim;
using FrooxEngine;
using HarmonyLib;

namespace AllowCompSpawn
{
    [ResonitePlugin(PluginMetadata.GUID, PluginMetadata.NAME, PluginMetadata.VERSION, PluginMetadata.AUTHORS, PluginMetadata.REPOSITORY_URL)]
    [BepInDependency(BepInExResoniteShim.PluginMetadata.GUID)]
    public class AllowCompSpawn : BasePlugin
    {

        public override void Load() => HarmonyInstance.PatchAll();


        [HarmonyPatch(typeof(ReferenceProxy), nameof(ReferenceProxy.Construct))]
        private class allowCompSpawnPatch
        {
            public static void Prefix(ref bool downSpawnInstance)
            {
                downSpawnInstance = false;
            }
        }
    }
}