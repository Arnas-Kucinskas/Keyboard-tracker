using System;


namespace HookFromV2
{
    public class TimeToFixMistakesObj
    {
        public int speed
        { get; set; }

        public double cps
        { get; private set; }

        public double percentage
        { get; set; }

        public double accountedForPrecentage
        { get; set; }

        public int count
        { get; set; }

        public int difference
        { get; set; }

        public TimeToFixMistakesObj(int sp, int cnt, int diff)
        {
            speed = sp;
            count = cnt;
        
            difference = diff;

            cps = Math.Round(1000 / (double)speed, 2);
        }

        public void CalcPercentages(int total, int totalAccountedfor)
        {
            percentage = Math.Round(((double)difference * 100) / (double)total, 2);
            accountedForPrecentage = Math.Round(((difference*count)*100)/(double)totalAccountedfor, 2);
        }
    }
}
