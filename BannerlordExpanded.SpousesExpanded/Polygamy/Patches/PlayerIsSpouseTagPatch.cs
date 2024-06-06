using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation.Tags;

namespace BannerlordExpanded.SpousesExpanded.Polygamy.Patches
{
    [HarmonyPatchCategory("PolygamyModule")]
    [HarmonyPatch(typeof(PlayerIsSpouseTag), "IsApplicableTo")]
    public static class PlayerIsSpouseTagPatch
    {
        [HarmonyPostfix]
        static void Postfix(ref bool __result, CharacterObject character)
        {
            if (!__result)
            {
                __result = (character.IsHero && Hero.MainHero.ExSpouses.Contains(character.HeroObject));
            }
        }
    }
}
