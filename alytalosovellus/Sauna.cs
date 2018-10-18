using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alytalosovellus
{
    public class Sauna
    {
        public bool Switch { get; set; }

        public void SaunaPäälle()
        {
            Switch = true;
        }
        public void SaunaPois()
        {
            Switch = false;
        }
    }
}
