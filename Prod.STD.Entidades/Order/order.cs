using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades
{

    public class order
    {
        public string orderid { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string country { get; set; }
        public IEnumerable<order_item> orderitems { get; set; }
        public decimal total { get; set; }
    }
}
