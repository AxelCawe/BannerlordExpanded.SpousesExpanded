using BannerlordExpanded.SpousesExpanded.Polygamy.Behaviors;
using BannerlordExpanded.SpousesExpanded.Settings;
using System.Reflection;
using TaleWorlds.CampaignSystem;

namespace BannerlordExpanded.SpousesExpanded.Utility
{
    public static class SpousesExpandedUtil
    {
        public static bool IsPlayerSpouse(Hero hero)
        {
            if (MCMSettings.Instance.PolygamyEnabled)
            {
                return Campaign.Current.GetCampaignBehavior<PlayerPolygamyBehavior>().IsSpouse(hero);
            }
            else if (Hero.MainHero.Spouse == hero)
            {
                return true;
            }
            return false;
        }

        public static bool IsPlayerMarried()
        {
            if (MCMSettings.Instance.PolygamyEnabled)
                return false;
            else
                return Hero.MainHero.Spouse != null;
        }

        public static bool DivorceHero(Hero hero)
        {
            bool success = false;
            if (MCMSettings.Instance.PolygamyEnabled)
                success = Campaign.Current.GetCampaignBehavior<PlayerPolygamyBehavior>().RemoveSpouse(hero);
            else if (hero == Hero.MainHero.Spouse)
            {
                Hero.MainHero.Spouse = null;
                success = true;
            }
            if (success)
                hero.Spouse = null;
            return success;
        }

        public static void SetHeroSpouse(Hero mainHero, Hero spouse)
        {
            FieldInfo spouseField = typeof(Hero).GetField("_spouse", BindingFlags.Instance | BindingFlags.NonPublic);
            spouseField.SetValue(mainHero, spouse);
        }
    }
}
