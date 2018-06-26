using System.Collections.Generic;


namespace HookFromV2
{
    public class MistakesObject
    {
        public string replacedValue
        { get; set; }

        public int replacedTimes
        { get; set; } = 0;

        public string deletedValue
        { get; set; }

       public List<string> finalWord = new List<string>();
     
      

        public MistakesObject()
        {

        }

        public MistakesObject(string deleted, string replaced, int times)
        {
            replacedValue = replaced;
            replacedTimes = times;
            deletedValue = deleted;
         
        }
        public MistakesObject(string deleted, string replaced)
        {
            replacedValue = replaced;
            replacedTimes = 1;
            deletedValue = deleted;
            
        }

        public MistakesObject(string replaced)
        {
            replacedValue = replaced;
            replacedTimes = 1;
        }
    }
}
