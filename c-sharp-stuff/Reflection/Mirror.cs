using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public class Mirror
    {
        public bool SeeYourself { get; set; }
        public string SeeYourselfUgh { get; set; }

        public Mirror()
        {
            SeeYourself = true;
            SeeYourselfUgh = "true";
        }

        public string Look()
        {
            return "it's me";
        }
    }
}
