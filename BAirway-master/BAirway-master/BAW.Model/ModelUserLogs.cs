using System;

namespace BAW.Model
{
    public class ModelUserLogs : ModelBase
    {
        public const int EVENT_LOGIN = 1;
        public const int EVENT_LOGOUT = 2;
        public const int EVENT_LOGIN_FAIL = 3;
        public const int EVENT_EXCEPTION = 4;

        public int user_id { get; set; }
        public int event_id { get; set; }
        public String log_description { get; set; }
        public DateTime log_date { get; set; }
    }
}
