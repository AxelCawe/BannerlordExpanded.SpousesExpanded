using BannerlordExpanded.SpousesExpanded.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordExpanded.SpousesExpanded.PregnancyDuration.Patches
{
    [HarmonyPatchCategory("PregnancyDuration")]
    [HarmonyPatch(typeof(DefaultPregnancyModel), "get_PregnancyDurationInDays")]
    public static class DefaultPregnancyModelPatch_PregnancyDuration
    {
        [HarmonyPostfix]
        static void Postfix(ref float __result)
        {
            __result = MCMSettings.Instance.PregnancyDurationInDays;
        }

    }
}
