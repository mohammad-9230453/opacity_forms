using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace opacity_forms.Classes.Helper.APP
{
    internal class hash
    {
        public bool test_mode = false;
        public int days_no_, pass_days, can_days;
        Boxes.Alert.Alert alert = new Boxes.Alert.Alert();
        //private string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
        //           "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
        //           "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
        //           "M/d/yyyy h:mm", "M/d/yyyy h:mm",
        //           "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};
        //if (!DateTime.TryParseExact(date, formats,
        //                        new CultureInfo("en-US"),
        //                        DateTimeStyles.None,
        //                        out dateValue))
        //{
        //    return false;
        //
        //}


        private string company = "e%p=$!d";

        // برای تاریخ شروع قرارداد
        private IDictionary<string, string> _hash = new Dictionary<string, string>()
        {
            { "a" , "0"},
            { "B" , "0"},
            { "A" , "1"},
            { "b" , "1"},
            { "c" , "2"},
            { "D" , "2"},
            { "C" , "3"},
            { "d" , "3"},
            { "e" , "4"},
            { "F" , "4"},
            { "E" , "5"},
            { "f" , "5"},
            { "g" , "6"},
            { "H" , "6"},
            { "G" , "7"},
            { "h" , "7"},
            { "i" , "8"},
            { "J" , "8"},
            { "I" , "9"},
            { "j" , "9"},
        };

        // برای مدت قرارداد به تعداد روز
        private IDictionary<string, string> _hash2 = new Dictionary<string, string>()
        {
            { "g" , "0"},{ "G" , "1"},{ "I" , "2"},{ "i" , "3"},{ "k" , "4"},{ "K" , "5"},{ "m" , "6"},{ "M" , "7"},{ "o" , "8"},{ "O" , "9"},
            { "H" , "0"},{ "h" , "1"},{ "j" , "2"},{ "J" , "3"},{ "L" , "4"},{ "l" , "5"},{ "N" , "6"},{ "n" , "7"},{ "P" , "8"},{ "p" , "9"},

        };

        //
        //[0]rSv[1]rSv[2]rSv[ 3 ]rSv[4]rSv[ 5 ]rSv[6]rSv[7]
        //
        //
        //  [3] : [0]tUw[ 1:D ]tUw[ 2:M ]tUw[ 3:Y ]tUw[4]tUw[5]
        //
        //
        //  [5] : [ 0:commpany ]xYz[ 1:Number ]xYz[2]
        //
        //
        //  [5] : [ e%p=$!d ]xYz  [ 007: (gH|gH|nM) , 030: (gH|iJ|gH) ,365: (iJ|mN|lK) ]  xYz[2]
        //
        //  code  Split('r' , 'S' , 'v'),
        //  arr_count = 8 ,
        //  3:date ,
        //  5:days
        //
        //
        //
        //date  Split('t' , 'U' , 'w') , arr_count = 6 , 1:D:00 , 2:M:00 , 3:Y:0000
        //          |a|b|c|C|e|E|   |g|G|i|I|
        // (t,U,w)  |B|A|D|d|F|f|   |H|h|J|j|  (t,U,w) => in 3
        //          |0|1|2|3|4|5|   |6|7|8|9|
        //          ------------- = مازاد به استفاده در جاهای دیگر
        //
        //
        //day number Split('x', 'Y', 'z') arr_count = 3 , 1:number:000
        //          |H|h|j|J|   |k|K|m|M|o|O|
        // (x,Y,z)  |g|G|I|i|   |L|l|N|n|P|p|  (x,Y,z)  => in 5
        //          |0|1|2|3|   |4|5|6|7|8|9|
        //                      ------------- = مازاد به استفاده در جاهای دیگر
        //
        //
        //
        // q,Q, R,T,V,W,X,Z, s,u,y =  کاراکترهای ازاد
        //          
        //
        // ex : 6/6/1995  38 day =>[ 06 D | 06 M | 1995 Y | 038 Day ](1,2,3),(1)   06:aH 06:
        //
        //
        //qRy5*@$rT=V)y9%SuQZ$&XvWtDdtaHUAeabwRtqrVSe%p=$!dxGHgYQXSZyrqu
        //  0    |    1  |  2   |   date(3)      | |               |    |

        public bool hash_check(string code, bool test = false)
        {
            this.test_mode = test;
            //======================================================================================
            if (test)
                code = "qRy5*@$rT=V)y9%SuQZ$&XvWtDdtaHUAEabwRtqrVSe%p=$!dxGHgYQXSZyrqu";  //  در صورتی که بخام نسخه ای ازمایشی بدم که به هیچ وجه نتونن تغییری توش بدن
            //======================================================================================

            string empty_, date, days_number;
            string[] arr, empty_arr;
            char emp_ch;
            //code = arr L10
            arr = code.Split('r', 'S', 'v').Select(str => str.Trim()).ToArray();
            if (arr.Count() != 8)
                return false;
            //date = arr[3] L6
            empty_ = arr[3];
            empty_arr = empty_.Split('t', 'U', 'w').Select(str => str.Trim()).ToArray();
            if (empty_arr.Count() != 6)
                return false;
            //day
            if (!_hash.ContainsKey(empty_arr[1].Trim()[0].ToString()) || !_hash.ContainsKey(empty_arr[1].Trim()[1].ToString()) || empty_arr[1].Trim().Length != 2)//D
            {
                return false;

            }
            //month
            if (!_hash.ContainsKey(empty_arr[2].Trim()[0].ToString()) || !_hash.ContainsKey(empty_arr[2].Trim()[1].ToString()) || empty_arr[2].Trim().Length != 2)//M
            {
                return false;

            }
            //year
            if (!_hash.ContainsKey(empty_arr[3].Trim()[0].ToString()) || !_hash.ContainsKey(empty_arr[3].Trim()[1].ToString()) || !_hash.ContainsKey(empty_arr[3].Trim()[2].ToString()) || !_hash.ContainsKey(empty_arr[3].Trim()[3].ToString()) || empty_arr[3].Trim().Length != 4)//Y
            {
                return false;

            }


            // تاریخ
            DateTime dateValue;

            // https://www.w3schools.com/mysql/func_mysql_date_add.asp

            //date = Classes.Helper.DB.GET_STR("SELECT DATE_ADD(NOW(), INTERVAL 0 DAY) AS date", "date"); // یافتن تاریخی به مدت این روز بعد از امروز  0=همین امروز    1=فردا
            //date = Classes.Helper.DB.GET_STR("SELECT NOW() AS date", "date"); // همین امروز
            //DateTime today = DateTime.Parse(date.Split(' ')[0], System.Globalization.CultureInfo.InvariantCulture);


            // امروز*****************************************************************امروز*************************************************************************امروز
            DateTime today = DateTime.UtcNow;
            //DateTime today = Classes.Helper.Function.GetNetworkTime();




            //DateTime today = Classes.Helper.Function.GetDateFromNet();


            //DateTime today = DateTime.Now;


            // اگه تاریخ خارجی انتخاب بشه
            //str_date
            //date =
            //       _hash[empty_arr[1].Trim()[0].ToString()] + _hash[empty_arr[1].Trim()[1].ToString()] + "/" +
            //       _hash[empty_arr[2].Trim()[0].ToString()] + _hash[empty_arr[2].Trim()[1].ToString()] + "/" +
            //       _hash[empty_arr[3].Trim()[0].ToString()] + _hash[empty_arr[3].Trim()[1].ToString()] + _hash[empty_arr[3].Trim()[2].ToString()] + _hash[empty_arr[3].Trim()[3].ToString()] ;
            //
            //date check
            //           dateValue = DateTime.Parse(date,
            //                                     System.Globalization.CultureInfo.InvariantCulture);
            //


            // اگه تاریخ فارسی انتخاب بشه
            PersianCalendar pc = new PersianCalendar();
            dateValue = new DateTime(
                int.Parse(_hash[empty_arr[3].Trim()[0].ToString()] + _hash[empty_arr[3].Trim()[1].ToString()] + _hash[empty_arr[3].Trim()[2].ToString()] + _hash[empty_arr[3].Trim()[3].ToString()]),
                int.Parse(_hash[empty_arr[2].Trim()[0].ToString()] + _hash[empty_arr[2].Trim()[1].ToString()]),
                int.Parse(_hash[empty_arr[1].Trim()[0].ToString()] + _hash[empty_arr[1].Trim()[1].ToString()]),
                pc);



            var total_days = ((today - dateValue).Days);
            this.pass_days = total_days;



            //==================================
            //days = arr[5] L6
            empty_ = arr[5];
            empty_arr = empty_.Split('x', 'Y', 'z').Select(str => str.Trim()).ToArray();
            if (empty_arr.Count() != 3)
                return false;
            if (this.company != empty_arr[0])
                return false;
            //

            if (!_hash2.ContainsKey(empty_arr[1].Trim()[0].ToString()) || !_hash2.ContainsKey(empty_arr[1].Trim()[1].ToString()) || !_hash2.ContainsKey(empty_arr[1].Trim()[2].ToString()) || empty_arr[1].Trim().Length != 3)//number:000
            {
                return false;

            }
            days_number = _hash2[empty_arr[1].Trim()[0].ToString()] + _hash2[empty_arr[1].Trim()[1].ToString()] + _hash2[empty_arr[1].Trim()[2].ToString()];
            can_days = int.Parse(days_number);
            return true;
        }
    }
}
