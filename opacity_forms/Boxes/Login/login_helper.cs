using System;
using System.Collections.Generic;
using System.Data;

namespace opacity_forms.Boxes.Login
{
    internal class login_helper
    {
        public static IDictionary<string, string[]> ACCESS(string person_id, string access_id)
        {
            IDictionary<string, string[]> access_ = new Dictionary<string, string[]>();

            string key;
            string[] value;
            List<string> strings = new List<string>();
            DataTable dt_0, dt_1, dt_2;
            dt_0 = Classes.Helper.DB.GET_DATA_TABLE($"SELECT * FROM accesses WHERE deep = 0 AND situation = 1 AND id = {access_id}");
            dt_1 = Classes.Helper.DB.GET_DATA_TABLE($"SELECT * FROM accesses WHERE deep = 1 AND situation = 1  AND parent_id = {access_id} AND id IN (SELECT access_id FROM person_accesses WHERE person_id = {person_id})");
            for (int i = 0; i < dt_1.Rows.Count; i++)
            {
                key = Convert.ToString(dt_1.Rows[i]["name"]).Trim().Replace(" ", "_");
                strings.Clear();
                dt_2 = Classes.Helper.DB.GET_DATA_TABLE($"SELECT * FROM accesses WHERE deep = 2 AND situation = 1  AND parent_id =  {Convert.ToString(dt_1.Rows[i]["id"]).Trim()} AND id IN (SELECT access_id FROM person_accesses WHERE person_id = {person_id})");
                for (int j = 0; j < dt_2.Rows.Count; j++)
                {
                    strings.Add(Convert.ToString(dt_2.Rows[j]["name"]).Trim().Replace(" ", "_"));// add child to str[]
                }
                value = strings.ToArray(); // values:str[]
                access_.Add(key, value); // key => values:str[]

            }
            // اینجا
            // انبار =>  ایجاد ، تغییر ، حذف ، خروجی_اکسل


            return access_;
        }
    }
}
