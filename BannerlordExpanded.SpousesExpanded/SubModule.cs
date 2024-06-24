using BannerlordExpanded.SpousesExpanded.BaseSpouseDialog.Behaviors;
using BannerlordExpanded.SpousesExpanded.Behaviors;
using BannerlordExpanded.SpousesExpanded.Divorce;
using BannerlordExpanded.SpousesExpanded.MarriageOfferForPlayer.Behaviors;
using BannerlordExpanded.SpousesExpanded.Polygamy.Behaviors;
using BannerlordExpanded.SpousesExpanded.Settings;
using HarmonyLib;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;


namespace BannerlordExpanded.SpousesExpanded
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();

        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            Harmony harmony = new Harmony("BannerlordExpanded.SpousesExpanded");

            if (MCMSettings.Instance.PolygamyEnabled)
                harmony.PatchCategory(Assembly.GetExecutingAssembly(), "PolygamyModule");
            if (MCMSettings.Instance.PregnancyAgeEnabled)
                harmony.PatchCategory(Assembly.GetExecutingAssembly(), "PregnancyAge");
            //harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            base.OnGameStart(game, gameStarter);
            if (gameStarter is CampaignGameStarter)
                AddBehaviors(gameStarter as CampaignGameStarter);
        }

        private void AddBehaviors(CampaignGameStarter gameStarter)
        {
            gameStarter.AddBehavior(new BaseWifeDialogBehavior());

            if (MCMSettings.Instance.PolygamyEnabled)
            {
                gameStarter.AddBehavior(new PlayerPolygamyBehavior());
                gameStarter.AddBehavior(new PlayerPolygamySetMainSpouseBehavior());
            }
            if (MCMSettings.Instance.DontWantEldestMemberEnabled)
            {
                gameStarter.AddBehavior(new DontWantEldestMemberBehavior());
            }
            if (MCMSettings.Instance.MarriageOfferForPlayerEnabled)
            {
                gameStarter.AddBehavior(new MarriageOfferForPlayerBehavior());
            }
            if (MCMSettings.Instance.DivorceEnabled)
            {
                gameStarter.AddBehavior(new PlayerDivorceBehavior());
            }

        }
    }
}