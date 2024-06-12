using BannerlordExpanded.SpousesExpanded.Utility;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace BannerlordExpanded.SpousesExpanded.MarriageOfferForPlayer.Behaviors
{
    internal class MarriageOfferForPlayerBehavior : CampaignBehaviorBase
    {

        MethodInfo _considerMarriageForPlayerClanMemberMethod;
        MethodInfo _canOfferMarriageForClanMethod;

        MarriageOfferCampaignBehavior _marriageOfferCampaignBehavior;
        public override void RegisterEvents()
        {
            //throw new System.NotImplementedException();
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
            CampaignEvents.DailyTickClanEvent.AddNonSerializedListener(this, DailyTick);
        }

        public override void SyncData(IDataStore dataStore)
        {
            //throw new System.NotImplementedException();
        }

        public void OnGameLoaded(CampaignGameStarter gameStarter)
        {
            _marriageOfferCampaignBehavior = Campaign.Current.GetCampaignBehavior<MarriageOfferCampaignBehavior>();
        }

        public void DailyTick(Clan consideringClan)
        {
            if (SpousesExpandedUtil.IsPlayerMarried() == false && CanOfferMarriageForClan(consideringClan))
            {
                ConsiderMarriageForPlayerClanMember(consideringClan);
            }
        }

        private bool ConsiderMarriageForPlayerClanMember(Clan consideringClan)
        {
            if (_considerMarriageForPlayerClanMemberMethod == null)
                _considerMarriageForPlayerClanMemberMethod = typeof(MarriageOfferCampaignBehavior).GetMethod("ConsiderMarriageForPlayerClanMember", BindingFlags.NonPublic | BindingFlags.Instance);

            return (bool)_considerMarriageForPlayerClanMemberMethod.Invoke(_marriageOfferCampaignBehavior, new object[] { Hero.MainHero, consideringClan });
        }

        private bool CanOfferMarriageForClan(Clan consideringClan)
        {

            if (_canOfferMarriageForClanMethod == null)
                _canOfferMarriageForClanMethod = typeof(MarriageOfferCampaignBehavior).GetMethod("CanOfferMarriageForClan", BindingFlags.NonPublic | BindingFlags.Instance);

            return (bool)_canOfferMarriageForClanMethod.Invoke(_marriageOfferCampaignBehavior, new object[] { consideringClan });
        }
    }
}
