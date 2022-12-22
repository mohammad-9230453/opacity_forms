using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace opacity_forms.Classes.Helper
{
    internal class Function
    {
        //============================================(تابع فیکس کردن جداول)================================================
        public static void sizeDGV(DataGridView dgv)
        {
            //  1
            //DataGridViewElementStates states = DataGridViewElementStates.None;
            ////dgv.ScrollBars = ScrollBars.None;
            //var totalHeight = dgv.Rows.GetRowsHeight(states) + dgv.ColumnHeadersHeight;
            ////totalHeight += dgv.Rows.Count * 1; // a correction I need
            //var totalWidth = dgv.Columns.GetColumnsWidth(states) + dgv.RowHeadersWidth;
            //dgv.ClientSize = new Size(totalWidth, totalHeight);



            //  2 : خوب کار میکنه
            dgv.Height =
            dgv.Rows.Cast<DataGridViewRow>().Sum(x => x.Height)
            + (dgv.ColumnHeadersVisible ? dgv.ColumnHeadersHeight : 0) + 3;

            //dgv.Width =
            //dgv.Columns.Cast<DataGridViewColumn>().Sum(x => x.Width)
            //+ (dgv.RowHeadersVisible ? dgv.RowHeadersWidth : 0) + SystemInformation.VerticalScrollBarWidth;
            //SystemInformation.HorizontalScrollBarHeight;
        }
        //============================================(تابع فیکس کردن جداول)================================================



        public static string RowConvertToStr(DataRow row, string cell)
        {
            return
                row[cell] == DBNull.Value
                ?
                string.Empty
                :
                //(T)row[cell] ;
                row[cell].ToString();
        }

        public static int RowConvertToInt(DataRow row, string cell)
        {
            var val = row[cell];

            return
                row[cell] == DBNull.Value || (val.GetType() != typeof(UInt32) && val.GetType() != typeof(int))
                ?
                0
                :
                //(T)row[cell] ;
                int.Parse(row[cell].ToString());
        }
        public static float RowConvertToFloat(DataRow row, string cell)
        {

            return
                row[cell] == DBNull.Value || (row[cell].GetType() != typeof(Double) && row[cell].GetType() != typeof(float) && row[cell].GetType() != typeof(Single))
                ?
                0
                :
                //(T)row[cell] ;
                float.Parse(row[cell].ToString());
        }










        //***********BEST============================================(تابع برسی اتصال اینترنت)================================================
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool CheckForInternetConnection()
        {
            return InternetGetConnectedState(out int i, 0);
        }
        //***********BEST============================================(تابع برسی اتصال اینترنت)================================================












        //============================================(تابع برسی اتصال اینترنت)================================================
        public static bool CheckForInternetConnection_2()
        {
            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            if (reply.Status == IPStatus.Success)
            {
                // presumably online
                return true;
            }
            return false;


            //try
            //{
            //    using (var client = new WebClient())
            //    using (var stream = client.OpenRead("http://www.google.com"))
            //    {
            //        return true;
            //    }
            //}
            //catch
            //{
            //    return false;
            //}
        }
        //============================================(تابع برسی اتصال اینترنت)================================================

















        //***********BEST============================================(تابع گرفتن تاریخ و زمان به صورت آنلاین)================================================
        public static DateTime GetNetworkTime()
        {
            //default Windows time server
            const string ntpServer = "time.windows.com";

            // NTP message size - 16 bytes of the digest (RFC 2030)
            var ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 3000;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }
        //***********BEST============================================(تابع گرفتن تاریخ و زمان به صورت آنلاین)================================================









        //============================================(تابع گرفتن تاریخ و زمان به صورت آنلاین)================================================
        public static DateTime GetDateFromNet()
        {

            var client = new TcpClient("time.nist.gov", 13);
            using (var streamReader = new StreamReader(client.GetStream()))
            {
                var response = streamReader.ReadToEnd();
                var utcDateTimeString = response.Substring(7, 17);
                var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                return localDateTime;
            }
        }
        //============================================(تابع گرفتن تاریخ و زمان به صورت آنلاین)================================================








        //============================================(تابع گرفتن تاریخ و زمان به صورت آنلاین)================================================
        public static DateTime GetFastestNISTDate()
        {
            var result = DateTime.MinValue;

            // Initialize the list of NIST time servers
            // http://tf.nist.gov/tf-cgi/servers.cgi
            string[] servers = new string[] {
                "nist1-ny.ustiming.org",
                "nist1-nj.ustiming.org",
                "nist1-pa.ustiming.org",
                "time-a.nist.gov",
                "time-b.nist.gov",
                "nist1.aol-va.symmetricom.com",
                "nist1.columbiacountyga.gov",
                "nist1-chi.ustiming.org",
                "nist.expertsmi.com",
                "nist.netservicesgroup.com"
                };

            // Try 5 servers in random order to spread the load
            Random rnd = new Random();
            foreach (string server in servers.OrderBy(s => rnd.NextDouble()).Take(5))
            {
                try
                {
                    // Connect to the server (at port 13) and get the response
                    string serverResponse = string.Empty;
                    using (var reader = new StreamReader(new System.Net.Sockets.TcpClient(server, 13).GetStream()))
                    {
                        serverResponse = reader.ReadToEnd();
                    }

                    // If a response was received
                    if (!string.IsNullOrEmpty(serverResponse))
                    {
                        // Split the response string ("55596 11-02-14 13:54:11 00 0 0 478.1 UTC(NIST) *")
                        string[] tokens = serverResponse.Split(' ');

                        // Check the number of tokens
                        if (tokens.Length >= 6)
                        {
                            // Check the health status
                            string health = tokens[5];
                            if (health == "0")
                            {
                                // Get date and time parts from the server response
                                string[] dateParts = tokens[1].Split('-');
                                string[] timeParts = tokens[2].Split(':');

                                // Create a DateTime instance
                                DateTime utcDateTime = new DateTime(
                                    Convert.ToInt32(dateParts[0]) + 2000,
                                    Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]),
                                    Convert.ToInt32(timeParts[0]), Convert.ToInt32(timeParts[1]),
                                    Convert.ToInt32(timeParts[2]));

                                // Convert received (UTC) DateTime value to the local timezone
                                result = utcDateTime.ToLocalTime();

                                return result;
                                // Response successfully received; exit the loop

                            }
                        }

                    }

                }
                catch
                {
                    // Ignore exception and try the next server
                }
            }
            return result;
        }
        //============================================(تابع گرفتن تاریخ و زمان به صورت آنلاین)================================================









        //============================================(تابع فیکس کردن ستون هایی از جداول که تاریخ اند)================================================
        public static void FIX_DT_DATE(DataTable dataTable, string[] dates)
        {
            if (dates.Count() > 0)
            {
                string str_date, PersianDate;
                DateTime dt;
                PersianCalendar pc;
                if (dataTable.Rows.Count > 0)
                {
                    dataTable.Columns.Add("empty");
                    foreach (string date in dates)
                    {


                        if (date != "null")
                        {

                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                str_date = Convert.ToString(dataTable.Rows[i][date]);//--------------err!!!
                                if (!string.IsNullOrEmpty(str_date))
                                {

                                    pc = new PersianCalendar();
                                    dt = DateTime.Parse(str_date.Split(' ')[0],
                                              System.Globalization.CultureInfo.InvariantCulture);
                                    PersianDate = string.Format("{0}/{1}/{2}", Convert.ToString(pc.GetYear(dt)), Convert.ToString(pc.GetMonth(dt)), Convert.ToString(pc.GetDayOfMonth(dt)));
                                    dataTable.Rows[i]["empty"] = PersianDate.Split(' ')[0];


                                }
                                else
                                {
                                    dataTable.Rows[i][date] = "0000/00/00";
                                }
                            }

                            dataTable.Columns.Remove(date);
                            dataTable.Columns.Add(date);
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                dataTable.Rows[i][date] = dataTable.Rows[i]["empty"];
                            }
                        }

                    }
                    dataTable.Columns.Remove("empty");
                }
            }
        }
        //============================================(تابع فیکس کردن ستون هایی از جداول که تاریخ اند)================================================

        public static int TO_INT_WEEK(DayOfWeek day)
        {
            switch (day.ToString())
            {
                case "Monday":
                    return 2;
                    break;
                case "Tuesday":
                    return 3;
                    break;
                case "Wednesday":
                    return 4;
                    break;
                case "Thursday":
                    return 5;
                    break;
                case "Friday":
                    return 6;
                    break;
                case "Saturday":
                    return 0;
                    break;
                case "Sunday":
                    return 1;
                    break;
            }
            return -1;
        }
        public static string TO_STR_WEEK(DayOfWeek day)
        {
            switch (day.ToString())
            {
                case "Monday":
                    return "دوشنبه";
                    break;
                case "Tuesday":
                    return "سه شنبه";
                    break;
                case "Wednesday":
                    return "چهارشنبه";
                    break;
                case "Thursday":
                    return "پنجشنبه";
                    break;
                case "Friday":
                    return "جمعه";
                    break;
                case "Saturday":
                    return "شنبه";
                    break;
                case "Sunday":
                    return "یکشنبه";
                    break;
            }
            return null;
        }
        public static string TO_STR_MONTH(int m)
        {
            switch (m)
            {
                case 1:
                    return "فروردین";
                    break;
                case 2:
                    return "اردیبهشت";
                    break;
                case 3:
                    return "خرداد";
                    break;
                case 4:
                    return "تیر";
                    break;
                case 5:
                    return "مرداد";
                    break;
                case 6:
                    return "شهریور";
                    break;
                case 7:
                    return "مهر";
                    break;
                case 8:
                    return "آبان";
                    break;
                case 9:
                    return "آذر";
                    break;
                case 10:
                    return "دی";
                    break;
                case 11:
                    return "بهمن";
                    break;
                case 12:
                    return "اسفند";
                    break;
            }
            return null;
        }
        public static string TO_STR_EnMONTH(int m)
        {
            switch (m)
            {
                case 1:
                    return "ژانویه";
                    break;
                case 2:
                    return "فوریه";
                    break;
                case 3:
                    return "مارچ";
                    break;
                case 4:
                    return "آپریل";
                    break;
                case 5:
                    return "می";
                    break;
                case 6:
                    return "ژوئن";
                    break;
                case 7:
                    return "جولای";
                    break;
                case 8:
                    return "آگوست";
                    break;
                case 9:
                    return "سپتامبر";
                    break;
                case 10:
                    return "اکتبر";
                    break;
                case 11:
                    return "نوامبر";
                    break;
                case 12:
                    return "دسامبر";
                    break;
            }
            return null;
        }


    }
}
