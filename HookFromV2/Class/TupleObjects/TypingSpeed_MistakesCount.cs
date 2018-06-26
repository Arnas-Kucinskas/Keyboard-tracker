

namespace HookFromV2
{
    public class TypingSpeed_MistakesCount
    {
        public double speed
        { get; set; }


        public int mistakesCount
        { get; set; }

        public double percentage
        { get; set; }

        public TypingSpeed_MistakesCount(double spd, int mst)
        {
            speed = spd;
            mistakesCount = mst;
        }

        public TypingSpeed_MistakesCount(double spd, int mst, double perc)
        {
            speed = spd;
            mistakesCount = mst;
            percentage = perc;
        }
    }
}
