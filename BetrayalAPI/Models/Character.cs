namespace BetrayalAPI.Models
{
    public class Character
    {
        public virtual string Name { get; set; }
        public virtual int[] Speed { get; set; }
        public virtual int CurrentSpeed { get; set; }
        public virtual int[] Might { get; set; }
        public virtual int CurrentMight { get; set; }
        public virtual int[] Sanity { get; set; }
        public virtual int CurrentSanity { get; set; }
        public virtual int[] Knowledge { get; set; }
        public virtual int CurrentKnowledge { get; set; }
        public virtual bool InUse { get; set; }
        public virtual string InUseBy { get; set; }
        public virtual int Id { get; set; }
    }
}