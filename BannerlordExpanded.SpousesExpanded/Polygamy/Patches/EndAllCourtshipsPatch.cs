using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordExpanded.SpousesExpanded.Polygamy.Patches
{
    [HarmonyPatchCategory("PolygamyModule")]
    [HarmonyPatch(typeof(Romance), "EndAllCourtships")]
    public static class EndAllCourtshipsPatch
    {
        [HarmonyPrefix]
        static bool Prefix(Hero forHero)
        {
            return forHero == Hero.MainHero;
        }
    }
}
