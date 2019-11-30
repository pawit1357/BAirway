using System;
using System.Collections.Generic;
using BAW.Model;

namespace BAW.Dao
{
    public class DefaultDao
    {
        private StationDao siteDao = new StationDao();
        public int getSiteID(String _code)
        {
           List<ModelStation> sites =  siteDao.Select("where site_code='"+_code+"'");
           if (sites != null)
           {
               if (sites.Count > 0)
               {
                   return sites[0].id;
               }
           }
           return -1;
        }
    }
}
