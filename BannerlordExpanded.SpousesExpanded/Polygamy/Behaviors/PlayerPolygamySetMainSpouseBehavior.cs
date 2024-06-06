using TaleWorlds.CampaignSystem;

namespace BannerlordExpanded.SpousesExpanded.Polygamy.Behaviors
{
    public class PlayerPolygamySetMainSpouseBehavior : CampaignBehaviorBase
    {
        PlayerPolygamyBehavior playerPolygamyBehavior;

        public override void RegisterEvents()
        {
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        }

        public override void SyncData(IDataStore dataStore)
        {

        }

        void OnGameLoaded(CampaignGameStarter gameStarter)
        {
            playerPolygamyBehavior = Campaign.Current.GetCampaignBehavior<PlayerPolygamyBehavior>();

            AddDialogs(gameStarter);
        }

        void AddDialogs(CampaignGameStarter gameStarter)
        {
            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse", "BannerlordExpandedSpousesExpanded_SpouseDialog_Start", "BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse", "{=BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse}I want you to become my main spouse.",
                () =>
                {
                    if (Hero.OneToOneConversationHero == null) return false;

                    return Hero.MainHero.Spouse != Hero.OneToOneConversationHero;
                },
                null
                );
            gameStarter.AddDialogLine("BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure", "BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse", "BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result", "{=BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure}Are you sure?", null, null);
            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result_Yes", "BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result", "BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result_Yes_After", "{=BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result_Yes}Yes of course!", null, () => { playerPolygamyBehavior.SetPrimarySpouse(Hero.OneToOneConversationHero); });
            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result_No", "BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result", "lord_pretalk", "{=BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result_No}On second thought, I have changed my mind.", null, null);

            gameStarter.AddDialogLine("BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result_Yes_After", "BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result_Yes_After", "lord_pretalk", "{=BannerlordExpandedSpousesExpanded_SpouseDialog_SetMainSpouse_AreYourSure_Result_Yes_After}I am more than happy to!", null, null);
        }




    }
}
