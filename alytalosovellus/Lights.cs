using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alytalosovellus
{
    public class Lights
    {
        public string Dimmer { get; set; } = "0";
        public bool Valot { get; set; }
        public void ValotPäälle()
        {
            Valot = true;
        }
        public void ValotPois()
        {
            Valot = false;
        }

    }
}
