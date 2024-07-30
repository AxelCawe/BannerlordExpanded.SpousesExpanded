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

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyDuration}Custom Pregnancy Duration", GroupOrder = 5)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyDuration}Custom Pregnancy Duration", RequireRestart = true, IsToggle = true)]
        public bool PregnancyDurationEnabled { get; set; } = true;
        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyDuration}Custom Pregnancy Duration", GroupOrder = 5)]
        [SettingPropertyFloatingInteger("{=BannerlordExpandedSpousesExpanded_Settings_PregnancyDurationDays}Pregnancy Duration in Days", 1f, 250f)]
        public float PregnancyDurationInDays { get; set; } = 36f;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_MaternalMortality}Custom Maternal Mortality", GroupOrder = 6)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_MaternalMortality}Custom Maternal Mortality", RequireRestart = true, IsToggle = true)]
        public bool CustomMortalityInLaborEnabled { get; set; } = true;
        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_MaternalMortality}Custom Maternal Mortality", GroupOrder = 6)]
        [SettingPropertyFloatingInteger("{=BannerlordExpandedSpousesExpanded_Settings_MaternalMortalityChance}Chance of mother dying in childbirth", 0f, 1f)]
        public float MortalityChanceInLabor { get; set; } = 0.015f;


        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_StillBirth}Custom Still Birth", GroupOrder = 7)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_StillBirth}Custom Still Birth", RequireRestart = true, IsToggle = true)]
        public bool CustomStillBirthEnabled { get; set; } = true;
        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_StillBirth}Custom Still Birth", GroupOrder = 7)]
        [SettingPropertyFloatingInteger("{=BannerlordExpandedSpousesExpanded_Settings_StillBirthChance}Chance of baby dying in childbirth", 0f, 1f)]
        public float StillBirthChance { get; set; } = 0.01f;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_FemaleOffSpring}Custom Female OffSpring Chance", GroupOrder = 8)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_FemaleOffSpring}Custom Female OffSpring Chance", RequireRestart = true, IsToggle = true)]
        public bool CustomFemaleOffSpringEnabled { get; set; } = true;
        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_FemaleOffSpring}Custom Female OffSpring Chance", GroupOrder = 8)]
        [SettingPropertyFloatingInteger("{=BannerlordExpandedSpousesExpanded_Settings_FemaleOffSpringChance}Chance of female baby in childbirth", 0f, 1f)]
        public float FemaleOffSpringChance { get; set; } = 0.51f;

        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_TwinProbability}Custom Twin Probability", GroupOrder = 8)]
        [SettingPropertyBool("{=BannerlordExpandedSpousesExpanded_Settings_TwinProbability}Custom Twin Probability", RequireRestart = true, IsToggle = true)]
        public bool CustomTwinProbabilityEnabled { get; set; } = true;
        [SettingPropertyGroup("{=BannerlordExpandedSpousesExpanded_Settings_TwinProbability}Custom Twin Probability", GroupOrder = 8)]
        [SettingPropertyFloatingInteger("{=BannerlordExpandedSpousesExpanded_Settings_TwinProbabilityChance}Chance of twins in childbirth", 0f, 1f)]
        public float TwinProbabilityChance { get; set; } = 0.03f;

    }
}
