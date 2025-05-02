using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Project.models
{
    public class Delivery
    {
        public int DeliveryID { get; set; }
        public string Status { get; set; }
        public string DeliveryAddress { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public int OrderID { get; set; }
        public int DeliveryPersonID { get; set; }
        public decimal DeliveryFee { get; set; }

    }
}
