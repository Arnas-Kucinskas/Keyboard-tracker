using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookFromV2
{
    class Inputs
    {
        public int Id { get; set; }

        [Index]
        public string input { get; set; }
        public int timestamp { get; set; }
        public int program_id { get; set; }
        public string datetime { get; set; }

    }
}
