

namespace HookFromV2
{
    public class ProgramExe
    {
        public int _id
        { get; set; }

        public string _name
        { get; set; }

        public string _exe
        { get; set; }

        public bool _filter
        { get; set; }

        public ProgramExe(int id,  bool filter)
        {
            _id = id;
            _filter = filter;
        }

            public ProgramExe(int id, string name, string exe, bool filter)
        {
            _id = id;
            _name = name;
            _exe = exe;
            _filter = filter;
        }
    }
}
