using BannerlordExpanded.SpousesExpanded.Polygamy.Behaviors;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace BannerlordExpanded.SpousesExpanded.Polygamy.Patches
{
    [HarmonyPatchCategory("PolygamyModule")]
    [HarmonyPatch(typeof(ConversationHelper), "GetHeroRelationToHeroTextShort")]
    static class GetHeroRelationToHeroTextShortPatch
    {
        static bool IsPlayerSpouse(Hero hero)
        {
            return Campaign.Current.GetCampaignBehavior<PlayerPolygamyBehavior>().IsSpouse(hero);
        }

        static MBList<Hero> GetPlayerSpouses()
        {
            return Campaign.Current.GetCampaignBehavior<PlayerPolygamyBehavior>().GetPlayerSpouses();
        }

        [HarmonyPostfix]
        static void Postfix(ref string __result, Hero queriedHero, Hero baseHero, bool uppercaseFirst)
        {
            TextObject textObject = null;

            if (baseHero == Hero.MainHero && IsPlayerSpouse(queriedHero) || queriedHero == Hero.MainHero && IsPlayerSpouse(baseHero))
            {
                textObject = GameTexts.FindText("str_spouse", null);
            }
            else if (baseHero == Hero.MainHero && IsPlayerSpouse(queriedHero) && queriedHero.Father == queriedHero)
            {
                textObject = (!queriedHero.IsFemale ? GameTexts.FindText("str_husband_fatherinlaw", null) : GameTexts.FindText("str_wife_fatherinlaw", null));
            }
            else if (baseHero == Hero.MainHero && IsPlayerSpouse(queriedHero) && queriedHero.Mother == queriedHero)
            {
                textObject = (!queriedHero.IsFemale ? GameTexts.FindText("str_husband_motherinlaw", null) : GameTexts.FindText("str_wife_motherinlaw", null));
            }
            else if (baseHero == Hero.MainHero && GetPlayerSpouses().Any((Hero spouse) => spouse.Siblings.Contains(queriedHero)))
            {
                textObject = (baseHero.IsFemale ? GameTexts.FindText(queriedHero.IsFemale ? "str_husband_sisterinlaw" : "str_husband_brotherinlaw", null) : GameTexts.FindText(queriedHero.IsFemale ? "str_wife_sisterinlaw" : "str_wife_brotherinlaw", null));
            }

            if (textObject != null)
            {
                string text = textObject.ToString();
                if (!char.IsLower(text[0]) != uppercaseFirst)
                {
                    char[] array = text.ToCharArray();
                    text = (uppercaseFirst ? array[0].ToString().ToUpper() : array[0].ToString().ToLower());
                    for (int i = 1; i < array.Length; i++)
                    {
                        text += array[i].ToString();
                    }
                }
                __result = text;
            }
        }
    }
}
