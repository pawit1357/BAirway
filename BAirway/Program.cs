using BAW.Dao;
using BAW.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BAirway
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Connection.IsServerConnected())
            {
                //upload data from localdb-->online db
                #region "Syncronize Data"
                Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
                thread.Start();
                #endregion
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMenu());

        }




        public static void WorkThreadFunction()
        {
            try
            {
                TransactionUtil.transfer2Server();
                TransactionUtil.downloadAuthenCode();

                //TransactionUtil.downloadStation();
                TransactionUtil.downloadUsers();
                //TransactionUtil.downloadLounge();
                //TransactionUtil.downloadArea();
                //TransactionUtil.downloadGroup();
                //TransactionUtil.downloadRole();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // log errors
                //logger.Equals(ex.Message);
            }
        }


    }
}
