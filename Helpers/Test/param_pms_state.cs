using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    public class param_pms_state
    {
        [Key]
        public string param_pms_state_cd { get; set; }
        public string param_pms_state_name { get; set; }
        public int param_pms_state_sort { get; set; }
    }
}
