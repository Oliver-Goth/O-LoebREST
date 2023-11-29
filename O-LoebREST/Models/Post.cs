using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace O_LoebREST.Class
{
    public class Post
    {

        // skal indeholde 2 Kordinater:
        // bredegrad (N / S) mellem -90 0g 90
        // Længdegrad (V / Ø) mellem -180 og -180
        // source:
        // https://support.google.com/maps/answer/18539?hl=es&co=GENIE.Platform%3DAndroid

        // måder at skrive Kordinater på:
        // Decimalgrader(DD) : 41.40338, 2.17403
        //                     ( N / S )( V / Ø )
        // Grader, minutter og sekunder(DMS) : 41°24'12.2"N 2°10'26.5"E
        // Grader og decimalminutter(DMM) : 41 24.2028, 2 10.4418

        public void validate()
        {

        }
    }
}
