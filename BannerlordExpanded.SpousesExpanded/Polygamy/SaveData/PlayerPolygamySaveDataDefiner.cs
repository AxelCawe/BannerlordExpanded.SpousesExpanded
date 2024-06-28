using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace BannerlordExpanded.SpousesExpanded.Polygamy.SaveData
{
    public class PlayerPolygamySaveDataDefiner : SaveableTypeDefiner
    {
        public PlayerPolygamySaveDataDefiner() : base(069526952)
        {
        }
        protected override void DefineContainerDefinitions()
        {
            ConstructContainerDefinition(typeof(Dictionary<Hero, MBList<Hero>>));
        }
    }
}

