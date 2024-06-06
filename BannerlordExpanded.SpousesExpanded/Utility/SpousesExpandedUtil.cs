using BannerlordExpanded.SpousesExpanded.Polygamy.Behaviors;
using BannerlordExpanded.SpousesExpanded.Settings;
using TaleWorlds.CampaignSystem;

namespace BannerlordExpanded.SpousesExpanded.Utility
{
    public static class SpousesExpandedUtil
    {
        public static bool IsPlayerSpouse(Hero hero)
        {
            if (MCMSettings.Instance.PolygamyEnabled)
            {
                Campaign.Current.GetCampaignBehavior<PlayerPolygamyBehavior>().IsSpouse(hero);
            }
            else if (Hero.MainHero.Spouse == hero)
            {
                return true;
            }
            return false;
        }
    }
}
