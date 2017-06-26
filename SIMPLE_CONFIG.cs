using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace launcher
{
    class SIMPLE_CONFIG
    {
        public static string    IP = "115.159.156.195"; /* EXTERNAL IP ADDRESS OR DOMAIN NAME [ example-wow.com ] 
                                                   */

        public static int       PORT = 4000,      /* MYSQL DB PORT 
                                                   */
                                TIMEOUT = 1;      /* TIME LIMIT, IN SECONDS, IN WHICH THE LAUNCHER VERIFIES IF THE SERVER IS ONLINE OR NOT
                                                     DEFAULT: 1
                                                     !!WARNING!!
                                                     IF YOUR SERVER HAS A SLOW INTERNET CONNECTION YOU MIGHT WANT TO INCREASE THE TIME TO
                                                     2 OR EVEN 3 SECONDS [ if it actually takes more than 2 seconds you might consider buying a new host ]
                                                     INCREASING THE `TIMEOUT` WILL ALSO MAKE YOUR LAUNCHER START HARDER.
                                                   */
    }
}
