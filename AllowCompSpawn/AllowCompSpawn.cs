using HarmonyLib;
using NeosModLoader;
using FrooxEngine;

namespace AllowCompSpawn
{
    public class AllowCompSpawn : NeosMod
    {
        public override string Name => "AllowCompSpawn";
        public override string Author => "eia485";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/EIA485/NeosAllowCompSpawn/";
        
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.eia485.allowCompSpawn");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(ReferenceProxy), "ShouldBeProtected")]
        private class allowCompSpawnPatch
        {
            public static bool Prefix(ref bool __result)
            {
                __result = false;
                return false;
            }
        }
    }
}