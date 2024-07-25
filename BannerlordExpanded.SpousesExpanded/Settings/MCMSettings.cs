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

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_MarriageOfferForPlayer}Marriage Offer For Player", GroupOrder = 2)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_MarriageOfferForPlayerEnabled}Enable", RequireRestart = true, IsToggle = true)]
        public bool MarriageOfferForPlayerEnabled { get; set; } = true;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_Divorce}Player Divorce", GroupOrder = 3)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_DivorceEnabled}Enable", RequireRestart = true, IsToggle = true)]
        public bool DivorceEnabled { get; set; } = true;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyAge}Custom Pregnancy Age Range", GroupOrder = 4)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyAge}Custom Pregnancy Age Range", RequireRestart = true, IsToggle = true)]
        public bool PregnancyAgeEnabled { get; set; } = true;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyAge}Custom Pregnancy Age Range", GroupOrder = 4)]
        [SettingPropertyInteger("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyAgeMin}Minimum Age for Pregnancy", 18, 125, HintText = "{=BannerlordExpandedSpousesExpanded_Settings_PregnancyAgeMin_Desc}Must be below Max Age to avoid errors!", RequireRestart = true)]
        public int PregnancyAgeMin { get; set; } = 18;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyAge}Custom Pregnancy Age Range", GroupOrder = 4)]
        [SettingPropertyInteger("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyAgeMax}Maxmimum Age for Pregnancy", 18, 250, HintText = "{=BannerlordExpandedSpousesExpanded_Settings_PregnancyAgeMax_Desc}Must be above Min Age to avoid errors!", RequireRestart = true)]
        public int PregnancyAgeMax { get; set; } = 45;

        public bool PregnancyDurationEnabled { get; set; } = true;
        public float PregnancyDurationInDays { get; set; } = 36f;

    }
}
