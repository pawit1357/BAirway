using System;
using System.Collections.Generic;
using BAW.Model;

namespace BAW.Utils
{
    public class MyFunction
    {
        public static string GetInvoice()
        {
            return DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") + "-";
        }

        public static int getMinute(string _hr)
        {
            int minute = 0;
            if (_hr.Length == 0) minute = 0;
            if (!_hr.Equals(""))
            {
                string[] hr = _hr.Split('.');
                switch (hr.Length)
                {
                    case 1:
                        minute = Convert.ToInt16(hr[0]) * 60;
                        break;
                    case 2:
                        minute = (Convert.ToInt16(hr[0]) * 60) + 30;
                        break;
                }
            }
            return minute;
        }
        public static bool isNumber(string value)
        {
            bool isNumber = false;
            try
            {
                Int32 test = Convert.ToInt32(value);
                isNumber = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isNumber;
        }

        public static int calDay(DateTime endDate, DateTime startDate)
        {
            TimeSpan count_date; // ไม่ต้อง new object TimeSpan (แต่ถึง new ก็ไม่ error แต่เสียเปล่า)
            count_date = endDate - startDate;
            return (int)Math.Ceiling(count_date.TotalDays); // Math.Ceiling() ปัดขึ้นเสมอ / Math.Floor() ปัดลงเสมอ เลือกเอาครับ.
        }
        //หาจำนวนนาที (เข้างานสาย)
        public static double getMinute(string begin, string end)
        {
            //Console.WriteLine("Myfunction.getMinute-->{0},{1}", begin, end);
            double total = 0;
            string[] dBegin = begin.Split(':');
            string[] DEnd = end.Split(':');
            double dbegin = (Convert.ToDouble(dBegin[0]) * 60) + Convert.ToDouble(dBegin[1].Split(' ')[0]);
            double dend = (Convert.ToDouble(DEnd[0]) * 60) + Convert.ToDouble(DEnd[1].Split(' ')[0]);
            if (dbegin > dend)
            {
                total = dbegin - dend;
            }
            return total;
        }

        public static string getMonth(int index)
        {
            string[] month = { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฏาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
            return month[index - 1];
        }
        public static int getYear(int _year)
        {
            int rYear = _year;
            if (_year < 2500)
            {
                rYear = _year + 543;
            }
            return rYear;
        }


        public static List<MasterModel> getYearDDL(int nextYear)
        {
            List<MasterModel> years = new List<MasterModel>();
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + nextYear; i++)
            {
                MasterModel tmp = new MasterModel();
                tmp.id = i;
                tmp.name = i + "";
                years.Add(tmp);
            }
            return years;
        }

        public static String getBoadingPass(ModelTransaction tran)
        {
            //M1HAMID/AHMED         E       BKKFCOTG 0944 209Y040E0070 100
            //M1GILJIMENEZ/PILA1 MS EKWGVQS BKKTDXPG 0305 207Y045A0016 300
            string fullName = tran.passenger_name + "                               ";
            string prefix = "                               ";
            string fromTo = tran.from_city + "" + tran.to_city;

            return String.Format("{0} {1} {2} {3} {4} {5}",
                fullName.Substring(0, 21).ToUpper(),
                prefix.Substring(0, 7).ToUpper(), fromTo.ToUpper(), tran.flight_no.ToUpper(), DateTime.Now.DayOfYear.ToString("000") + "Y" + tran.seat_no, "9999");

        }

    }
}
