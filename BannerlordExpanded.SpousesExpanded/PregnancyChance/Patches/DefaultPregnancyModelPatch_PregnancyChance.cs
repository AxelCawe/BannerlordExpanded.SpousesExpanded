using BannerlordExpanded.SpousesExpanded.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordExpanded.SpousesExpanded.PregnancyChance.Patches
{
    [HarmonyPatchCategory("PregnancyChance")]
    [HarmonyPatch(typeof(DefaultPregnancyModel), "GetDailyChanceOfPregnancyForHero")]
    public static class DefaultPregnancyModelPatch_PregnancyChance
    {
        [HarmonyPostfix]
        static void Postfix(Hero hero, ref float __result)
        {
            // Apply global multiplier to all heroes
            __result *= MCMSettings.Instance.PregnancyChanceGlobalMultiplier;

            // Apply additional player spouse multiplier if the hero is a spouse of the player
            if (hero != null && Hero.MainHero != null && IsSpouseOfPlayer(hero))
            {
                __result *= MCMSettings.Instance.PregnancyChancePlayerSpouseMultiplier;
            }
        }

        private static bool IsSpouseOfPlayer(Hero hero)
        {
            return hero.Spouse == Hero.MainHero;
        }
    }
}
