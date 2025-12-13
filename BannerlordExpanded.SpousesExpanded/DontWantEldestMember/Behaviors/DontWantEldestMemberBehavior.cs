using Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace BannerlordExpanded.SpousesExpanded.Behaviors
{
    public class DontWantEldestMemberBehavior : CampaignBehaviorBase
    {

        RomanceCampaignBehavior _romanceCampaignBehavior;

        bool _isSpouseCandidateValid = false;

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, AddDialogs);
        }

        public override void SyncData(IDataStore dataStore)
        {
            //throw new NotImplementedException();
        }

        private void AddDialogs(CampaignGameStarter gameStarter)
        {
            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_DontWantEldestMember_Start", "lord_propose_marriage_to_clan_leader_response_other", "BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue", "{=BannerlordExpandedSpousesExpanded_DontWantEldestMember_Start}I was thinking of someone else...", () => IsGoodToShowDialog(), () => OpenInquiryMenu(), 101, null, null);
            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_DontWantEldestMember_Start", "lord_propose_marriage_to_clan_leader_response_self", "BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue", "{=BannerlordExpandedSpousesExpanded_DontWantEldestMember_Start}I was thinking of someone else...", () => IsGoodToShowDialog(), () => OpenInquiryMenu(), 101, null, null);

            gameStarter.AddDialogLine("BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue", "BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue", "BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue2", "{=BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue}Who do you have in mind?", null, null, 100, null);
            gameStarter.AddDialogLine("BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue_Success", "BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue2", "BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue_Success_Reply", "{=BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue2}I see. So you are interested in {HERO.LINK}?", () => IsSpouseCandidateValid(), null, 100, null);
            gameStarter.AddDialogLine("BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue_Failed", "BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue2", "lord_pretalk", "{=BannerlordExpandedSpousesExpanded_DontWantEldestMember_ContinueFailed}Do you have no one in mind?", () => !_isSpouseCandidateValid, null, 100, null);

            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue_Success_ReplyConfirm", "BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue_Success_Reply", "lord_propose_marriage_to_clan_leader_confirm", "{=BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue_Success_ReplyConfirm}Yes I am interested!", null, null, 100, null, null);
            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue_Success_ReplyCancel", "BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue_Success_Reply", "lord_pretalk", "{=BannerlordExpandedSpousesExpanded_DontWantEldestMember_Continue_Success_ReplyCancel}Sorry.. I am having second thoughts. Let me consider for a while...", null, null, 100, null, null);

        }

        private bool IsGoodToShowDialog()
        {
            _romanceCampaignBehavior = Campaign.Current.GetCampaignBehavior<RomanceCampaignBehavior>();
            return _romanceCampaignBehavior != null;
        }

        private bool IsSpouseCandidateValid()
        {
            if (!_isSpouseCandidateValid)
                return false;
            else
            {
                object spouseCandidate = typeof(RomanceCampaignBehavior).GetField("_proposedSpouseForPlayerRelative", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_romanceCampaignBehavior);
                if (spouseCandidate != null)
                {
                    Hero spouseCandidateHero = spouseCandidate as Hero;
                    MBTextManager.SetTextVariable("HERO_NAME", spouseCandidateHero.Name, false);
                    StringHelpers.SetCharacterProperties("HERO", spouseCandidateHero.CharacterObject);
                    return true;
                }
                else return false;
            }
        }

        private void OpenInquiryMenu()
        {
            var playerProposalHero = (Hero)typeof(RomanceCampaignBehavior).GetField("_playerProposalHero", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_romanceCampaignBehavior);
            MethodInfo MarriageCourtshipPossibility = typeof(RomanceCampaignBehavior).GetMethod("MarriageCourtshipPossibility", BindingFlags.NonPublic | BindingFlags.Instance);



            List<InquiryElement> list = new List<InquiryElement>();
            foreach (Hero hero in from x in Hero.OneToOneConversationHero.Clan.AliveLords
                                  orderby x.Age descending
                                  select x)
            {


                if ((bool)MarriageCourtshipPossibility.Invoke(_romanceCampaignBehavior, new object[] { playerProposalHero, hero }) && hero != Hero.OneToOneConversationHero)
                {
                    bool alreadyExists = false;
                    foreach (InquiryElement element in list)
                    {
                        if ((MBGUID)element.Identifier == hero.Id)
                        {
                            alreadyExists = true;
                            break;
                        }
                    }
                    if (!alreadyExists)
                        list.Add(new InquiryElement(hero.Id, hero.Name.ToString(), new CharacterImageIdentifier(CharacterCode.CreateFrom(hero.CharacterObject))));
                }
            }
            MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(new TextObject("{=BannerlordExpandedSpousesExpanded_DontWantYourEldestMember_GameMenu_Title}Who would you prefer?").ToString()
                , new TextObject("{=annerlordExpandedSpousesExpanded_DontWantYourEldestMember_GameMenu_Desc}Select Lord/Lady that you want to be the spouse of your selected clan member.").ToString()
                , list, true, 1, 1, new TextObject("{=annerlordExpandedSpousesExpanded_DontWantYourEldestMember_GameMenu_Confirm}Confirm").ToString()
                , new TextObject("{=annerlordExpandedSpousesExpanded_DontWantYourEldestMember_GameMenu_Cancel}Cancel").ToString()
                , MultiSelectionInquiry_ManageSelectedHero
                , MultiSelectionInquiry_Cancelled));
        }


        void MultiSelectionInquiry_ManageSelectedHero(List<InquiryElement> inqury)
        {
            InquiryElement inquiryElement = inqury[inqury.Count - 1];
            Hero first = Hero.FindFirst(H => H.Id == (MBGUID)inquiryElement.Identifier);

            typeof(RomanceCampaignBehavior).GetField("_proposedSpouseForPlayerRelative", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_romanceCampaignBehavior, first);
            _isSpouseCandidateValid = true;
            Campaign.Current.ConversationManager.ContinueConversation();
        }

        void MultiSelectionInquiry_Cancelled(List<InquiryElement> inqury)
        {
            _isSpouseCandidateValid = false;
            Campaign.Current.ConversationManager.ContinueConversation();
        }
    }
}
