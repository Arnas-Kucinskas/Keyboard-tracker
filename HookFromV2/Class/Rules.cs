using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace HookFromV2
{
     class Rules
    {

        public List<RuleObj> RuleKey(Keys vkCode, List<RuleObj> bambozledList, TrackingBuffer buffObj, int timer_deleted)
        {
            RuleObj tupleObject = new RuleObj();
     
                if (vkCode == Keys.Delete && buffObj.ValidateBounds(1))
                {
                    tupleObject.ruleKeyUsed = Keys.Delete;
                    tupleObject.deltedKey = buffObj.GetDeleteValue();
                    tupleObject.timerDeleted = timer_deleted;
                }
                else if (vkCode == Keys.Back && buffObj.ValidateBounds(0))
                {
                    tupleObject.ruleKeyUsed = Keys.Back;
                    tupleObject.deltedKey = buffObj.GetBackSpaceValue();
                    tupleObject.timerDeleted = timer_deleted;
                }
                bambozledList.Add(tupleObject);
 
            return bambozledList;
        }

        private List<RuleObj> UpdateTupleList(List<RuleObj> bambozledList, TrackingBuffer buffObj, int i, Keys key)
        {
            RuleObj tuple = new RuleObj(buffObj.buffer[i]._input, key);
            bambozledList.Add(tuple);
            bambozledList = SortTupleList(bambozledList, buffObj);
            return bambozledList;
        }


        public List<RuleObj> SortTupleList(List<RuleObj> bambozledList, TrackingBuffer buffObj)
        {
            if (bambozledList.Count > 0 && buffObj.Count() > 0) 
            {
                for (int i = bambozledList.Count - 1; i >= 0; i--)
                {
                    if (bambozledList[i].ruleKeyUsed == Keys.Back)
                    {
                        RuleObj tupleObject = bambozledList[i];
                        tupleObject.ruleKeyUsed = Keys.Delete;
                        bambozledList.RemoveAt(i);
                        bambozledList.Insert(0, tupleObject);
                    }

                }
            }
            return bambozledList;
        }

        public void NormalKey(List<RuleObj> tupleList, string vkCode, int timer_replaced)
        {
            int listCount = tupleList.Count();
            if (tupleList[listCount-1].replacedWithKey != null)
            {
                RuleObj tupleObject = new RuleObj(vkCode);
                tupleList.Add(tupleObject);
            }
            for (int i = 0; i < tupleList.Count; i++)
            {
                if (tupleList[i].replacedWithKey == null)
                {
                    tupleList[i].replacedWithKey = vkCode.ToString();
                    tupleList[i].timerReplaced = timer_replaced;
                    break;
                }
            }

        }
        /* Checks if word has already been deleted */
        public bool OneWordValidation(Keys vkCode, TrackingBuffer buffer)
        {
            bool result = false;

            if (vkCode == Keys.Back && buffer.ValidateBounds(0))
            {
                if (buffer.GetValue(0) == " ")
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
