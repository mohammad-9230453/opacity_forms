using System;
using System.Windows.Forms;

namespace opacity_forms.Boxes.Forms.hash
{
    public partial class New_Hash_Code_Form : Form
    {
        public New_Hash_Code_Form()
        {
            InitializeComponent();
        }
        Boxes.Alert.Alert alert = new Boxes.Alert.Alert();
        private void btn_check_Click(object sender, EventArgs e)
        {
            if (txt_code.Text.Length < 5)
            {
                alert.shortAlert("مقدار وارد شده صحیح نمیباشد", Alert.topShort.enmtype.error);
                return;
            }

            Classes.Helper.APP.hash hash = new Classes.Helper.APP.hash();
            if (!hash.hash_check(txt_code.Text))
            {
                alert.shortAlert("!!!", Alert.topShort.enmtype.error);
            }
            if (hash.can_days < hash.pass_days)
            {
                alert.shortAlert("زمان این کد تمام شده و دیگر کارایی ندارد", Alert.topShort.enmtype.error);
                return;
            }

            Classes.Helper.DB.SQL_QUERY("INSERT INTO programm (hash_code) VALUES ( '" + Convert.ToString(txt_code.Text) + "' )");
            alert.shortAlert("کد شما با موفقیت ثبت گردید", Alert.topShort.enmtype.success);
            alert.shortAlert("برنامه را ببندید و دوباره باز کنید", Alert.topShort.enmtype.success);

            // alert.shortAlert(Convert.ToString(hash.can_days)+">"+Convert.ToString(hash.pass_days), Alert.topShort.enmtype.error);


        }

        private void New_Hash_Code_Form_Load(object sender, EventArgs e)
        {
            Classes.Helper.DB.SQL_QUERY("DELETE FROM programm");
        }
    }
}
