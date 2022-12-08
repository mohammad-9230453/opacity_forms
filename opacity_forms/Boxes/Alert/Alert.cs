namespace opacity_forms.Boxes.Alert
{
    internal class Alert
    {

        public void alert(string msg, Boxes.Alert.Right_side.enmType type)
        {

            Boxes.Alert.Right_side alrt = new Boxes.Alert.Right_side();
            alrt.showAlert(msg, type);

        }

        public void shortAlert(string msg, Boxes.Alert.topShort.enmtype type)
        {

            Boxes.Alert.topShort alrt = new Boxes.Alert.topShort();
            alrt.showAlert(msg, type);

        }

        public void scroll(string msg)
        {

            Boxes.Alert.ScrollMessage alrt = new Boxes.Alert.ScrollMessage(msg);
            alrt.ShowDialog();

        }
    }
}
