using System;

namespace BAW.Model
{
    public class ModelStaff : ModelBase
    {
        public String staff_name { get; set; }
        public String staff_surname { get; set; }
        public int staff_station { get; set; }
        public int staff_lounge { get; set; }
        public int staff_area { get; set; }
        public String status { get; set; }
    }
}
