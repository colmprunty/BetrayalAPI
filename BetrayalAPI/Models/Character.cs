namespace BetrayalAPI.Models
{
    public class Character
    {
        public string Name { get; set; }
        public int[] Speed { get; set; }
        public int CurrentSpeed { get; set; }
        public int[] Might { get; set; }
        public int CurrentMight { get; set; }
        public int[] Sanity { get; set; }
        public int CurrentSanity { get; set; }
        public int[] Knowledge { get; set; }
        public int CurrentKnowledge { get; set; }
        public bool InUse { get; set; }
        public string InUseBy { get; set; }
        public int Id { get; set; }
    }
}