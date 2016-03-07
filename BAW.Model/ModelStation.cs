using System;

namespace BAW.Model
{
    public class ModelStation : ModelBase
    {
        public String site_code { get; set; }
        public String site_name { get; set; }

        public String site_host_ip { get; set; }
        public String site_host_user { get; set; }
        public String site_host_pass { get; set; }

    }
}
