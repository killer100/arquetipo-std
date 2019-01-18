namespace Prod.STD.Entidades
{
    public class order_item
    {
        public string orderitemid { get; set; }
        public string orderid { get; set; }
        public string productname { get; set; }
        public int units { get; set; }
        public decimal unitprice { get; set; }        
    }
}
