using BannerlordExpanded.SpousesExpanded.Polygamy.Behaviors;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordExpanded.SpousesExpanded.Polygamy.Patches
{
    [HarmonyPatchCategory("PolygamyModule")]
    [HarmonyPatch(typeof(DefaultMarriageModel), "IsSuitableForMarriage")]
    public static class IsSuitableForMarriagePatch
    {
        [HarmonyPostfix]
        static void Postfix(ref bool __result, Hero maidenOrSuitor)
        {
            if (!__result)
            {
                if (maidenOrSuitor == Hero.MainHero)
                {

                    __result = true;
                }

            }

            if (__result)
            {
                if (Campaign.Current.GetCampaignBehavior<PlayerPolygamyBehavior>().IsSpouse(maidenOrSuitor))
                {
                    __result = false;
                }
            }

        }
    }
}
