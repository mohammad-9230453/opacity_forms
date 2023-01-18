using System;
using System.Windows.Forms;

namespace opacity_forms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Boxes.Forms.dateprojectstack.DGV());
            //return;
            //====================================================================================================================
            Classes.Helper.ENV.SERVER = "31.214.174.195";
            Classes.Helper.ENV.USER = "aryair_Ps";
            Classes.Helper.ENV.PASS = "Mohammad_Maleks534930";
            Classes.Helper.ENV.DB = "aryair_Ps";
            Classes.Helper.ENV.PORT = "3306";
            //====================================================================================================================
            Classes.Helper.ENV.SERVER = "127.0.0.1";
            Classes.Helper.ENV.USER = "mohammad_maleks";
            Classes.Helper.ENV.PASS = "Mohammad_Maleks534930";
            Classes.Helper.ENV.DB = "ps";
            Classes.Helper.ENV.PORT = "3306";
            //====================================================================================================================
            //Classes.Helper.ENV.SERVER = "127.0.0.1";
            //Classes.Helper.ENV.USER = "root";
            //Classes.Helper.ENV.PASS = "";
            //Classes.Helper.ENV.DB = "ps";
            //Classes.Helper.ENV.PORT = "3306";
            //====================================================================================================================
            Classes.Helper.ENV.SET_CONN();
            //====================================================================================================================
            //(new Classes.Helper.ENV())
            //    .SET("Server", "31.214.174.195")
            //    .SET("username", "aryair_Ps")
            //    .SET("password", "Mohammad_Maleks534930")
            //    .SET("database", "aryair_Ps")
            //    .SET("SSL Mode", "0")
            //    .SET("Port", "3306");
            //====================================================================================================================
            string code;
            int count;

            if (!Classes.Helper.Function.CheckForInternetConnection())// برسی اتصال به اینترنت
            {
                MessageBox.Show("خطای اتصال به اینترنت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DateTime today = DateTime.UtcNow.ToLocalTime();
            //DateTime today = Classes.Helper.Function.GetNetworkTime();
            Classes.global_inf.today = today;
            count = Classes.Helper.DB.GET_INT("SELECT COUNT(*) FROM programm");
            if (count != 1)
            {
                Application.Run(new Boxes.Forms.hash.New_Hash_Code_Form());
                return;
            }
            code = Classes.Helper.DB.GET_STR("SELECT hash_code FROM programm LIMIT 1", "hash_code");
            Classes.Helper.APP.hash hash = new Classes.Helper.APP.hash();
            bool can_continue = hash.hash_check(code.Trim(), test: false);
            //====================================================================================================================


            if (count == 1 && can_continue && hash.can_days > hash.pass_days)
            {
                //Application.Run(new Boxes.Forms.messege.message());//Convert.ToString(hash.pass_days), Convert.ToString(hash.can_days)));
                Application.Run(new background());//Convert.ToString(hash.pass_days), Convert.ToString(hash.can_days)));
                return;
            }
            else
            {
                if (!hash.test_mode)
                {

                    Application.Run(new Boxes.Forms.hash.New_Hash_Code_Form());
                    return;
                }
                else
                {
                    MessageBox.Show("مهلت شما برای استفاده از این نسخه به اتمام رسیده", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            //====================================================================================================================
            //Application.Run(new background());
        }
    }
}
