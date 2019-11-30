using BAW.Biz;
using BAW.Dao;
using BAW.Model;
using BAW.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using Tamir.SharpSsh;
using System.Linq;

namespace BAW.TransferDailyTransaction
{
    public class Program
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {

            try
            {
                String[] _SkipSelfStation = Configurations.SkipSelfStation.Split(',');

                RadDao radDao = new RadDao();
                /*
                 0 = Run all station.
                 * format : ????.exe {station} {yyyyMMdd}
                 */
                String _station = args.Length > 0 ? (args[0].Equals("0") ? "" : String.IsNullOrEmpty(args[0]) ? "" : " Where id=" + args[0]) : "";
                Sftp sftp = new Sftp("sftp.bangkokair.net", "cat2gos", "C@t2g0s");
                Console.WriteLine("sftp.bangkokair.net Connected. " + DateTime.Now);
                sftp.Connect(22);



                DateTime runDate = args.Length > 0 ? (String.IsNullOrEmpty(args[1]) ? DateTime.Now.AddDays(-1) : new DateTime(Convert.ToInt16(args[1].Substring(0, 4)), Convert.ToInt16(args[1].Substring(4, 2)), Convert.ToInt16(args[1].Substring(6, 2)), 0, 0, 0)) : DateTime.Now.AddDays(-1);//Run pevios day
                TransactionDao tranDao = new TransactionDao();

                StationDao stationDao = new StationDao();
                LoungeDao loungeDao = new LoungeDao();
                AreaDao areaDao = new AreaDao();

                List<ModelStation> stations = stationDao.Select("" + _station);
                if (stations.Count > 0)
                {
                    foreach (ModelStation station in stations)
                    {
                        if (station.id != 99)
                        {
                            List<ModelLounge> lounges = loungeDao.Select(" Where lounge_station=" + station.id);

                            if (null != lounges && lounges.Count > 0)
                            {
                                foreach (ModelLounge lounge in lounges)
                                {
                                    List<ModelArea> areas = areaDao.Select(" Where area_station=" + station.id + " and area_lounge=" + lounge.id);
                                    if (null != areas && areas.Count > 0)
                                    {
                                        foreach (ModelArea area in areas)
                                        {

                                            String PATH_LOCAL = String.Format(@"{0}{1}\Gen log\Log {2} {3}", Configurations.DailyTransactionLogsPath, station.site_code, lounge.lounge_name, area.area_name);
                                            String PATH_FTP = String.Format("{0}/Gen log/Log {1} {2}", station.site_code, lounge.lounge_name, area.area_name);
                                            DirectoryInfo di = new DirectoryInfo(@"" + PATH_LOCAL);

                                            if (!di.Exists) { di.Create(); }
                                            //Create path on server
                                            sftp.Mkdir(PATH_FTP);

                                            String cri = "";
                                            //if station equal (BKK-Inter,BKK - Dom
                                            if (_SkipSelfStation.Contains(station.id.ToString()))
                                            {
                                                cri = "where date(create_date) = date('" + runDate.ToString("yyyy-MM-dd") + "') and LoungePlace=" + station.id + " and LoungeType=" + lounge.id + " and LoungeArea=" + area.id + " and group_id <> 32 and type <> 'S'  order by LoungePlace asc,LoungeType asc,LoungeArea asc,update_date desc";
                                            }
                                            else
                                            {
                                                cri = "where date(create_date) = date('" + runDate.ToString("yyyy-MM-dd") + "') and LoungePlace=" + station.id + " and LoungeType=" + lounge.id + " and LoungeArea=" + area.id + " and group_id <> 32  order by LoungePlace asc,LoungeType asc,LoungeArea asc,update_date desc";
                                            }

                                            List<ModelTransaction> lists = tranDao.Select(cri, station.id);

                                            ManageLOG mangeLog = new ManageLOG();
                                            if (null != lists && lists.Count > 0)
                                            {

                                                mangeLog.fileName = String.Format(@"{0}\export_{1}.csv", PATH_LOCAL, runDate.ToString("yyyy-MM-dd"));
                                                mangeLog.folderName = PATH_LOCAL;
                                                String header = "No,Username,Type,GenDate,GroupName,Duration,PassengerName,FromCity,ToCity,AirlineCode,FlightNo,DateOfFlight,SeatNo,LoungePlace,LoungeType,LoungeArea,Owner,Begin_Date,Status,Remark,AccessCode,Remark2,LastUpdate,LastUpdateBy";
                                                mangeLog.WriteLog(header);
                                                int seq = 1;
                                                foreach (ModelTransaction transaction in lists)
                                                {

                                                    String athCodeBeginUse = (transaction.begin_date == null) ? String.Empty : transaction.begin_date.ToString("yyyy-MM-dd HH:mm:ss");
                                                    try
                                                    {
                                                        athCodeBeginUse = radDao.getAthCodeInfo(transaction.ath_id);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        logger.Debug("* Skip get begindate of " + station.site_code + ">>" + lounge.lounge_name + ">>" + area.area_name + " ::ID::" + transaction.id);
                                                        logger.Error("*  " + ex.InnerException.Message);
                                                    }


                                                    mangeLog.WriteLog(
                                                        seq + "," +                              //No
                                                        Utils.CustomUtils.RemoveSpecialCharacters(transaction.passenger_name + "" + transaction.flight_no + "" + transaction.seat_no) + "," +
                                                        transaction.type + "," +                 //Type
                                                        transaction.create_date.ToString("yyyy-MM-dd HH:mm:ss") + "," +
                                                        transaction.group_idName + "," +         //GroupName
                                                        transaction.duration + "," +             //Duration
                                                        Utils.CustomUtils.RemoveSpecialCharacters(transaction.passenger_name) + "," +       //PassengerName
                                                        Utils.CustomUtils.RemoveSpecialCharacters(transaction.from_city) + "," +            //FromCity
                                                        Utils.CustomUtils.RemoveSpecialCharacters(transaction.to_city) + "," +              //ToCity
                                                        Utils.CustomUtils.RemoveSpecialCharacters(transaction.airline_code) + "," +         //AirlineCode
                                                        Utils.CustomUtils.RemoveSpecialCharacters(transaction.flight_no) + "," +            //FlightNo
                                                        transaction.date_of_flight.ToString("yyyy-MM-dd HH:mm:ss") + "," +
                                                        Utils.CustomUtils.RemoveSpecialCharacters(transaction.seat_no) + "," +              //SeatNo
                                                        transaction.LoungeSiteCode + "," +           //LoungePlace
                                                        transaction.LoungeName + "," +           //LoungeType
                                                        transaction.LoungeAreaName + "," +       //LoungeArea
                                                        transaction.create_byName + "," +        //Owner
                                                        athCodeBeginUse + "," +
                                                        transaction.status + "," +               //Status
                                                        Utils.CustomUtils.RemoveSpecialCharacters(transaction.remark) + "," +               //Remark
                                                        transaction.ath_id + "," +               //AccessCode
                                                        Utils.CustomUtils.RemoveSpecialCharacters(transaction.remakr2) + "," +              //Remark2
                                                        transaction.update_date.ToString("yyyy-MM-dd HH:mm:ss") + "," +
                                                        transaction.update_byName                //LastUpdateBy
                                                        );
                                                    //Update begindate
                                                    tranDao.UpdateBeginDate(transaction, station.id);
                                                    seq++;
                                                }
                                            }
                                            else
                                            {
                                                mangeLog.fileName = String.Format(@"{0}\export_{1} No data.csv", PATH_LOCAL, runDate.ToString("yyyy-MM-dd"));
                                                mangeLog.folderName = PATH_LOCAL;
                                                mangeLog.WriteLog("");
                                                logger.Debug("Transaction of " + station.site_code + ">>" + lounge.lounge_name + ">>" + area.area_name + " is empty");
                                            }
                                            /*
                                             * TRANSFER FILE TO SERVER.
                                             */
                                            //if (!closeFtp)
                                            //{
                                            sftp.Put(mangeLog.fileName, PATH_FTP);
                                            //}
                                        }
                                    }
                                    else
                                    {
                                        logger.Debug("Area of " + station.site_code + ">>" + lounge.lounge_name + " is empty.");
                                    }
                                }
                            }
                            else
                            {
                                logger.Debug("Lounge of " + station.site_code + " is empty.");
                            }
                        }
                    }

                }
                else
                {
                    logger.Debug("Station is empty.");
                }
                /*
                 * CLOSE FTP
                 */
                sftp.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
