using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace ValheimTogglePins
{
    [BepInPlugin("seroyer.ValheimTogglePins", "Valheim Toggle Pins", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class TogglePins : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("seroyer.ValheimTogglePins");

        private static bool m_keyInit = false;
        private static bool m_pinsVisible = true;

        void Awake()
        {
            harmony.PatchAll();
        }

        void OnDestroy()
        {
            harmony.UnpatchSelf();
        }

        [HarmonyPatch(typeof(ZInput), "Reset")]
        public static class ZInput_Reset_Patch
        {
            public static void Postfix(ref ZInput __instance)
            {
                __instance.AddButton("TogglePins", KeyCode.T);
                m_keyInit = true;
            }
        }

        [HarmonyPatch(typeof(Minimap), "IsPointVisible")]
        public static class Minimap_IsPointVisible_Patch
        {
            public static bool Prefix(ref bool __result, Vector3 p, RawImage map)
            {
                if (!m_pinsVisible)
                {
                    __result = false;
                    return false;
                }
                return true;
            }
        }

        void Update()
        {
            if (m_keyInit && ZInput.GetButtonDown("TogglePins"))
            {
                m_pinsVisible = !m_pinsVisible;
            }
        }
    }
}