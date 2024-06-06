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



        [SettingPropertyGroup("{=BE_SE_Settings_Polygamy}Companion To Family Conversations", GroupOrder = 0)]
        [SettingPropertyBool("{=BE_SE_Settings_PolygamyEnabled}Enable Disown Children Conversation", RequireRestart = true, IsToggle = true)]
        public bool PolygamyEnabled { get; set; } = true;


    }
}
