using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITR
{
    public static class IPAddress
    {
        /// <summary>
        /// Get IP Address
        /// </summary>
        /// <returns></returns>
        public static String GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            String ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!String.IsNullOrEmpty(ipAddress))
            {
                String[] address = ipAddress.Split(',');
                if (address.Length > 0)
                {
                    return address[0];
                }
            }

            ipAddress = context.Request.UserHostAddress;

            if (ipAddress.Trim() == "::1")
            {

                String stringHostName = System.Net.Dns.GetHostName();
                System.Net.IPHostEntry ipHostEntry = System.Net.Dns.GetHostEntry(stringHostName);
                System.Net.IPAddress[] arrIPAddresses = ipHostEntry.AddressList;

                try
                {
                    ipAddress = arrIPAddresses[1].ToString();
                }
                catch (Exception)
                {

                    try
                    {
                        arrIPAddresses = System.Net.Dns.GetHostAddresses(stringHostName);
                        ipAddress = arrIPAddresses[0].ToString();
                    }
                    catch (Exception)
                    {
                        ipAddress = "127.0.0.1";
                    }
                }
            }
            return ipAddress;
        }
    }
}