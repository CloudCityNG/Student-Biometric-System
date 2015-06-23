using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrFingerXLib;

namespace AttendanceVerification
{
    public class TTemplate
    {
        // Template data.
        public System.Array tpt;
        // Template size
        public int size;

        public TTemplate()
        {
            // Create a byte buffer for the template
            tpt = new byte[(int)GRConstants.GR_MAX_SIZE_TEMPLATE];
            size = 0;
        }
    }
}
