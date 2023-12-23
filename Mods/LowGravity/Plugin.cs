using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;

namespace LowGravity
{
    [BepInPlugin("com.MasterOogway.lowgravity", "Low Gravity", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            Harmony harmony = new Harmony("com.MasterOogway.lowgravity");


            MethodInfo original = AccessTools.Method(typeof(PlayerPhysics), "Awake");
            MethodInfo patch = AccessTools.Method(typeof(myPatches), "Awake_LowGray_Plug");
            harmony.Patch(original, new HarmonyMethod(patch));
        }

        public class myPatches
        {
            public static bool Awake_LowGray_Plug(PlayerPhysics __instance)
            {
                __instance.gravity_modifier = (Fix)0.3f;
                return true;
            }
        }
    }
}
