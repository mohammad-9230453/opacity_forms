using System.Collections.Generic;

namespace opacity_forms.Classes.Helper.APP
{
    internal class Config
    {
        public Config()
        {


        }

        public enum enm_table
        {
            users_id,
            parts_id,
            projects_code,
            materials_id,
            raw_materials_id,
            salons_id,
            shifts_id,
            machines_id,
            products_id,
            part_outs_id,
        }

        public static IDictionary<string, string[]> TableRelations(enm_table table)
        {
            switch (table)
            {


                case enm_table.users_id:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"user_machine" , new string[]{ "user_id" , null  } },
                    {"part_daily" , new string[]{ "user_id" , null } },
                    };
                    break;


                case enm_table.parts_id:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"product_childs" , new string[]{ "child_id" , " AND child_type = 0 " } },
                    {"store_daily" , new string[]{ "child_id" , " AND child_type = 3 " } },
                    {"store_daily;" , new string[]{ "child_id" , " AND child_type = 4 " } },
                    {"parts" , new string[]{ "last_id" , " AND level != 0 " } },
                    {"part_machine" , new string[]{ "part_id" , null } },
                    {"part_daily" , new string[]{ "part_id"  , null } },
                    {"part_store" , new string[]{ "part_id"  , null } },
                    {"waste_part_store" , new string[]{ "part_id"  , null } },
                    };
                    break;



                case enm_table.projects_code:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"borade_store" , new string[]{ "pro_code" , " AND has_pro = 1 " } },
                    {"waste_part_store" , new string[]{ "pro_code" , " AND has_pro = 1 " } },
                    {"part_store" , new string[]{ "pro_code" , " AND has_pro = 1 " } },
                    {"product_store" , new string[]{ "pro_code" , " AND has_pro = 1 " } },
                    {"rm_store" , new string[]{ "pro_code" , " AND has_pro = 1 " } },
                    {"tahmil_store" , new string[]{ "pro_code" , " AND has_pro = 1 " } },
                    {"product_assembly_daily" , new string[]{ "pro_code" , " AND has_pro = 1 " } },
                    {"part_daily" , new string[]{ "prog_id" , " AND has_pro = 1 " } },
                    {"store_daily" , new string[]{ "pro_code" , " AND has_pro = 1 " } },
                    };
                    break;



                case enm_table.materials_id:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"borade_store" , new string[]{ "material_id" , null } },
                    {"raw_materials" , new string[]{ "material_id" , null } },
                    {"product_materials" , new string[]{ "material_id" , null } },
                    {"rm_store" , new string[]{ "material_id" , null } },
                    {"store_daily" , new string[]{ "child_id" , " AND child_type = 1 " } },
                    {"store_daily;" , new string[]{ "child_id" , " AND child_type = 2 " } },
                    };
                    break;



                case enm_table.raw_materials_id:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"rm_store" , new string[]{ "rm_id" , null } },
                    {"tahmil_store" , new string[]{ "rm_id" , null } },
                    {"parts" , new string[]{ "rm_id" , null } },
                    {"parts;" , new string[]{ "last_id" , " AND level = 0 " } },
                    {"store_daily" , new string[]{ "child_id" , " AND child_type = 5 " } },
                    {"store_daily;" , new string[]{ "child_id" , " AND child_type = 6 " } },
                    };
                    break;



                case enm_table.salons_id:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"machines" , new string[]{ "salon_id" , null } },
                    {"part_daily" , new string[]{ "salon_id" , null } },
                    };
                    break;



                case enm_table.shifts_id:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"part_daily" , new string[]{ "shift_id" , null } },
                    };
                    break;



                case enm_table.machines_id:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"part_daily" , new string[]{ "machine_id" , null } },
                    {"part_machine" , new string[]{ "machine_id" , null } },
                    {"user_machine" , new string[]{ "machine_id" , null } },
                    };
                    break;



                case enm_table.products_id:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"part_daily" , new string[]{ "product_id" , null } },
                    {"product_materials" , new string[]{ "product_id" , null } },
                    {"product_store" , new string[]{ "product_id" , null } },
                    {"projects" , new string[]{ "product_id" , null } },
                    {"product_assemblies_name" , new string[]{ "product_id" , null } },
                    {"store_daily" , new string[]{ "child_id" , " AND child_type = 7 " } },
                    {"store_daily;" , new string[]{ "child_id" , " AND child_type = 8 " } },
                    };
                    break;



                case enm_table.part_outs_id:
                    return
                    new Dictionary<string, string[]>()
                    {
                    {"product_childs" , new string[]{ "child_id" , " AND child_type = 1 " } },
                    {"po_store" , new string[]{ "po_id"  , null } },
                    };
                    break;



                default:
                    return null;
                    break;
            }
        }


    }
}
