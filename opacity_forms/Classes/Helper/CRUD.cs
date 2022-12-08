using System.Collections.Generic;
using System.Linq;

namespace opacity_forms.Classes.Helper
{
    internal class CRUD
    {
        public static bool CAN_DELETE(string id, IDictionary<string, string[]> rel)
        {
            string[] arr;
            string table_name;
            bool result = true;
            string query;
            foreach (KeyValuePair<string, string[]> kvp in rel)
            {
                arr = kvp.Key.Split('.', ' ', '/', '\\', '\'', '"', '[', ']', '{', '}', ',', '*', '!', '@', '#', '$', '%', '^', '&', '(', ')', '+', '=', '-', '~', '`', ':', '?', '<', '>', ';', '|').Select(str => str.Trim()).ToArray();
                table_name = arr[0];
                //if (arr.Count() > 1)
                //{
                //    table_name = arr[0];
                //}
                query = string.Format("SELECT * FROM {0} WHERE {1} = {2} {3}", table_name, kvp.Value[0], id, kvp.Value[1]);
                if (Classes.Helper.DB.GET_BOOL(query))
                    result = false;
            }
            return result;
        }

        public static void SET_Situation_To(string table, string situation, string key, string id)
        {

            string query;
            query = string.Format("UPDATE {0} SET situation = {1} WHERE {2} = {3} ", table, situation, key, id);
            Classes.Helper.DB.SQL_QUERY(query);
        }
    }
}
