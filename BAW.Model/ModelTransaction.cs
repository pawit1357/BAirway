using System;

namespace BAW.Model
{
    public class ModelTransaction 
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public String boardingpass { get; set; }
        public String group_idName { get; set; }
        public String passenger_name { get; set; }
        public String from_city { get; set; }
        public String to_city { get; set; }
        public String airline_code { get; set; }
        public String flight_no { get; set; }
        public DateTime date_of_flight { get; set; }
        public String date_of_flight_start { get; set; }
        public String date_of_flight_end { get; set; }
        public String date_of_flight_custom { get; set; }
        public String seat_no { get; set; }
        public String remark { get; set; }
        public String remakr2 { get; set; }
        public String ath_id { get; set; }
        public String ath_idName { get; set; }

        public int create_by { get; set; }
        public String create_byName { get; set; }
        public DateTime create_date { get; set; }
        public String create_date_custom { get; set; }
        public String update_byName { get; set; }
        public int update_by { get; set; }
        public DateTime update_date { get; set; }
        public String update_date_custom { get; set; }
        public int LoungePlace { get; set; }
        public String LoungeSite { get; set; }
        public String LoungeSiteCode { get; set; }
        public int LoungeType { get; set; }
        public String LoungeName { get; set; }
        public int LoungeArea { get; set; }
        public String LoungeAreaName { get; set; }
        public String type { get; set; }
        public int duration { get; set; }
        public DateTime begin_date { get; set; }
        public String begin_date_custom { get; set; }
        public String status { get; set; }



    }
}
