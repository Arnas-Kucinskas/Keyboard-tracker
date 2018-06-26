using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookFromV2.Models
{
    class Mistakes
    {
        [AutoIncrement]
        public int Id { get; set; }

        [Index]
        public string deleted { get; set; }
        public string replaced_with { get; set; }
        public string datetime { get; set; }
        public int program_id{ get; set; }
        public string final_word { get; set; }
        public int typing_speed { get; set; }
        public int true_typing_speed { get; set; }
    }
}
