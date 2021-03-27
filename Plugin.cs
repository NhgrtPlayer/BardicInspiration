using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Bardic_Inspiration
{
    [BepInDependency(ValheimLib.ValheimLib.ModGuid)]
    [BepInPlugin("srf.bardicinspiration", Plugin.ModName, Plugin.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public const string Version = "1.0";
        public const string ModName = "Bardic Inspiration";
        Harmony _Harmony;
        public static ManualLogSource Log;

        private void Awake()
        {
#if DEBUG
			Log = Logger;
#else
            Log = new ManualLogSource(null);
#endif
            _Harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
        }

        private void OnDestroy()
        {
            if (_Harmony != null) _Harmony.UnpatchAll(null);
        }
    }
}
