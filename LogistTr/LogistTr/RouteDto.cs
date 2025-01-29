using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogistTr
{
    public class RouteDto
    {
        public string OrderNumber { get; set; }  // Номер заказа
        public string EndPoint_ { get; set; }    // Адрес доставки
        public int? Distance { get; set; }     // Протяженность маршрута (км)
        public string VehicleStatus { get; set; }  // Состояние транспортного средства
        public string DeliveryStatus { get; set; }  // Статус доставки
        public int VehicleId { get; set; }  // ID транспортного средства
        public int RouteId { get; set; }    // ID маршрута
    }
}
