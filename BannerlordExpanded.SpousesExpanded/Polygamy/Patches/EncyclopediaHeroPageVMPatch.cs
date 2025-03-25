using BannerlordExpanded.SpousesExpanded.Polygamy.Behaviors;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;

namespace BannerlordExpanded.SpousesExpanded.Polygamy.Patches
{
    [HarmonyPatchCategory("PolygamyModule")]
    [HarmonyPatch(typeof(EncyclopediaHeroPageVM), new[] { typeof(EncyclopediaPageArgs) })]
    [HarmonyPatch(MethodType.Constructor)]
    public static class EncyclopediaHeroPageVMPatch
    {
        [HarmonyPostfix]
        static void Postfix(EncyclopediaHeroPageVM __instance, EncyclopediaPageArgs args)
        {
            if (AccessTools.Field(typeof(EncyclopediaHeroPageVM), "_hero").GetValue(__instance) == Hero.MainHero)
            {
                FieldInfo field = AccessTools.Field(typeof(EncyclopediaHeroPageVM), "_allRelatedHeroes");
                List<Hero> allRelatedHeroes = field.GetValue(__instance) as List<Hero>;
                List<Hero> spouses = Campaign.Current.GetCampaignBehavior<PlayerPolygamyBehavior>().GetPlayerSpouses();
                foreach (Hero spouse in spouses)
                {
                    if (!allRelatedHeroes.Contains(spouse))
                    {
                        allRelatedHeroes.Add(spouse);
                    }
                }
                field.SetValue(__instance, allRelatedHeroes);
                __instance.RefreshValues();
            }

        }
    }
}
