namespace opacity_forms.Classes.Helper
{
    internal class ENV
    {
        //private static string str_conn = @"Server=127.0.0.1; User ID=root; password=;Persist Security Info= False; Initial Catalog=tvco_test;SSL Mode=0";

        //datasource=localhost;
        public static string SERVER = "127.0.0.1";//185.10.75.8
        public static string USER = "root"; //test_tc
        public static string PASS = "";//534930
        public static string DB = "ps";//tvco_test
        public static string STR_CONN = $"Server={SERVER}; username={USER}; password={PASS}; database={DB}; SSL Mode=0";
        public static void SET_CONN()
        {
            STR_CONN = $"Server={SERVER}; username={USER}; password={PASS}; database={DB}; SSL Mode=0";
        }
        //public static string STR_CONN = "Server=185.10.75.8; username=test_tc; password=534930; database=tvco_test; SSL Mode=0";

        public static string STR_SERVER = null;
    }
}
