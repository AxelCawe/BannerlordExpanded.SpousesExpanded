using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace BannerlordExpanded.SpousesExpanded.Polygamy.Patches
{
    [HarmonyPatchCategory("PolygamyModule")]
    [HarmonyPatch(typeof(RomanceCampaignBehavior), "conversation_player_eligible_for_marriage_with_conversation_hero_on_condition")]
    public static class ConversationPlayerElligibleForMarriagePatch2
    {
        [HarmonyPostfix]
        static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }
}
