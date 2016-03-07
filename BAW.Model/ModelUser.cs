using System;

namespace BAW.Model
{
    public class ModelUser : ModelBase
    {
        //public int staff_id { get; set; }
        public String user_name { get; set; }
        public String user_pass { get; set; }
        public int user_role { get; set; }
        public String userRoleName { get; set; }
        public String user_status { get; set; }
        public int stationId { get; set; }
    }
}
