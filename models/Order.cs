using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Project.models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int RestaurantID { get; set; }
        public int CustomerID { get; set; }
    }
}
