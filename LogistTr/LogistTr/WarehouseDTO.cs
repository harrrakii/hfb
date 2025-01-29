using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogistTr
{
    public class WarehouseDTO
    {
        public string OrderNumber { get; set; }
        public string CargoDescription { get; set; }
        public decimal? Weight { get; set; }
        public string WarehouseStatus { get; set; }
        public int WarehouseId { get; set; }
        public int OrderId { get; set; }
    }
}
