using System;

namespace opacity_forms.Classes.model
{
    internal class messages
    {
        public int id { get; set; }
        public string msg { get; set; }
        public int Y { get; set; }//-1 is every year
        public int D { get; set; }//-1 is every day
        public int M { get; set; }//-1 is every month
        public int W { get; set; }//-1 is every week
        public int has_end { get; set; }//0 is no and 1 is yes 
        public DateTime date { get; set; }//saving date
        public DateTime end_date { get; set; }//end date

    }
}
