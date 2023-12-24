using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;

namespace SpeedyPlayer
{
    [BepInPlugin("com.MasterOogway.speedyplayer", "Speedy Player", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin Speedy Player is loaded!");

            Harmony harmony = new Harmony("com.MasterOogway.speedyplayer");


            MethodInfo original = AccessTools.Method(typeof(PlayerPhysics), "Awake");
            MethodInfo patch = AccessTools.Method(typeof(myPatches), "Awake_SpeedyPlayer_Plug");
            harmony.Patch(original, new HarmonyMethod(patch));
        }

        public class myPatches
        {
            public static bool Awake_SpeedyPlayer_Plug(PlayerPhysics __instance)
            {
                __instance.Speed = (Fix)50f;
                __instance.airAccel = (Fix)30f;
                return true;
            }
        }
    }
}
