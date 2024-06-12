using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace BannerlordExpanded.SpousesExpanded.Polygamy.Behaviors
{
    internal class PlayerPolygamyBehavior : CampaignBehaviorBase
    {
        MBList<Hero> _secondarySpouses = new MBList<Hero>();

        public override void RegisterEvents()
        {
            //CampaignEvents.DailyTickHeroEvent.AddNonSerializedListener(this, RefreshSpouseVisit);
            //CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("BannerlordExpanded.SpousedExpanded_SecondarySpouses", ref _secondarySpouses);

        }


        public bool IsSpouse(Hero hero)
        {
            return _secondarySpouses.Contains(hero) || (Hero.MainHero.Spouse != null && hero == Hero.MainHero.Spouse);
        }

        public void SetPrimarySpouse(Hero hero)
        {
            if (!IsSpouse(hero))
            {
                throw new System.Exception($"[BannerlordExpanded.SpousesExpanded]: Tried setting Hero {hero.Name} as primary spouse even though he/she is not a spouse.");
            }


            if (Hero.MainHero.Spouse != hero)
            {

                _secondarySpouses.Remove(hero);
                _secondarySpouses.Add(Hero.MainHero.Spouse);

                Hero.MainHero.Spouse = hero;
                hero.Spouse = Hero.MainHero;
            }
        }

        public MBList<Hero> GetPlayerSpouses()
        {
            return new MBList<Hero>(_secondarySpouses);
        }

        public void AddSpouse(Hero hero)
        {
            _secondarySpouses.Add(hero);
        }

        public bool RemoveSpouse(Hero hero)
        {
            if (Hero.MainHero.Spouse == hero)
            {
                if (_secondarySpouses.Count > 0)
                    Hero.MainHero.Spouse = _secondarySpouses[0];
                else
                    Hero.MainHero.Spouse = null;
                return true;
            }
            else if (_secondarySpouses.Contains(hero))
            {
                _secondarySpouses.Remove(hero);
                return true;
            }
            else
            {
                // Hero is not a spouse?!
            }

            return false;
        }
    }
}
