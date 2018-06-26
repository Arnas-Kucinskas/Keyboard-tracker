using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookFromV2
{
    public class Heatmap
    {
        [AutoIncrement]
        public int Id { get; }

        [Index]
        public string input { get; set; }
        public int delay { get; set; }

        //[CheckConstraint("date BETWEEN '2018' and '2019'")]
        public string date { get; set; }
        public int program_id { get; set; }
        

    
    }
}
