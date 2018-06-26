using System.Windows.Forms;

namespace HookFromV2
{
    class RuleObj
    {
        public string deltedKey
        { get; set; }

        public string replacedWithKey
        { get; set; }

        public Keys ruleKeyUsed
        { get; set; }

        public int timerDeleted
        { get; set; }

        public int timerReplaced
        { get; set; }

        public RuleObj()
        {

        }

        public RuleObj(string deleted, Keys ruleKey)
        {
            deltedKey = deleted;
            ruleKeyUsed = ruleKey;
        }

            public RuleObj(string replaced)
        {
            replacedWithKey = replaced;
        }
    }
}
