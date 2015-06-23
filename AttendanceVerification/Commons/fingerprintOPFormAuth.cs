using System;
using System.Data;
using GrFingerXLib;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AttendanceVerification
{
    public struct TRawImage
    {
        // Image data.
        public object img;
        // Image width.
        public int width;
        // Image height.
        public int height;
        // Image resolution.
        public int Res;
    };

    public class FingerprintOPFormAuth
    {
        AxGrFingerXLib.AxGrFingerXCtrl grfingerx;
        private TTemplate template;
        public TRawImage  rawImage;

        public void InitializeGrFinger(AxGrFingerXLib.AxGrFingerXCtrl grfingerxFormAuth)
        {
            grfingerx = grfingerxFormAuth;
            grfingerx.Initialize();
            grfingerx.CapInitialize();

            template = new TTemplate();
        }

        public bool authenticate(System.Byte[] temp1, System.Byte[] temp2, System.Byte[] temp3)
        {
            //instantiating the new templates
            TTemplate t1 = new TTemplate();
            TTemplate t2 = new TTemplate();
            TTemplate t3 = new TTemplate();

            int score = 0;
            int result;


            System.Byte[] temp = temp1;
            System.Array.Copy(temp, 0, t1.tpt, 0, temp.Length);
            t1.size = temp.Length;

            temp = temp2;
            System.Array.Copy(temp, 0, t2.tpt, 0, temp.Length);
            t2.size = temp.Length;

            temp = temp3;
            System.Array.Copy(temp, 0, t3.tpt, 0, temp.Length);
            t3.size = temp.Length;

            //now we try to match with at least one of the user's fingerprint
            result = (int)grfingerx.Verify(ref t1.tpt, ref template.tpt,
                                           ref score, (int)GRConstants.GR_DEFAULT_CONTEXT);

            if ((GRConstants)result == GRConstants.GR_MATCH)
                return true;

            result = (int)grfingerx.Verify(ref t2.tpt, ref template.tpt,
                               ref score, (int)GRConstants.GR_DEFAULT_CONTEXT);

            if ((GRConstants)result == GRConstants.GR_MATCH)
                return true;

            result = (int)grfingerx.Verify(ref t3.tpt, ref template.tpt,
                               ref score, (int)GRConstants.GR_DEFAULT_CONTEXT);

            if ((GRConstants)result == GRConstants.GR_MATCH)
                return true;

            return false;
        }

        public void extractTemplate()
        {
            template.size = (int)GRConstants.GR_MAX_SIZE_TEMPLATE;
            grfingerx.Extract(ref rawImage.img, rawImage.width, rawImage.height, 
                              rawImage.Res,ref template.tpt, ref template.size, 
                              (int)GRConstants.GR_DEFAULT_CONTEXT);
        }
    }
}
