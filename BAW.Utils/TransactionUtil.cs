using System;
using System.Collections.Generic;
using System.Text;
using BAW.Model;
using BAW.Dao;
using BAW.Biz;

namespace BAW.Utils
{
    public class TransactionUtil
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(TransactionUtil));
        public TransactionUtil()
        { }
        public static void transfer2Server()
        {
            int total = 0;
            int success = 0;

            try
            {

                TransactionDao dao = new TransactionDao();
                int StationID = Convert.ToInt16(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID"));
                String cri = " Where t.LoungePlace=" + StationID;
                List<ModelTransaction> lists = dao.SelectOffine(cri + " order by t.update_date desc", StationID);
                if (lists != null)
                {
                    total = lists.Count;
                    logger.Debug("# Start Transfer data to server.");
                    logger.Debug("Local transaction have " + lists.Count + " records.");
                    if (lists.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (ModelTransaction model in lists)
                        {
                            bool result = dao.Insert(model, StationID);
                            if (result)
                            {
                                logger.Debug("Local transaction have " + lists.Count + " records.");
                                //Delete local data when transfer to ser success.
                                if (dao.DeleteOffline(model, StationID))
                                {
                                    success++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("# " + ex.ToString());

            }
            logger.Debug("# Summary=> Total transfer total: " + total + " success: " + success + " fail: " + (total - success));
            logger.Debug("# End Transfer data to server.");

        }
        public static void downloadAuthenCode()
        {
            int success = 0;
            try
            {

            AuthenCodeDao dao = new AuthenCodeDao();
            int StationID = Convert.ToInt16(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID"));
            dao.deleteLocalDB();
            //STEP 1: Update used code to online authencode
            List<ModelAuthenCode> listOfUnUsedList = dao.SelectAllUnUse(StationID);
            if (listOfUnUsedList != null && listOfUnUsedList.Count > 0)
            {
                foreach (ModelAuthenCode model in listOfUnUsedList)
                {
                    if (dao.InsertOffline(model))
                    {
                        success++;
                    }
                }
            }

            }
            catch (Exception ex) {
                logger.Error("Exception:"+ex.ToString());

            }
            //logger.Debug("# Summary=> Total Download total: " + total + " success: " + success + " fail: " + (total - success));
            logger.Debug("# End Download data from server.");

        }

        public static void synCodeToOnline()
        {
            //int total = 0;
            //int success = 0;

            AuthenCodeDao dao = new AuthenCodeDao();
            int StationID = Convert.ToInt16(ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID"));

            //STEP 1: Update used code to online authencode
            StringBuilder sbSql = new StringBuilder();
            List<ModelAuthenCode> listAccessCode = dao.SelectOffineUsedCode(StationID);
            if (listAccessCode != null && listAccessCode.Count > 0)
            {
                foreach (ModelAuthenCode authCode in listAccessCode)
                {
                    sbSql.Append(authCode.ath_code);
                    sbSql.Append(",");
                }
                String useIds = sbSql.ToString().Substring(0, sbSql.ToString().Length - 1);
                dao.UpdateByListId(useIds, StationID);

            }

            //STEP 3: Download authencode to store on offine
            //List<ModelAuthenCode> listOfUnUsedList = dao.SelectAllUnUse(StationID);
            //if (listOfUnUsedList != null && listOfUnUsedList.Count > 0)
            //{
            //    foreach (ModelAuthenCode model in listOfUnUsedList)
            //    {
            //        if (dao.InsertOffline(model))
            //        {
            //            success++;
            //        }
            //    }
            //}

            //logger.Debug("# Summary=> Total Download total: " + total + " success: " + success + " fail: " + (total - success));
            logger.Debug("# End Download data from server.");

        }
        public static void downloadUsers()
        {
            String StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            int total = 0;
            int success = 0;
            UserDao dao = new UserDao();
            List<ModelUser> listAccessCode = dao.Select(" Where u.station_id=" + StationID);
            if (listAccessCode != null)
            {
                total = listAccessCode.Count;
                logger.Debug("# Start Download [USER] from server.");

                foreach (ModelUser model in listAccessCode)
                {
                    List<ModelUser> tmp = dao.SelectOffine(" Where user_name='" + model.user_name + "'");
                    if (tmp != null)
                    {
                        if (tmp.Count > 0)
                        {
                        }
                        else
                        {
                            if (dao.InsertOffline(model))
                            {
                                success++;
                            }
                        }
                    }
                }


                logger.Debug("# Summary=> Total Download total: " + total + " success: " + success + " fail: " + (total - success));
                logger.Debug("# End Download data from server.");
            }
            StaffDao staffDao = new StaffDao();
            List<ModelStaff> listStaff = staffDao.Select(" Where staff_station=" + StationID);
            if (listStaff != null)
            {
                total = listStaff.Count;
                logger.Debug("# Start Download [STAFF PROFILE] from server.");

                foreach (ModelStaff model in listStaff)
                {
                    List<ModelStaff> tmp = staffDao.SelectOffline(" Where staff_name='" + model.staff_name + "'");
                    if (tmp != null)
                    {
                        if (tmp.Count > 0)
                        {
                        }
                        else
                        {
                            if (staffDao.InsertOffline(model))
                            {
                                success++;
                            }
                        }
                    }
                }



                logger.Debug("# Summary=> Total Download total: " + total + " success: " + success + " fail: " + (total - success));
                logger.Debug("# End Download data from server.");
            }
        }
        public static void downloadLounge()
        {
            String StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            int total = 0;
            int success = 0;
            LoungeDao dao = new LoungeDao();
            List<ModelLounge> lists = dao.Select(" Where l.lounge_station=" + StationID);
            if (lists != null)
            {
                total = lists.Count;
                logger.Debug("# Start download [LOUNGE] from server.");

                foreach (ModelLounge model in lists)
                {
                    List<ModelLounge> tmp = dao.SelectOffline(" Where l.id='" + model.id + "'");
                    if (tmp != null)
                    {
                        if (tmp.Count > 0)
                        {
                        }
                        else
                        {
                            if (dao.InsertOffline(model))
                            {
                                success++;
                            }
                        }
                    }

                }
                logger.Debug("# Summary=> Total Download total: " + total + " success: " + success + " fail: " + (total - success));
                logger.Debug("# End Download data from server.");
            }
        }
        public static void downloadArea()
        {
            String StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            int total = 0;
            int success = 0;
            AreaDao dao = new AreaDao();
            List<ModelArea> lists = dao.Select(" Where area_station=" + StationID);
            if (lists != null)
            {
                total = lists.Count;
                logger.Debug("# Start download [AREA] from server.");

                foreach (ModelArea model in lists)
                {
                    List<ModelArea> tmp = dao.SelectOffine(" Where id='" + model.id + "'");
                    if (tmp != null)
                    {
                        if (tmp.Count > 0)
                        {
                        }
                        else
                        {
                            if (dao.InsertOffline(model))
                            {
                                success++;
                            }
                        }
                    }
                }
                logger.Debug("# Summary=> Total Download total: " + total + " success: " + success + " fail: " + (total - success));
                logger.Debug("# End Download data from server.");
            }
        }
        public static void downloadGroup()
        {
            String StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            int total = 0;
            int success = 0;
            GroupDao dao = new GroupDao();
            List<ModelGroup> lists = dao.Select("");
            if (lists != null)
            {
                total = lists.Count;
                logger.Debug("# Start download [GROUP] from server.");

                foreach (ModelGroup model in lists)
                {

                    List<ModelGroup> tmp = dao.SelectOffine(" Where group_code='" + model.group_code + "'");
                    if (tmp != null)
                    {
                        if (tmp.Count > 0)
                        {
                        }
                        else
                        {
                            //logger.Debug(">>"+model.id+","+model.group_code);
                            if (model.id > 0)
                            {
                                if (dao.InsertOffline(model))
                                {
                                    success++;
                                }
                            }
                        }
                    }

                }
                logger.Debug("# Summary=> Total Download total: " + total + " success: " + success + " fail: " + (total - success));
                logger.Debug("# End Download data from server.");
            }
        }
        public static void downloadRole()
        {
            String StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            int total = 0;
            int success = 0;
            RoleDao dao = new RoleDao();
            List<ModelRole> lists = dao.Select("");
            if (lists != null)
            {
                total = lists.Count;
                logger.Debug("# Start download [ROLE] from server.");

                foreach (ModelRole model in lists)
                {
                    List<ModelRole> tmp = dao.SelectOffline(" Where role_code='" + model.role_code + "'");
                    if (tmp != null)
                    {
                        if (tmp.Count > 0)
                        {
                        }
                        else
                        {
                            if (dao.InsertOffline(model))
                            {
                                success++;
                            }
                        }
                    }
                }
                logger.Debug("# Summary=> Total Download total: " + total + " success: " + success + " fail: " + (total - success));
                logger.Debug("# End Download data from server.");
            }
        }

        public static void downloadStation()
        {
            String StationID = ManageLOG.getValueFromRegistry(Configurations.AppRegName, "StationID");
            int total = 0;
            int success = 0;
            StationDao dao = new StationDao();
            List<ModelStation> lists = dao.Select("");
            if (lists != null)
            {
                total = lists.Count;
                logger.Debug("# Start download [STATION] from server.");

                foreach (ModelStation model in lists)
                {
                    List<ModelStation> tmp = dao.SelectOffine(" Where id='" + model.id + "'");
                    if (tmp != null)
                    {
                        if (tmp.Count > 0)
                        {
                        }
                        else
                        {
                            if (dao.InsertOffine(model))
                            {
                                success++;
                            }
                        }
                    }
                }
                logger.Debug("# Summary=> Total Download total: " + total + " success: " + success + " fail: " + (total - success));
                logger.Debug("# End Download data from server.");
            }
        }
    }
}
