using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace opacity_forms.Classes.Helper
{
    internal class DB
    {
        private static string str_conn = Classes.Helper.ENV.STR_CONN;

        private static Boxes.Alert.Alert alert = new Boxes.Alert.Alert();
        //connection
        public static MySqlConnection GetConnection()
        {
            //datasource=localhost;
            //string sql = "Server=127.0.0.1; username=root; password=; database=tvco_test;SSL Mode=0";
            MySqlConnection conn = new MySqlConnection(str_conn);
            try
            {
                conn.Open();
            }
            catch (MySqlException e)
            {

                MessageBox.Show("خطای اتصال به سرور", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        //GET DATA TABLE
        public static DataTable GET_DATA_TABLE(string sql)
        {
            //DataTable ds = new DataTable();
            DataSet ds = new DataSet();
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da;

            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            if (con != null)
                con.Close();
            return ds.Tables[0] as DataTable;
        }

        // SQL QUERY
        public static void SQL_QUERY(string sql, bool has_alert = true)
        {
            MySqlConnection mySqlConnection = GetConnection();

            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            mySqlCommand.CommandType = System.Data.CommandType.Text;
            try
            {
                mySqlCommand.ExecuteNonQuery();
                if (has_alert) alert.alert("عملیات با موفقیت انجام شد", Boxes.Alert.Right_side.enmType.success);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error!\n" + ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            mySqlConnection.Close();

        }

        //GET INT
        public static int GET_INT(string sql)
        {
            MySqlConnection mySqlConnection = GetConnection();

            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);

            Int32 int_ = Convert.ToInt32(mySqlCommand.ExecuteScalar());
            return int_;
        }

        //Get_Float
        public static float Get_Float(string sql)
        {
            MySqlConnection mySqlConnection = GetConnection();

            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);

            float flt_ = Convert.ToSingle(mySqlCommand.ExecuteScalar());
            return flt_;
        }


        //GET STR
        public static string GET_STR(string query, string column)
        {
            string sql = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                return dr[column].ToString();
                conn.Close();
            }
            else
            {
                conn.Close();
                return null;
            }

        }

        // FILL TABLE

        public static void FILL_TABLE(string query, DataGridView dgv)
        {
            FILL_TABLE(query, dgv, new[] { "null" });
        }
        public static void FILL_TABLE(string query, DataGridView dgv, string[] dates)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            string sql = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.FillAsync(dataTable);


            Classes.Helper.Function.FIX_DT_DATE(dataTable, dates);

            dgv.DataSource = dataTable;

            //dgv.ReadOnly = true;
            //foreach (string gg in dates)
            //{
            //    if (gg != "null")
            //        dgv.Columns[gg].ReadOnly = false;
            //}

            conn.Close();
        }

        //GET BOOL
        public static bool GET_BOOL(string query)
        {
            string sql = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }

        }

        // FILL SELECT
        public static void FILL_SELECT(string query, ComboBox cmb)
        {
            string sql = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            adapter.FillAsync(dataTable);

            cmb.DataSource = dataTable;
            cmb.ValueMember = "value"; // id 
            cmb.DisplayMember = "name"; // name

            conn.Close();
        }
    }
}
