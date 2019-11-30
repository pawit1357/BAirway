using System;
using System.Collections.Generic;
using System.Web.Services;

namespace RadiusService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public String getAthCodeInfo(String athCode)
        {
            RadAcctDao dao = new RadAcctDao();
            List<RadAcct> listRad = dao.Select(athCode);
            if (listRad.Count > 0) {
                return listRad[0].acctstarttime.ToString("yyyy-MM-dd HH:MM:ss");
            }
            return String.Empty;
        }
    }
}