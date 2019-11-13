using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro
{

    public class RootPageMasterMenuItem
    {
        public RootPageMasterMenuItem()
        {
            TargetType = typeof(RootPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}