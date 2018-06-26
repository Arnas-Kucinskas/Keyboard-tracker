using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookFromV2
{
    public class Programs
    {
        public int Id { get; set; }

        [Index]
        public string exe { get; set; }
        public string name { get; set; }
        public byte filter { get; set; }
    
    }
}
