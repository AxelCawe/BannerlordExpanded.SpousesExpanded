using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BannerlordExpanded.SpousesExpanded.Settings
{
    internal class MCMSettings : AttributeGlobalSettings<MCMSettings>
    {
        public override string Id => "BannerlordExpanded.SpousesExpanded";

        public override string DisplayName => "BE - Spouses Expanded";

        public override string FolderName => "BannerlordExpanded.SpousesExpanded";

        public override string FormatType => "xml";



        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_Polygamy}Player Polygamy", GroupOrder = 0)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_PolygamyEnabled}Enable", RequireRestart = true, IsToggle = true)]
        public bool PolygamyEnabled { get; set; } = true;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_DontWantEldestMember}I Dont Want Your Eldest Member", GroupOrder = 1)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_DontWantEldestMemberEnabled}Enable", HintText = "{=BannerlordExpandedSpousesExpanded_Settings_DontWantEldestMemberEnabled_Desc}Enable the option to choose any of the clan's marry-able characters for marriage instead of only the oldest one.", RequireRestart = true, IsToggle = true)]
        public bool DontWantEldestMemberEnabled { get; set; } = true;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_MarriageOfferForPlayer}Marriage Offer For Player", GroupOrder = 1)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_MarriageOfferForPlayerEnabled}Enable", RequireRestart = true, IsToggle = true)]
        public bool MarriageOfferForPlayerEnabled { get; set; } = true;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_Divorce}Player Divorce", GroupOrder = 1)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_DivorceEnabled}Enable", RequireRestart = true, IsToggle = true)]
        public bool DivorceEnabled { get; set; } = true;
    }
}
