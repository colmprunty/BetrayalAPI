using FluentNHibernate.Mapping;

namespace BetrayalAPI.Models
{
    public class CharacterMap : ClassMap<Character>
    {
        public CharacterMap()
        {
            Map(x => x.Name);
            Map(x => x.Speed);
            Map(x => x.CurrentSpeed);
            Map(x => x.Might);
            Map(x => x.CurrentMight);
            Map(x => x.Sanity);
            Map(x => x.CurrentSanity);
            Map(x => x.Knowledge);
            Map(x => x.CurrentKnowledge);
            Map(x => x.InUse);
            Map(x => x.InUseBy);
            Id(x => x.Id);
        }
    }
}