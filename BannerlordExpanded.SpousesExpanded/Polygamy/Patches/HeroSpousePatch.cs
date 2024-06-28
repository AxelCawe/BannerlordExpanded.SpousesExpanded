//using BannerlordExpanded.SpousesExpanded.Polygamy.Behaviors;
//using BannerlordExpanded.SpousesExpanded.Utility;
//using HarmonyLib;
//using TaleWorlds.CampaignSystem;

//namespace BannerlordExpanded.SpousesExpanded.Polygamy.Patches
//{
//    [HarmonyPatchCategory("PolygamyModule")]
//    [HarmonyPatch(typeof(Hero), "get_Spouse")]
//    public static class HeroSpousePatch
//    {
//        [HarmonyPostfix]
//        static void Postfix(ref Hero __result, ref Hero __instance)
//        {
//            PlayerPolygamyBehavior playerPolygamyBehavior = Campaign.Current.GetCampaignBehavior<PlayerPolygamyBehavior>();
//            if (playerPolygamyBehavior == null) return;
//            if (SpousesExpandedUtil.IsPlayerSpouse(__instance) && Hero.MainHero != null && Hero.MainHero.Spouse != __instance) // if player spouse but not the main spouse
//            {
//                __result = Hero.MainHero;
//            }
//        }
//    }
//}
