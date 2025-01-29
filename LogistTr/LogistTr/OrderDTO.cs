using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogistTr
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Cargo { get; set; }
        public decimal? Size { get; set; }
        public string Address { get; set; }
        public string Driver { get; set; }
        public string Payment { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime DeliveryDate { get; set; }
    }
}
